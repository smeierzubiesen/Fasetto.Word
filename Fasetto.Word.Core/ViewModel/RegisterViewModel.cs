namespace Fasetto.Word.Core
{
    using System.Security;
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// The View model for the register screen
    /// </summary>
    public class RegisterViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RegisterViewModel"/> class.
        /// </summary>
        public RegisterViewModel()
        {
            // Create commands
            LoginCommand = new RelayCommand(async () => await LoginAsync());
            RegisterCommand = new RelayParameterizedCommand(async (parameter) => await RegisterAsync(parameter));
        }

        #endregion Constructor



        #region Public Properties

        /// <summary>
        /// Gets or sets the email of the user
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// A flag to indicate whether the register command is running
        /// </summary>
        public bool RegisterIsRunning { get; set; }

        #endregion Public Properties

        #region Public Functions

        /// <summary>
        /// Switch to the login page
        /// </summary>
        /// <returns>The result of the registration attempt <see cref="Task"/>.</returns>
        public async Task LoginAsync()
        {
            // Toggle Side menu
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            // Goto the login page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Login);
            await Task.Delay(1);
        }

        /// <summary>
        /// Attempts to register the user.
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view.</param>
        /// <returns>The result of the register attempt <see cref="Task"/>.</returns>
        public async Task RegisterAsync(object parameter)
        {
            await RunCommandAsync(() => RegisterIsRunning, async () =>
            {
                await Task.Delay(500);
            });
        }

        #endregion Public Functions

        #region Commands

        /// <summary>
        /// Gets or sets the command to process the login
        /// </summary>
        public ICommand LoginCommand { get; set; }

        /// <summary>
        /// Gets or sets the command to forward to the register page
        /// </summary>
        public ICommand RegisterCommand { get; set; }

        #endregion Commands
    }
}