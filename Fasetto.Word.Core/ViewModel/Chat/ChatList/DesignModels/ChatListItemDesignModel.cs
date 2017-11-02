namespace Fasetto.Word.Core
{
    /// <inheritdoc/>
    /// <summary>
    /// The design-time data for a <see cref="T:Fasetto.Word.Core.ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance (singleton) of the design model
        /// </summary>
        public static ChatListItemDesignModel Instance => new ChatListItemDesignModel();

        #endregion Singleton



        #region Public Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public ChatListItemDesignModel()
        {
            Initials = "SM";
            Name = "Sebastian Meier zu Biesen";
            Message = "some very long message with some extra words to see how TextTrimming behaves";
            ProfilePictureRgb = "3099c5";
        }

        #endregion Public Constructors
    }
}