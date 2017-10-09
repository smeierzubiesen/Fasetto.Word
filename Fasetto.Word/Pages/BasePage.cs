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
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using Fasetto.Word.Core;

    /// <inheritdoc/>
    /// <summary>
    /// BasePage for all pages to inherit from and gain basic function
    /// </summary>
    /// <typeparam name="VM">The _ViewModel Type</typeparam>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()

    {
        #region Constructor

        /// <inheritdoc/>
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Fasetto.Word.BasePage"/> class.
        /// </summary>
        public BasePage()
        {
            // If we are animating, hide the animation, for it to load properly
            if (PageLoadAnimation != PageAnimation.None)
            {
                Visibility = Visibility.Collapsed;
            }

            // Listen for the PageLoad event and hook into it.
            Loaded += BasePage_Loaded;

            // Create a default view model
            ViewModel = new VM();
        }

        #endregion Constructor



        #region Public Properties

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
        public float SlideSeconds { get; set; } = 0.8f;

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

                // Update the _ViewModel
                _ViewModel = value;

                // Update the DataContext
                DataContext = _ViewModel;
            }
        }

        #endregion Public Properties

        #region Animation Load / Unload

        /// <summary>
        /// The animation when a page gets loaded
        /// </summary>
        /// <param name="sender">The page to be animated</param>
        /// <param name="e">Any parameters passed</param>
        private void BasePage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Task.Run(async () => await AnimateInAsync());
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
                    await this.SlideAndFadeInFromRightAsync(SlideSeconds);
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

        #region Private members

        /// <summary>
        /// The _ViewModel associated with this page
        /// </summary>
        private VM _ViewModel { get; set; }

        #endregion Private members
    }
}