using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fasetto.Word.Core
{
    /// <summary>
    /// The application state as a viewmodel
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        /// <summary>
        /// Gets or sets the current page of the App
        /// </summary>
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        /// <summary>
        /// Indicates wether we can see the sidemenu or not
        /// </summary>
        public bool SideMenuVisible { get; set; } = false;
    }
}
