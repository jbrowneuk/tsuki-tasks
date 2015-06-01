namespace TodoList
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Markup;
    using System.Windows.Threading;

    using TodoList.Model;
    using TodoList.UI.Views;
    using TodoList.ViewModel;

    /// <summary>
    ///     The app.
    /// </summary>
    public partial class App
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes static members of the <see cref="App" /> class.
        /// </summary>
        static App()
        {
            // Ensure the current culture passed into bindings is the OS culture.
            // By default, WPF uses en-US as the culture, regardless of the system settings.
            FrameworkElement.LanguageProperty.OverrideMetadata(
                typeof(FrameworkElement), 
                new FrameworkPropertyMetadata(XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag)));
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="App" /> class.
        /// </summary>
        public App()
        {
            DispatcherUnhandledException += this.ApplicationExceptionHandler;
            Startup += this.OnStartup;
            Exit += this.OnExit;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the item list.
        /// </summary>
        internal ItemLoader ItemList { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Controls the display of the crash handler when a UI-level exception is thrown.
        /// </summary>
        /// <param name="sender">
        /// Sending object.
        /// </param>
        /// <param name="e">
        /// Any event arguments.
        /// </param>
        private void ApplicationExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            var owner = Current.MainWindow;

            if (owner is CrashHandler)
            {
                owner = null;
            }

            var dlg = new CrashHandler
                          {
                              Owner = owner, 
                              DataContext = new CrashHandlerDialogViewModel(e.Exception)
                          };
            dlg.Show();

            e.Handled = true;
        }

        /// <summary>
        /// The on startup event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnStartup(object sender, StartupEventArgs e)
        {
            this.ItemList = new ItemLoader();

            var mainWindow = new MainWindow();
            var mainWindowViewModel = new MainWindowViewModel(mainWindow);
            mainWindow.DataContext = mainWindowViewModel;
            mainWindow.Show();

            Startup -= this.OnStartup;
        }

        /// <summary>
        /// The on exit event.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnExit(object sender, ExitEventArgs e)
        {
            this.ItemList.SaveItems();
        }

        #endregion
    }
}