// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BasePage.cs" company="mitos[dash]kalandiel">
//   2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
//   BasePage for all pages to inherit from and gain basic function
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fasetto.Word
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// BasePage for all pages to inherit from and gain basic function
    /// </summary>
    /// <typeparam name="VM">The _ViewModel Type</typeparam>
    public class BasePage<VM> : Page
        where VM : BaseViewModel, new()

    {
        #region Constructor

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Fasetto.Word.BasePage" /> class.
        /// </summary>
        public BasePage()
        {
            // If we are animating, hide the animation, for it to load properly
            if (this.PageLoadAnimation != PageAnimation.None)
            {
                this.Visibility = Visibility.Collapsed;
            }

            // Listen for the PageLoad event and hook into it.
            this.Loaded += this.BasePageLoaded;

            // Create a default view model
            this.ViewModel = new VM();
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
            get => this._ViewModel;

            set
            {
                // if nothing has changed simply return
                if (this._ViewModel == value)
                {
                    return;
                }

                // Update the _ViewModel
                this._ViewModel = value;

                // Update the DataContext
                this.DataContext = this._ViewModel;
            }
        }

        #endregion Public Properties

        #region Animation Load / Unload

        /// <summary>
        /// The animation when a page gets loaded
        /// </summary>
        /// <param name="sender">The page to be animated</param>
        /// <param name="e">Any parameters passed</param>
        private async void BasePageLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            await this.AnimateIn();
        }

        /// <summary>
        /// Animate the PageLoad
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> result
        /// </returns>
        public async Task AnimateIn()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageLoadAnimation)
            {
                case PageAnimation.SlideAndFadeInFromRight:
                    await this.SlideAndFadeInFromRight(this.SlideSeconds);
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// Animate the PageUnload
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/> result
        /// </returns>
        public async Task AnimateOut()
        {
            if (this.PageLoadAnimation == PageAnimation.None)
            {
                return;
            }

            switch (this.PageUnloadAnimation)
            {
                case PageAnimation.SlideAndFadeOutToLeft:
                    await this.SlideAndFadeOutToLeft(this.SlideSeconds);
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