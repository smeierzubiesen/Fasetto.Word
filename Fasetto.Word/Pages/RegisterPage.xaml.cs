// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RegisterPage.xaml.cs" company="mitos[dash]kalandiel">
//     2017 by AngelSix - modified by mitos[dash]kalandiel
// </copyright>
// <summary>
// Interaction logic for RegisterPage.xaml
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace Fasetto.Word
{
    using System.Security;
    using Fasetto.Word.Core;

    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : BasePage<LoginViewModel>, IHavePassword
    {
        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public RegisterPage()
        {
            InitializeComponent();
        }

        #endregion Public Constructors



        #region Public Properties

        /// <summary>
        /// The secure password for this login page
        /// </summary>
        public SecureString SecurePassword => PasswordText.SecurePassword;

        #endregion Public Properties
    }
}