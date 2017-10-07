using System.Collections.Generic;

namespace Fasetto.Word
{
    /// <summary>
    /// A ViewModel for the overview chatlist
    /// </summary>
    public class ChatListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// A single instance of the design model (to fill in data during design time)
        /// </summary>
        public static ChatListViewModel Instance => new ChatListDesignModel();

        #endregion Public Properties



        #region Public Properties

        /// <summary>
        /// The chat list items
        /// </summary>
        public List<ChatListItemViewModel> Items { get; set; }

        #endregion Public Properties
    }
}