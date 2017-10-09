namespace Fasetto.Word.Core
{
    using System.Security;

    /// <summary>
    /// An interface for a class that can provide (and manipulate) secure password string <see cref="SecureString"/>
    /// </summary>
    public interface IHavePassword
    {
        #region Public Properties

        /// <summary>
        /// The secure password to work with.
        /// </summary>
        SecureString SecurePassword { get; }

        #endregion Public Properties
    }
}