using System;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// A ViewModel for each chat message item in the chat window/page
    /// </summary>
    public class ChatMessageListItemViewModel : BasePopupMenuViewModel
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
        /// A flag indicating whether the message was read by the recipient according to <see cref="MessageReadTime"/>.
        /// </summary>
        public bool MessageRead => MessageReadTime > DateTimeOffset.MinValue;

        /// <summary>
        /// The time the message was read by the recipient or <see cref="DateTimeOffset.MinValue"/>
        /// if not read.
        /// </summary>
        public DateTimeOffset MessageReadTime { get; set; }

        /// <summary>
        /// The time the message was sent.
        /// </summary>
        public DateTimeOffset MessageSentTime { get; set; }

        /// <summary>
        /// The RGB values (in hex) to assign to this profile picture background
        /// </summary>
        public string ProfilePictureRgb { get; set; }

        /// <summary>
        /// The display name for the sender of a message
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// True if this message is sent by the user of the app.
        /// </summary>
        public bool SentByMe { get; set; }
    }

    #endregion Public Properties
}