using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;

namespace Fasetto.Word
{
    /// <summary>
    /// The dock position of the window
    /// </summary>
    public enum WindowDockPosition
    {
        /// <summary>
        /// Not docked
        /// </summary>
        Undocked,

        /// <summary>
        /// Docked to the left of the screen
        /// </summary>
        Left,

        /// <summary>
        /// Docked to the right of the screen
        /// </summary>
        Right,
    }

    /// <summary>
    /// Fixes the issue with Windows of Style <see cref="WindowStyle.None"/> covering the taskbar
    /// </summary>
    public class WindowResizer
    {
        #region Private Members

        /// <summary>
        /// How close to the edge the window has to be to be detected as at the edge of the screen
        /// </summary>
        private const int EdgeTolerance = 2;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition mLastDock = WindowDockPosition.Undocked;

        /// <summary>
        /// The last screen the window was on
        /// </summary>
        private IntPtr mLastScreen;

        /// <summary>
        /// The last calculated available screen size
        /// </summary>
        private Rect mScreenSize = new Rect();

        /// <summary>
        /// The transform matrix used to convert WPF sizes to screen pixels
        /// </summary>
        private Matrix mTransformToDevice;

        /// <summary>
        /// The window to handle the resizing for
        /// </summary>
        private readonly Window _mWindow;

        #endregion Private Members

        #region Dll Imports

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool GetCursorPos(out Point lpPoint);

        [DllImport("user32.dll")]
        private static extern bool GetMonitorInfo(IntPtr hMonitor, MonitorInfo lpmi);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern IntPtr MonitorFromPoint(Point pt, MonitorOptions dwFlags);

        #endregion Dll Imports



        #region Public Events

        /// <summary>
        /// Called when the window dock position changes
        /// </summary>
        public event Action<WindowDockPosition> WindowDockChanged = (dock) => { };

        #endregion Public Events

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="window">The window to monitor and correctly maximize</param>
        public WindowResizer(Window window)
        {
            // The Window Handle
            _mWindow = window;

            // Create transform visual (for converting WPF size to pixel size)
            GetTransform();

            // Listen out for source initialized to setup
            _mWindow.SourceInitialized += Window_SourceInitialized;

            // Monitor for edge docking
            _mWindow.SizeChanged += Window_SizeChanged;
        }

        #endregion Constructor

        #region Initialize

        /// <summary>
        /// Gets the transform object used to convert WPF sizes to screen pixels
        /// </summary>
        private void GetTransform()
        {
            // Get the visual source
            var source = PresentationSource.FromVisual(_mWindow);

            // Reset the transform to default
            mTransformToDevice = default(Matrix);

            // Otherwise, get the new transform object
            if (source?.CompositionTarget != null) mTransformToDevice = source.CompositionTarget.TransformToDevice;
        }

        /// <summary>
        /// Initialize and hook into the windows message pump
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SourceInitialized(object sender, System.EventArgs e)
        {
            // Get the handle of this window
            var handle = (new WindowInteropHelper(_mWindow)).Handle;
            var handleSource = HwndSource.FromHwnd(handle);

            // Hook into it's Windows messages
            handleSource?.AddHook(WindowProc);
        }

        #endregion Initialize

        #region Edge Docking

        /// <summary>
        /// Monitors for size changes and detects if the window has been docked (Aero snap) to an edge
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            // We cannot find positioning until the window transform has been established
            if (mTransformToDevice == default(Matrix))
                return;

            // Get the WPF size
            var size = e.NewSize;

            // Get window rectangle
            var top = _mWindow.Top;
            var left = _mWindow.Left;
            var bottom = top + size.Height;
            var right = left + _mWindow.Width;

            // Get window position/size in device pixels
            var windowTopLeft = mTransformToDevice.Transform(new System.Windows.Point(left, top));
            var windowBottomRight = mTransformToDevice.Transform(new System.Windows.Point(right, bottom));

            // Check for edges docked
            var edgedTop = windowTopLeft.Y <= (mScreenSize.Top + EdgeTolerance);
            var edgedLeft = windowTopLeft.X <= (mScreenSize.Left + EdgeTolerance);
            var edgedBottom = windowBottomRight.Y >= (mScreenSize.Bottom - EdgeTolerance);
            var edgedRight = windowBottomRight.X >= (mScreenSize.Right - EdgeTolerance);

            // Get docked position
            var dock = WindowDockPosition.Undocked;

            // Left docking
            if (edgedTop && edgedBottom && edgedLeft)
                dock = WindowDockPosition.Left;
            else if (edgedTop && edgedBottom && edgedRight)
                dock = WindowDockPosition.Right;
            // None
            else
                return;
                //dock = WindowDockPosition.Undocked;

            // If dock has changed
            if (dock != mLastDock)
                // Inform listeners
                WindowDockChanged(dock);

            // Save last dock position
            mLastDock = dock;
        }

        #endregion Edge Docking

        #region Windows Proc

        /// <summary>
        /// Listens out for all windows messages for this window
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="msg"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <param name="handled"></param>
        /// <returns></returns>
        private IntPtr WindowProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            switch (msg)
            {
                // Handle the GetMinMaxInfo of the Window
                case 0x0024:/* WM_GETMINMAXINFO */
                    WmGetMinMaxInfo(hwnd, lParam);
                    handled = true;
                    break;
            }

            return (IntPtr)0;
        }

        #endregion Windows Proc



        #region Private Methods

        /// <summary>
        /// Get the min/max window size for this window Correctly accounting for the taskbar size and position
        /// </summary>
        /// <param name="hwnd"></param>
        /// <param name="lParam"></param>
        private void WmGetMinMaxInfo(System.IntPtr hwnd, System.IntPtr lParam)
        {
            // Get the point position to determine what screen we are on
            GetCursorPos(out var lMousePosition);

            // Get the primary monitor at cursor position 0,0
            var lPrimaryScreen = MonitorFromPoint(new Point(0, 0), MonitorOptions.MonitorDefaultToPrimary);

            // Try and get the primary screen information
            var lPrimaryScreenInfo = new MonitorInfo();
            if (GetMonitorInfo(lPrimaryScreen, lPrimaryScreenInfo) == false)
                return;

            // Now get the current screen
            var lCurrentScreen = MonitorFromPoint(lMousePosition, MonitorOptions.MonitorDefaultToNearest);

            // If this has changed from the last one, update the transform
            if (lCurrentScreen != mLastScreen || mTransformToDevice == default(Matrix))
                GetTransform();

            // Store last know screen
            mLastScreen = lCurrentScreen;

            // Get min/max structure to fill with information
            var lMmi = (MinMaxInfo)Marshal.PtrToStructure(lParam, typeof(MinMaxInfo));

            // If it is the primary screen, use the rcWork variable
            if (lPrimaryScreen.Equals(lCurrentScreen) == true)
            {
                lMmi.mMaxPosition.X = lPrimaryScreenInfo.mRcWork.mLeft;
                lMmi.mMaxPosition.Y = lPrimaryScreenInfo.mRcWork.mTop;
                lMmi.mMaxSize.X = lPrimaryScreenInfo.mRcWork.mRight - lPrimaryScreenInfo.mRcWork.mLeft;
                lMmi.mMaxSize.Y = lPrimaryScreenInfo.mRcWork.mBottom - lPrimaryScreenInfo.mRcWork.mTop;
            }
            // Otherwise it's the rcMonitor values
            else
            {
                lMmi.mMaxPosition.X = lPrimaryScreenInfo.mRcMonitor.mLeft;
                lMmi.mMaxPosition.Y = lPrimaryScreenInfo.mRcMonitor.mTop;
                lMmi.mMaxSize.X = lPrimaryScreenInfo.mRcMonitor.mRight - lPrimaryScreenInfo.mRcMonitor.mLeft;
                lMmi.mMaxSize.Y = lPrimaryScreenInfo.mRcMonitor.mBottom - lPrimaryScreenInfo.mRcMonitor.mTop;
            }

            // Set min size
            var minSize = mTransformToDevice.Transform(new System.Windows.Point(_mWindow.MinWidth, _mWindow.MinHeight));

            lMmi.mMinTrackSize.X = (int)minSize.X;
            lMmi.mMinTrackSize.Y = (int)minSize.Y;

            // Store new size
            mScreenSize = new Rect(lMmi.mMaxPosition.X, lMmi.mMaxPosition.Y, lMmi.mMaxSize.X, lMmi.mMaxSize.Y);

            // Now we have the max size, allow the host to tweak as needed
            Marshal.StructureToPtr(lMmi, lParam, true);
        }

        #endregion Private Methods
    }

    #region Dll Helper Structures

    /// <inheritdoc/>
    internal enum MonitorOptions : uint
    {
        MonitorDefaultToNull = 0x00000000,
        MonitorDefaultToPrimary = 0x00000001,
        MonitorDefaultToNearest = 0x00000002
    }

    /// <summary>
    /// Information about maximum and minimum window sizes
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct MinMaxInfo : IEquatable<MinMaxInfo>
    {
        /// <summary>
        /// Reserved screen area
        /// </summary>
        public Point mReserved;

        /// <summary>
        /// The maximum size
        /// </summary>
        public Point mMaxSize;

        /// <summary>
        /// The maximum position on the screeen
        /// </summary>
        public Point mMaxPosition;

        /// <summary>
        /// Minimum track size(?)
        /// </summary>
        public Point mMinTrackSize;

        /// <summary>
        /// Maximum track size(?)
        /// </summary>
        public Point mMaxTrackSize;

        /// <summary>
        /// Return wether a type equals another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(MinMaxInfo other)
        {
            return false;
        }
    };

    /// <summary>
    /// A point refered to as Point.X and Point.Y on the screen (or anywhere else)
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// x coordinate of point.
        /// </summary>
        public int X;

        /// <summary>
        /// y coordinate of point.
        /// </summary>
        public int Y;

        /// <summary>
        /// Construct a point of coordinates (x,y).
        /// </summary>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Indicates whether wether a type is equal to another
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Point other)
        {
            return false;
        }
    }

    /// <inheritdoc/>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rectangle : IEquatable<Rectangle>
    {
        /// <summary>
        /// Integer values for a rectangles left, top, right and bottom position (in effect its size)
        /// </summary>
        public int mLeft, mTop, mRight, mBottom;

        /// <summary>
        /// The <see cref="Rectangle"/> constructor
        /// </summary>
        /// <param name="left"></param>
        /// <param name="top"></param>
        /// <param name="right"></param>
        /// <param name="bottom"></param>
        public Rectangle(int left, int top, int right, int bottom)
        {
            mLeft = left;
            mTop = top;
            mRight = right;
            mBottom = bottom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(Rectangle other)
        {
            return false;
        }
    }

    /// <summary>
    /// Monitor info such as its total size, available work area and any flags
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public class MonitorInfo
    {
        /// <summary>
        /// The size of the <see cref="MonitorInfo"/>
        /// </summary>
        public int mCbSize = Marshal.SizeOf(typeof(MonitorInfo));

        /// <summary>
        /// The total size of the monitor rectangle
        /// </summary>
        public Rectangle mRcMonitor = new Rectangle();

        /// <summary>
        /// The actual available are on the monitor
        /// </summary>
        public Rectangle mRcWork = new Rectangle();

        /// <summary>
        /// Any Monitor info flags
        /// </summary>
        public int mDwFlags = 0;
    }

    #endregion Dll Helper Structures
}