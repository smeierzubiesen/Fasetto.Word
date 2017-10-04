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
    using System;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

    /// <summary>
    /// BasePage for all pages to inherit from and gain basic function
    /// </summary>
    public class BasePage : Page
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
        }

        #endregion

        #region Public Properties
        
        /// <summary>
        /// Gets or sets how long the slide animation lasts
        /// </summary>
        public float SlideSeconds { get; set; } = 0.8f;
        
        /// <summary>
        /// Gets or sets the page load animation.
        /// </summary>
        public PageAnimation PageLoadAnimation { get; set; } = PageAnimation.SlideAndFadeInFromRight;

        /// <summary>
        /// Gets or sets the page unload animation.
        /// </summary>
        public PageAnimation PageUnloadAnimation { get; set; } = PageAnimation.SlideAndFadeOutToLeft;

        #endregion

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

        #endregion

    }
}
