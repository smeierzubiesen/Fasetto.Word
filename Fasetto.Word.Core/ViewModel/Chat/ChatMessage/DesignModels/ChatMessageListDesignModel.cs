using System;
using System.Collections.Generic;

namespace Fasetto.Word.Core
{
    /// <inheritdoc/>
    /// <summary>
    /// The design-time data for a <see cref="T:Fasetto.Word.Core.ChatMessageListViewModel"/>
    /// </summary>
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singleton

        /// <summary>
        /// A single instance for the design model
        /// </summary>
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();

        #endregion Singleton



        #region Public Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public ChatMessageListDesignModel()
        {
            Items = new List<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {
                    Initials = "SM",
                    Message = "We need to update the old server. Ideally we would spin up a new VM with Windows 2016. Let me know if you need anything else.",
                    SenderName = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "VM",
                    Message = "Can we please ensure that a backup has been triggered from the VM host? I need some data on the new server which is hard to replicate...",
                    SenderName = "Veronica Meier zu Biesen",
                    ProfilePictureRgb = "00ffcc",
                    MessageSentTime = DateTimeOffset.Now,
                    MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "SM",
                    Message = "The backup should be available, as usual, on the host data share",
                    SenderName = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    MessageSentTime = DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1.4)),
                    SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "SM",
                    Message = "The new server is up and running. The IP is 172.24.2.5\r\nUsername: admin\r\nPassword: 'P8ssw0rd!' (without the quotation marks!!)",
                    SenderName = "Sebastian Meier zu Biesen",
                    ProfilePictureRgb = "ffcc00",
                    MessageSentTime = DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1.5)),
                    SentByMe = false
                },
                new ChatMessageListItemViewModel
                {
                    Initials = "VM",
                    Message = "That is fantastic work, thanks a bunch",
                    SenderName = "Veronica Meier zu Biesen",
                    ProfilePictureRgb = "00ffcc",
                    MessageSentTime = DateTimeOffset.Now.Subtract(TimeSpan.FromHours(1.6)),
                    SentByMe = true
                }
            };
        }

        #endregion Public Constructors
    }
}