// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StoryBoardHelpers.cs" company="mitos[dash]kalandiel">
//   2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
//   Animation helpers for <see cref="Storyboard" />
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Fasetto.Word.Animation
{
    using System;
    using System.Windows;
    using System.Windows.Media.Animation;

    /// <summary>
    /// Animation helpers for <see cref="Storyboard"/>
    /// </summary>
    public static class StoryBoardHelpers
    {
        /// <summary>
        /// Adds a slide effect (from right) to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// How long the slide effect lasts
        /// </param>
        /// <param name="offset">
        /// The distance to the right to start from
        /// </param>
        /// <param name="decelerationRatio">
        /// The rate of deceleration.
        /// </param>
        public static void AddSlideFromRight(
            this Storyboard storyboard,
            float seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
                                     {
                                         Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                                         From = new Thickness(offset, 0, -offset, 0),
                                         To = new Thickness(0),
                                         DecelerationRatio = decelerationRatio
                                     };
            
            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            
            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide effect (from left) to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// How long the slide effect lasts
        /// </param>
        /// <param name="offset">
        /// The distance to the right to start from
        /// </param>
        /// <param name="decelerationRatio">
        /// The rate of deceleration.
        /// </param>
        public static void AddSlideFromLeft(
            this Storyboard storyboard,
            float seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
                                {
                                    Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                                    From = new Thickness(-offset, 0, offset, 0),
                                    To = new Thickness(0),
                                    DecelerationRatio = decelerationRatio
                                };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide effect (to right) to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// How long the slide effect lasts
        /// </param>
        /// <param name="offset">
        /// The distance to the right to start from
        /// </param>
        /// <param name="decelerationRatio">
        /// The rate of deceleration.
        /// </param>
        public static void AddSlideToRight(
            this Storyboard storyboard,
            float seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
                                {
                                    Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                                    From = new Thickness(0),
                                    To = new Thickness(offset, 0, -offset, 0),
                                    DecelerationRatio = decelerationRatio
                                };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a slide effect (to left) to the <see cref="Storyboard"/>.
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// How long the slide effect lasts
        /// </param>
        /// <param name="offset">
        /// The distance to the right to start from
        /// </param>
        /// <param name="decelerationRatio">
        /// The rate of deceleration.
        /// </param>
        public static void AddSlideToLeft(
            this Storyboard storyboard,
            float seconds,
            double offset,
            float decelerationRatio = 0.9f)
        {
            // Create the margin animate from right
            var animation = new ThicknessAnimation
                                {
                                    Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                                    From = new Thickness(0),
                                    To = new Thickness(-offset, 0, offset, 0),
                                    DecelerationRatio = decelerationRatio
                                };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade in animation
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// Amount of seconds it takes to fade in
        /// </param>
        public static void AddFadeIn(
            this Storyboard storyboard,
            float seconds)
        {
            // Create the margin animate from right
            var animation =
                new DoubleAnimation { Duration = new Duration(TimeSpan.FromSeconds(seconds)), From = 0, To = 1 };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Adds a fade out animation
        /// </summary>
        /// <param name="storyboard">
        /// The storyboard to add the animation to.
        /// </param>
        /// <param name="seconds">
        /// Amount of seconds it takes to fade in
        /// </param>
        public static void AddFadeOut(
            this Storyboard storyboard,
            float seconds)
        {
            // Create the margin animate from right
            var animation =
                new DoubleAnimation { Duration = new Duration(TimeSpan.FromSeconds(seconds)), From = 1, To = 0 };

            // Set the target property name
            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));

            // Add the animation to the storyboard
            storyboard.Children.Add(animation);
        }
    }
}
