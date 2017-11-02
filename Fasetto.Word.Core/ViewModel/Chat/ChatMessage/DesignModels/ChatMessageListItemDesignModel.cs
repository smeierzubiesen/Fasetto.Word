using System;

namespace Fasetto.Word.Core
{
    /// <inheritdoc/>
    /// <summary>
    /// The design-time data for a <see cref="T:Fasetto.Word.Core.ChatMessageListItemViewModel"/>
    /// </summary>
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance (singleton) of the design model
        /// </summary>
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();

        #endregion Singleton



        #region Public Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public ChatMessageListItemDesignModel()
        {
            Initials = "SM";
            SenderName = "Sebastian Meier zu Biesen";
            Message = "This is an example of a chat message sent by the user, with some extra long text for text trimming behavior.\r\nIt also uses a CRLF to show if this renders correctly...";
            ProfilePictureRgb = "3099c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }

        #endregion Public Constructors
    }
}