using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModel for the message list in a chat
    /// </summary>
    public class ChatMessageListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The chat list items
        /// </summary>
        public List<ChatMessageListItemViewModel> Items { get; set; }

        #endregion Public Properties
    }
}