using System.Collections.Generic;
using System.Windows.Input;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModel for the message list in a chat
    /// </summary>
    public class ChatMessageListViewModel : BasePopupMenuViewModel
    {
        #region Public Properties

        /// <summary>
        /// The viewmodel for the attachment menu
        /// </summary>
        public ChatAttachmentPopupMenuViewModel AttachmentMenu { get; set; }

        /// <summary>
        /// True to indicate that the attachment menu is visible
        /// </summary>
        public bool AttachmentMenuVisible { get; set; }

        /// <summary>
        /// The chat list items
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        #endregion Public Properties

        #region Commands

        /// <summary>
        /// The command for when the Attachment Button is clicked
        /// </summary>
        public ICommand AttachmentButtonCommand { get; set; }

        #endregion Commands

        #region Constructor

        /// <summary>
        /// The ChatMessageListViewModel constructor
        /// </summary>
        public ChatMessageListViewModel()
        {
            //Create commands
            AttachmentButtonCommand = new RelayCommand(AttachmentButton);

            //Make a default menu
            AttachmentMenu = new ChatAttachmentPopupMenuViewModel();
        }

        #endregion Constructor

        #region Command Methods

        /// <summary>
        /// When the attachement button is clicked, show/hide the attachment popup
        /// </summary>
        public void AttachmentButton()
        {
            AttachmentMenuVisible ^= true;
        }

        #endregion Command Methods
    }
}