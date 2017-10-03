﻿using System;
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
        private Window _window;

        //The margin around the window to allow for a dropshadow
        private int _outerMarginSize = 10;
        //the radius of the edge around the window
        private int _windowRadius = 10;

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
        public Thickness InnerContentPadding => new Thickness(ResizeBorder);

        /// <summary>
        /// The size of the resize border around the window
        /// </summary>
        public int ResizeBorder { get; set; } = 6;

        /// <summary>
        /// The size of the resize border around the window, taking into account the outer margin
        /// </summary>
        public Thickness ResizeBorderThickness => new Thickness(ResizeBorder+OuterMarginSize);

        /// <summary>
        /// The margin around the window to allow for a dropshadow
        /// </summary>
        public int OuterMarginSize
        {
            get => _window.WindowState == WindowState.Maximized ? 0 : _outerMarginSize;
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
            get => _window.WindowState == WindowState.Maximized ? 0 : _windowRadius;
            set => _windowRadius = value;
        }

        /// <summary>
        /// The Radius of the corner edge of the window
        /// </summary>
        public CornerRadius WindowCornerRadius => new CornerRadius(WindowRadius);

        /// <summary>
        /// The height of the titlebar
        /// </summary>
        public int TitleHeight { get; set; } = 42;

        /// <summary>
        /// The title bar height as gridlength
        /// </summary>
        public GridLength TitleHeightGridLength => new GridLength(TitleHeight+ResizeBorder);

        /// <summary>
        /// The minimum  width the window can be
        /// </summary>
        public int WindowMinimumWidth { get; set; } = 400;
        
        /// <summary>
        /// The minimum height the window can be
        /// </summary>
        public int WindowMinimumHeight { get; set; } = 400;

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
