namespace Fasetto.Word
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Helpers to animate framework elements in specific ways
    /// </summary>
    public static class FrameworkElementAnimations
    {
        #region Public Methods

        /// <summary>
        /// Slide and fade in from left.
        /// </summary>
        /// <param name="element">The element to animate.</param>
        /// <param name="seconds">The seconds it takes to animate.</param>
        /// <param name="keepMargin">
        /// Optional: Wether to keep the element at the same width during animation
        /// </param>
        /// <param name="width">Optional: Pass in a width of the element to slide and fade in</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slide and fade in from right.
        /// </summary>
        /// <param name="element">The element to animate.</param>
        /// <param name="seconds">The seconds it takes to animate.</param>
        /// <param name="keepMargin">
        /// Optional: Wether to keep the element at the same width during animation
        /// </param>
        /// <param name="width">Optional: Pass in a width of the element to slide and fade in</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            sb.AddFadeIn(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slide and fade out to Left
        /// </summary>
        /// <param name="element">The element to animate.</param>
        /// <param name="seconds">The seconds it takes to animate.</param>
        /// <param name="keepMargin">
        /// Optional: Wether to keep the element at the same width during animation
        /// </param>
        /// <param name="width">Optional: Pass in a width of the element to slide and fade in</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// Slide and fade out to right.
        /// </summary>
        /// <param name="element">The element to animate.</param>
        /// <param name="seconds">The seconds it takes to animate.</param>
        /// <param name="keepMargin">
        /// Optional: Wether to keep the element at the same width during animation
        /// </param>
        /// <param name="width">Optional: Pass in a width of the element to slide and fade in</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds, bool keepMargin = true, int width = 0)
        {
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, width == 0 ? element.ActualWidth : width, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        #endregion Public Methods
    }
}