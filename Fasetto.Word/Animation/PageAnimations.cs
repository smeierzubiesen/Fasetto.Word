namespace Fasetto.Word
{
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;

    using Fasetto.Word.Animation;

    /// <summary>
    /// Helpers to animate pages in specific ways
    /// </summary>
    public static class PageAnimations
    {
        /// <summary>
        /// TODO The slide and fade in from right.
        /// </summary>
        /// <param name="page">
        /// TODO The page.
        /// </param>
        /// <param name="seconds">
        /// TODO The seconds.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task SlideAndFadeInFromRight(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.AddSlideFromRight(seconds, page.WindowWidth);
            sb.AddFadeIn(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }

        /// <summary>
        /// TODO The slide and fade in from right.
        /// </summary>
        /// <param name="page">
        /// TODO The page.
        /// </param>
        /// <param name="seconds">
        /// TODO The seconds.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public static async Task SlideAndFadeOutToLeft(this Page page, float seconds)
        {
            var sb = new Storyboard();
            sb.AddSlideToLeft(seconds, page.WindowWidth);
            sb.AddFadeOut(seconds);
            sb.Begin(page);
            page.Visibility = Visibility.Visible;
            await Task.Delay((int)seconds * 1000);
        }
    }
}

