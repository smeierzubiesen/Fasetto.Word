namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModel for each chat list item in the overview chatlist
    /// </summary>
    public class ChatListItemViewModel : BasePopupMenuViewModel
    {
        #region Public Properties

        /// <summary>
        /// The initials to show for the profile picture.
        /// </summary>
        public string Initials { get; set; }

        /// <summary>
        /// True if this item is selected
        /// </summary>
        public bool IsSelected { get; set; }

        /// <summary>
        /// The latest message from this chat.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The display name for this chat list item.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Indicates whether there is a new message in this chat
        /// </summary>
        public bool NewContentAvailable { get; set; }

        /// <summary>
        /// The RGB values (in hex) to assign to this profile picture background
        /// </summary>
        public string ProfilePictureRgb { get; set; }
    }

    #endregion Public Properties
}