namespace Fasetto.Word.Core
{
    using System.Threading.Tasks;
    using System.Windows.Input;

    /// <summary>
    /// The View model for the login screen
    /// </summary>
    public class LoginViewModel : BaseViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginViewModel"/> class.
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new RelayParameterizedCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
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

                //Go to chatpage
                IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Chat);
                //var email = Email;
                //var pass = (parameter as IHavePassword)?.SecurePassword.Unsecure();
            });
        }

        /// <summary>
        /// Attempts to register the user
        /// </summary>
        /// <returns>The result of the registration attempt <see cref="Task"/>.</returns>
        public async Task RegisterAsync()
        {
            // Toggle Side menu
            //IoC.Get<ApplicationViewModel>().SideMenuVisible ^= true;
            // Goto the register page
            IoC.Get<ApplicationViewModel>().GoToPage(ApplicationPage.Register);
            await Task.Delay(1);
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