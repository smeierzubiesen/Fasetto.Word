using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModel for the overview chatlist
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The chat list items
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }

        #endregion Public Properties
    }
}