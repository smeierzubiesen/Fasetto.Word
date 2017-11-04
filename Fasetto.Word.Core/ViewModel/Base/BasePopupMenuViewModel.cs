namespace Fasetto.Word.Core
{
    /// <summary>
    /// A view model any PopupMenu
    /// </summary>
    public class BasePopupMenuViewModel : BaseViewModel
    {
        #region Public Constructors

        /// <summary>
        /// Constructor
        /// </summary>
        public BasePopupMenuViewModel()
        {
            // Set default values
            // TODO: Move colors into Core
            BubbleBackground = "c1c1c1";
            ArrowAlignment = ElementHorizontalAlignment.Left;
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// The alignment of the triangle path (arrow) for the bubble
        /// </summary>
        public ElementHorizontalAlignment ArrowAlignment { get; set; }

        /// <summary>
        /// The background color of the bubble in ARGB value
        /// </summary>
        public string BubbleBackground { get; set; }

        #endregion Public Properties
    }
}