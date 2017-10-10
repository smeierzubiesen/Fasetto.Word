using Fasetto.Word.Core;

namespace Fasetto.Word
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Public Constructors

        /// <summary>
        /// The <see cref="MainWindow"/> Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new WindowViewModel(this);
        }

        #endregion Public Constructors
    }
}