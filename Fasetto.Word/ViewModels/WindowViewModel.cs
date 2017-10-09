namespace Fasetto.Word
{
    using System.Windows;
    using System.Windows.Input;
    using Fasetto.Word.Core;

    /// <summary>
    /// The View model for the windowHandle
    /// </summary>
    internal class WindowViewModel : BaseViewModel
    {
        #region private members

        /// <summary>
        /// The margin around the windowHandle to allow for a drop shadow
        /// </summary>
        private int outerMarginSize = 10;

        /// <summary>
        /// The last known dock position
        /// </summary>
        private WindowDockPosition windowDockPosition = WindowDockPosition.Undocked;

        /// <summary>
        /// The windows this ViewModel controls
        /// </summary>
        private Window windowHandle;

        /// <summary>
        /// the radius of the edge around the windowHandle
        /// </summary>
        private int windowRadius = 10;

        #endregion private members

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="WindowViewModel"/> class.
        /// </summary>
        /// <param name="windowHandle">The windowHandle.</param>
        public WindowViewModel(Window windowHandle)
        {
            this.windowHandle = windowHandle;

            // Listen for Window Resize event
            this.windowHandle.StateChanged += (sender, e) =>
                {
                    // Fire of events on resizing of windowHandle
                    OnPropertyChanged(nameof(ResizeBorderThickness));
                    OnPropertyChanged(nameof(OuterMarginSize));
                    OnPropertyChanged(nameof(OuterMarginSizeThickness));
                    OnPropertyChanged(nameof(WindowRadius));
                    OnPropertyChanged(nameof(WindowCornerRadius));
                };

            // Create commands
            MinimizeCommand = new RelayCommand(() => this.windowHandle.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => this.windowHandle.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => this.windowHandle.Close());
            SystemMenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(this.windowHandle, GetMousePosition(this.windowHandle)));

            // Fix windowHandle resize issue when windowHandle.style is none
            var resizer = new WindowResizer(this.windowHandle);
        }

        #endregion Constructor

        #region Commands

        /// <summary>
        /// Gets or sets the command to close the windowHandle
        /// </summary>
        public ICommand CloseCommand { get; set; }

        /// <summary>
        /// Gets or sets the command to maximize the windowHandle
        /// </summary>
        public ICommand MaximizeCommand { get; set; }

        /// <summary>
        /// Gets or sets the command to minimize the windowHandle
        /// </summary>
        public ICommand MinimizeCommand { get; set; }

        /// <summary>
        /// Gets or sets the command to show the System Menu
        /// </summary>
        public ICommand SystemMenuCommand { get; set; }

        #endregion Commands



        #region Public Properties

        /// <summary>
        /// Gets or sets true if the windowHandle should be borderless because its docked/maximized
        /// </summary>
        public bool Borderless => windowHandle.WindowState == WindowState.Maximized || windowDockPosition != WindowDockPosition.Undocked;

        /// <summary>
        /// Gets or sets the padding of the main windowHandle content
        /// </summary>
        public Thickness InnerContentPadding { get; set; } = new Thickness(0);

        /// <summary>
        /// Gets or sets the margin around the windowHandle to allow for a drop shadow
        /// </summary>
        public int OuterMarginSize
        {
            get => Borderless ? 0 : outerMarginSize;
            set => outerMarginSize = value;
        }

        /// <summary>
        /// Gets or sets the thickness of the OuterMargin
        /// </summary>
        public Thickness OuterMarginSizeThickness => new Thickness(OuterMarginSize);

        /// <summary>
        /// The size of the resize border around the windowHandle
        /// </summary>
        public int ResizeBorder => Borderless ? 0 : 6;

        /// <summary>
        /// Gets or sets the size of the resize border around the windowHandle, taking into account
        /// the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder + OuterMarginSize);

        /// <summary>
        /// Gets or sets the height of the title bar
        /// </summary>
        public int TitleHeight { get; set; } = 36;

        /// <summary>
        /// Gets or sets the title bar height as grid length
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight + ResizeBorder);

        /// <summary>
        /// Gets or sets the Radius of the corner edge of the windowHandle
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// Gets or sets the minimum height the windowHandle can be
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 500;

        /// <summary>
        /// Gets or sets the minimum width the windowHandle can be
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 800;

        /// <summary>
        /// Gets or sets the radius of the edge around the windowHandle
        /// </summary>
        public int WindowRadius
        {
            get => Borderless ? 0 : windowRadius;
            set => windowRadius = value;
        }

        #endregion Public Properties

        #region Private helper functions

        /// <summary>
        /// Gets the current mouse position on the screen
        /// </summary>
        /// <param name="window">The window handle</param>
        /// <returns>Returns a mouse position as a <see cref="Point"/></returns>
        private Point GetMousePosition(Window window)
        {
            var position = Mouse.GetPosition(window);
            return new Point(position.X + window.Left, position.Y + window.Top);
        }

        #endregion Private helper functions
    }
}