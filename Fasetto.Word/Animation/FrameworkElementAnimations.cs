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
        /// <param name="keepMargin">Wether to keep the element at the same width during animation</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromLeftAsync(this FrameworkElement element, float seconds, bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
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
        /// <param name="keepMargin">Wether to keep the element at the same width during animation</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeInFromRightAsync(this FrameworkElement element, float seconds, bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, element.ActualWidth, keepMargin: keepMargin);
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
        /// <param name="keepMargin">Wether to keep the element at the same width during animation</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToLeftAsync(this FrameworkElement element, float seconds, bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, element.ActualWidth, keepMargin: keepMargin);
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
        /// <param name="keepMargin">Wether to keep the element at the same width during animation</param>
        /// <returns>The <see cref="Task"/>.</returns>
        public static async Task SlideAndFadeOutToRightAsync(this FrameworkElement element, float seconds, bool keepMargin = true)
        {
            var sb = new Storyboard();
            sb.AddSlideToRight(seconds, element.ActualWidth, keepMargin: keepMargin);
            sb.AddFadeOut(seconds);
            sb.Begin(element);
            element.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        #endregion Public Methods
    }
}