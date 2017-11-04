// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePage.cs" company="mitos[dash]kalandiel">
//     2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
// BasePage for all pages to inherit from and gain basic function
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Fasetto.Word
{
    using Fasetto.Word.Core;
    using System.ComponentModel;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    /// <inheritdoc/>
    /// <summary>
    /// BasePage for all pages to inherit from and gain basic functionality
    /// </summary>
    public class BasePage : UserControl
    {
        #region Public Constructors

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Fasetto.Word.BasePage"/> class.
        /// </summary>
        public BasePage()
        {
            //During Desing-time don't animate
            if (DesignerProperties.GetIsInDesignMode(this))
                return;

            // If we are animating, hide the animation, for it to load properly
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen for the PageLoad event and hook into it.
            Loaded += BasePage_LoadedAsync;
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// A flag to indicate if this page should animate out on load. Useful for when we are moving
        /// the page to another frame
        /// </summary>
        public bool AnimateOut { get; set; }

        /// <summary>
        /// Gets or sets the page load animation.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Gets or sets the page unload animation.
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        /// <summary>
        /// Gets or sets how long the slide animation lasts
        /// </summary>
        public float SlideSeconds { get; set; } = 0.4f;

        #endregion Public Properties

        #region Animation Load / Unload

        /// <summary>
        /// The animation when a page gets loaded
        /// </summary>
        /// <param name="sender">The page to be animated</param>
        /// <param name="e">Any parameters passed</param>
        private async void BasePage_LoadedAsync(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AnimateOut)
            {
                await AnimateOutAsync();
            }
            else
            {
                await AnimateInAsync();
            }
        }

        /// <summary>
        /// Animate the PageLoad
        /// </summary>
        /// <returns>The <see cref="Task"/> result</returns>
        public async Task AnimateInAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds, width: (int)Application.Current.MainWindow.Width);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Animate the PageUnload
        /// </summary>
        /// <returns>The <see cref="Task"/> result</returns>
        public async Task AnimateOutAsync()
        {
            if (PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeftAsync(SlideSeconds);
                    break;

                default:
                    break;
            }
        }

        #endregion Animation Load / Unload
    }

    /// <inheritdoc/>
    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    /// <typeparam name="VM">The mViewModel Type</typeparam>
    public class BasePage<VM> : BasePage
        where VM : Core.BasePopupMenuViewModel, new()

    {
        #region Constructor

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Fasetto.Word.BasePage"/> class.
        /// </summary>
        public BasePage() : base()
        {
            // Create a default view model
            ViewModel = new VM();
        }

        #endregion Constructor



        #region Public Properties

        /// <summary>
        /// Gets or sets the view model for this page.
        /// </summary>
        public VM ViewModel
        {
            get => _ViewModel;

            set
            {
                // if nothing has changed simply return
                if (_ViewModel == value)
                {
                    return;
                }

                // Update the mViewModel
                _ViewModel = value;

                // Update the DataContext
                DataContext = _ViewModel;
            }
        }

        #endregion Public Properties

        #region Private members

        /// <summary>
        /// The mViewModel associated with this page
        /// </summary>
        private VM _ViewModel { get; set; }

        #endregion Private members
    }
}