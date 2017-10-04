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
                    var sb = new Storyboard();
                    var slideAnimation = new ThicknessAnimation
                    {
                        Duration = new Duration(TimeSpan.FromSeconds(this.SlideSeconds)),
                        From = new Thickness(this.WindowWidth, 0, -this.WindowWidth, 0),
                        To = new Thickness(0),
                        DecelerationRatio = 0.9f
                    };
                    Storyboard.SetTargetProperty(slideAnimation, new PropertyPath("Margin"));
                    sb.Children.Add(slideAnimation);
                    sb.Begin(this);
                    this.Visibility = Visibility.Visible;
                    await Task.Delay((int)this.SlideSeconds * 1000);
                    break;
                default:
                    break;
            }
        }

        #endregion

    }
}
