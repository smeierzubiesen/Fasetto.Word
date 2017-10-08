using System.Collections.Generic;

namespace Fasetto.Word
{
    /// <inheritdoc/>
    /// <summary>
    /// The design-time data for a <see cref="T:Fasetto.Word.ChatListViewModel"/>
    /// </summary>
    public class ChatListDesignModel : ChatListViewModel
    {
        #region Public Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Initials = "SM",
                    Message = "A chat message with some added words and so forth",
                    Name = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    NewContentAvailable = true
                },
                new ChatListItemViewModel
                {
                    Initials = "VM",
                    Message = "Another chat message with some added words and so forth",
                    Name = "Veronica Meier zu Biesen",
                    ProfilePictureRgb = "00ffcc",
                    NewContentAvailable = false,
                    IsSelected = true
                },
                new ChatListItemViewModel
                {
                    Initials = "GM",
                    Message = "A third chat message with some added words and so forth",
                    Name = "Gradon Meier zu Biesen",
                    ProfilePictureRgb = "0010ff",
                    NewContentAvailable = true,
                    IsSelected = false
                },new ChatListItemViewModel
                {
                    Initials = "SM",
                    Message = "A chat message with some added words and so forth",
                    Name = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    NewContentAvailable = false,
                    IsSelected = false
                },
                new ChatListItemViewModel
                {
                    Initials = "VM",
                    Message = "Another chat message with some added words and so forth",
                    Name = "Veronica Meier zu Biesen",
                    ProfilePictureRgb = "00ffcc",
                    NewContentAvailable = false,
                    IsSelected = false
                },
                new ChatListItemViewModel
                {
                    Initials = "GM",
                    Message = "A third chat message with some added words and so forth",
                    Name = "Gradon Meier zu Biesen",
                    ProfilePictureRgb = "0010ff",
                    NewContentAvailable = false,
                    IsSelected = false
                },new ChatListItemViewModel
                {
                    Initials = "SM",
                    Message = "A chat message with some added words and so forth",
                    Name = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    NewContentAvailable = false,
                    IsSelected = false
                },
                new ChatListItemViewModel
                {
                    Initials = "VM",
                    Message = "Another chat message with some added words and so forth",
                    Name = "Veronica Meier zu Biesen",
                    ProfilePictureRgb = "00ffcc",
                    NewContentAvailable = true,
                    IsSelected = false
                },
                new ChatListItemViewModel
                {
                    Initials = "GM",
                    Message = "A third chat message with some added words and so forth",
                    Name = "Gradon Meier zu Biesen",
                    ProfilePictureRgb = "0010ff",
                    NewContentAvailable = false,
                    IsSelected = false
                }
            };
        }

        #endregion Public Constructors
    }
}