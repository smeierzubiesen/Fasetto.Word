namespace Fasetto.Word
{
    using System;
    using System.Windows;

    /// <summary>
    /// A base attached property to replace the M$ way to do this
    /// </summary>
    /// <typeparam name="TParent">The parent class to the attached property</typeparam>
    /// <typeparam name="TProperty">The type of this attached property</typeparam>
    public abstract class BaseAttachedProperty<TParent, TProperty>
        where TParent : BaseAttachedProperty<TParent, TProperty>, new()
    {
        #region Public Properties

        /// <summary>
        /// Gets the singleton instance of the parent class
        /// </summary>
        public static TParent Instance { get; private set; } = new TParent();

        #endregion Public Properties

        #region Attached Property Definitions

        /// <summary>
        /// The attached property for this class
        /// </summary>
        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached("Value", typeof(TProperty), typeof(BaseAttachedProperty<TParent, TProperty>), new PropertyMetadata(new PropertyChangedCallback(OnValuePropertyChanged)));

        /// <summary>
        /// The callback event when the <see cref="ValueProperty"/> is changed
        /// </summary>
        /// <param name="d">The UI element that had its property changed</param>
        /// <param name="e">The arguments for the event</param>
        private static void OnValuePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // Call the parent function
            Instance.OnValueChanged(d, e);

            // Call event listeners
            Instance.ValueChanged(d, e);
        }

        /// <summary>
        /// Gets the attached property value
        /// </summary>
        /// <param name="d">The element to get the property from</param>
        /// <returns>The value of the attached property</returns>
        public static TProperty GetValue(DependencyObject d) => (TProperty)d.GetValue(ValueProperty);

        /// <summary>
        /// Sets the attached property
        /// </summary>
        /// <param name="d">The element to set the property for</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetValue(DependencyObject d, TProperty value) => d.SetValue(ValueProperty, value);

        #endregion Attached Property Definitions

        #region Public events

        /// <summary>
        /// This fires when the value changes
        /// </summary>
        public event Action<DependencyObject, DependencyPropertyChangedEventArgs> ValueChanged = (sender, e) => { };

        #endregion Public events

        #region Event Methods

        /// <summary>
        /// The method that is called when any attached property of this type is changed
        /// </summary>
        /// <param name="sender">The UI element that this property was changed for</param>
        /// <param name="e">The arguments for this event</param>
        public virtual void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
        }

        #endregion Event Methods
    }
}