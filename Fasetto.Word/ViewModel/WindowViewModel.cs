using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;

namespace Fasetto.Word
{
    /// <summary>
    /// The View model for the window
    /// </summary>
    class WindowViewModel : BaseViewModel
    {
        #region private members

        /// <summary>
        /// The windows this ViewModel controls
        /// </summary>
        private Window _window;

        /// <summary>
        /// The margin around the window to allow for a dropshadow
        /// </summary>
        private int _outerMarginSize = 10;

        /// <summary>
        /// the radius of the edge around the window
        /// </summary>
        private int _windowRadius = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition _dockPosition = WindowDockPosition.Undocked;

        #endregion

        #region Commands

        /// <summary>
        /// The command to minimize the window
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// The command to maximize the window
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// The command to close the window
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// The command to show the System Menu
        /// </summary>
        public ICommand SystemMenuCommand { get; set; }

        #endregion

        #region Public Properties

        /// <summary>
        /// The padding of the main window content
        /// </summary>
        //public Thickness InnerContentPadding => new Thickness(ResizeBorder);
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);


        /// <summary>
        /// True if the window should be borderless because its docked/maximized
        /// </summary>
        public bool Borderless => (_window.WindowState == WindowState.Maximized || _dockPosition != WindowDockPosition.Undocked);

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a dropshadow
        /// </summary>
        public int OuterMarginSize
        {
            get => Borderless ? 0 : _outerMarginSize;
            set => _outerMarginSize = value;
        }

        /// <summary>
        /// The thickness of the OuterMargin
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// the radius of the edge around the window
        /// </summary>
        public int WindowRadius
        {
            get => Borderless ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The Radius of the corner edge of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The height of the titlebar
        /// </summary>
        public int TitleHeight { get; set; } = 36;

        /// <summary>
        /// The title bar height as gridlength
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// The minimum  width the window can be
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 400;

        /// <summary>
        /// The minimum height the window can be
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 400;

        /// <summary>
        /// The current page of the App
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Constructor
        /// <summary>
        /// The default constructor
        /// </summary>
        public WindowViewModel(Window window)
        {
            _window = window;

            //Listen for Window Resize event
            _window.StateChanged += (sender, e) =>
            {
                // Fire of events on resizing of window
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            //Create commands
            MinimizeCommand = new RelayCommand(() => _window.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => _window.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => _window.Close());
            SystemMenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(_window, GetMousePosition(_window)));

            //Fix window resize issue when window.style is none
            var resizer = new WindowResizer(_window);
        }
        #endregion

        #region Private helper functions

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <returns></returns>
        private Point GetMousePosition(Window window)
        {
            var position = Mouse.GetPosition(window);
            return new Point(position.X + window.Left, position.Y + window.Top);
        }

        #endregion

    }
}
