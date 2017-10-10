using System;
using System.Windows;

namespace Fasetto.Word
{
    /// <inheritdoc />
    /// <summary>
    /// A base class to run any animation method when a bool is set to true
    /// and a reverse animation set to false
    /// </summary>
    /// <typeparam name="TParent">Parent class to inherit from</typeparam>
    public abstract class AnimateBaseProperty<TParent> : BaseAttachedProperty<TParent, bool>
        where TParent : BaseAttachedProperty<TParent, bool>, new()
    {
        /// <summary>
        /// Check whether this is the first time property has been loaded.
        /// </summary>
        public bool FirstLoad { get; set; } = true;

        /// <inheritdoc />
        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="value"></param>
        public override void OnValueUpdated(DependencyObject sender, object value)
        {
            //Get the framework element
            if (!(sender is FrameworkElement element))
                return;

            // Don't fire if the value doesn't change
            if (sender.GetValue(ValueProperty) == value && !FirstLoad)
                return;

            // On first load ...
            if (FirstLoad)
            {
                // Create a single self-unhookable event
                // for the elements loaded event
                RoutedEventHandler onLoaded = null;
                onLoaded = (ss, ee) =>
                {
                    // Unhook ourselves
                    element.Loaded -= onLoaded;

                    // Do the desired animation
                    DoAnimationAsync(element, (bool)value);

                    // No longer in first load
                    FirstLoad = false;
                };
                // Hook into the Loaded event of the element
                element.Loaded += onLoaded;
            }
            else
            {
                // Do the desired animation
                DoAnimationAsync(element, (bool)value);
            }
        }

        /// <summary>
        /// The animation method that is fired when the value changes
        /// </summary>
        /// <param name="element">The Framework element</param>
        /// <param name="value">The value</param>
        protected virtual void DoAnimationAsync(FrameworkElement element, bool value)
        {
        }
    }

    /// <summary>
    /// Animates a framework element sliding it in from the left on show
    /// and sliding it out to the left on hide
    /// </summary>
    public class AnimateSlideInFromLeftProperty : AnimateBaseProperty<AnimateSlideInFromLeftProperty>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        protected override async void DoAnimationAsync(FrameworkElement element, bool value)
        {
            if (value)
            {
                await element.SlideAndFadeInFromLeftAsync(0.3f);
            }
            else
            {
                await element.SlideAndFadeOutToLeftAsync(0.3f);
            }
        }
    }

}
