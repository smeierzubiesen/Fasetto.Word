namespace Fasetto.Word.Core
{
    /// <summary>
    /// The application state as a viewmodel
    /// </summary>
    public class ApplicationViewModel : BasePopupMenuViewModel
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets the current page of the App
        /// </summary>
        public ApplicationPage CurrentPage { get; private set; } = ApplicationPage.Login;

        /// <summary>
        /// Indicates wether we can see the sidemenu or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;

        #endregion Public Properties



        #region Public Methods

        /// <summary>
        /// Navigates to the specified <see cref="ApplicationPage"/>
        /// </summary>
        /// <param name="page">The page to navigate to</param>
        public void GoToPage(ApplicationPage page)
        {
            // Set the current page
            CurrentPage = page;

            //Show sidemenu or not?
            SideMenuVisible = page == ApplicationPage.Chat;
        }

        #endregion Public Methods
    }
}