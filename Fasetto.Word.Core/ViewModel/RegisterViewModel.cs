namespace Fasetto.Word.Core
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// The View model for the register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public RegisterViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
        }

        #endregion Constructor



        #region Public Properties

        /// <summary>
        /// Gets or sets the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag to indicate whether the login command is running
        /// </summary>
        public bool LoginIsRunning { get; set; }

        #endregion Public Properties

        #region Public Functions

        /// <summary>
        /// Attempts to log the user in.
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view.</param>
        /// <returns>The result of the login attempt <see cref="Task"/>.</returns>
        public async Task LoginAsync(object parameter)
        {
            await RunCommandAsync(() => LoginIsRunning, async () =>
            {
                await Task.Delay(500);
                var email = Email;
                var pass = (parameter as IHavePassword)?.SecurePassword.Unsecure();
            });
        }

        #endregion Public Functions

        #region Commands

        /// <summary>
        /// Gets or sets the command process the login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        #endregion Commands
    }
}