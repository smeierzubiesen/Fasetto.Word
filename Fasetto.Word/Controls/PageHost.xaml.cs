namespace Fasetto.Word
{
    using Fasetto.Word.Core;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for PageHost.xaml
    /// </summary>
    public partial class PageHost : UserControl
    {
        #region Dependency Properties

        /// <summary>
        /// Registers <see cref="CurrentPage"/> as a dependency property
        /// </summary>
        public static readonly DependencyProperty CurrentPageProperty =
            DependencyProperty.Register(nameof(CurrentPage), typeof(BasePage), typeof(PageHost), new UIPropertyMetadata(CurrentPagePropertyChanged));

        /// <summary>
        /// The current page to show in the page host
        /// </summary>
        public BasePage CurrentPage
        {
            get => (BasePage)GetValue(CurrentPageProperty);
            set => SetValue(CurrentPageProperty, value);
        }

        #endregion Dependency Properties

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageHost()
        {
            InitializeComponent();

            //At Design-time, grab the current page and show it.
            if (DesignerProperties.GetIsInDesignMode(this))
            {
                NewPage.Content = (BasePage)new ApplicationPageValueConverter().Convert(IoC.Get<ApplicationViewModel>().CurrentPage);
            }
        }

        #endregion Constructor

        #region Property Changed Events

        /// <summary>
        /// Called when the <see cref="CurrentPage"/> value has changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        [SuppressMessage("ReSharper", "PossibleNullReferenceException")]
        private static void CurrentPagePropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frames
            var oldPageFrame = (sender as PageHost).OldPage;
            var newPageFrame = (sender as PageHost).NewPage;

            // Store the current page content as the old page
            var oldPageContent = newPageFrame.Content;

            // Remove current page from newPageFrame
            newPageFrame.Content = null;

            //Move the previous page into the old frame
            oldPageFrame.Content = oldPageContent;

            //Animate out old page when the Loaded event fires
            //right after this call due to moving frames
            if (oldPageContent is BasePage oldPage)
            {
                // Animate old page away
                oldPage.AnimateOut = true;

                //Once done, free it from memory
                Task.Delay((int)(oldPage.SlideSeconds * 1000)).ContinueWith((t) =>
                  {
                      Application.Current.Dispatcher.Invoke(() => oldPageFrame.Content = null);
                  });
            }

            //Set the new page content
            newPageFrame.Content = e.NewValue;
        }

        #endregion Property Changed Events
    }
}