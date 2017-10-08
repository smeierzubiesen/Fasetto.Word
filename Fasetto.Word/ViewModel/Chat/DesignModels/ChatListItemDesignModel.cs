namespace Fasetto.Word
{
    /// <inheritdoc/>
    /// <summary>
    /// The design-time data for a <see cref="T:Fasetto.Word.ChatListItemViewModel"/>
    /// </summary>
    public class ChatListItemDesignModel : ChatListItemViewModel
    {
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