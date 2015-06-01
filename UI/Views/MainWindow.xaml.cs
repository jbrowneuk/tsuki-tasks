namespace TodoList.UI.Views
{
    using TodoList.ViewModel;

    /// <summary>
    ///     The main window.
    /// </summary>
    public partial class MainWindow : IUiWrapper
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Public Methods and Operators

        /// <inheritdoc />
        public void OpenAboutWindow()
        {
            new AboutWindow { Owner = this }.ShowDialog();
        }

        #endregion
    }
}