namespace TodoList.UI.Views
{
    using System.Windows;

    /// <summary>
    ///     Interaction logic for the about window.
    /// </summary>
    public partial class AboutWindow
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindow"/> class.
        /// </summary>
        public AboutWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on close clicked event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void OnCloseClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}