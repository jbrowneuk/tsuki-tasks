namespace TodoList.ViewModel
{
    using System;
    using System.Diagnostics;
    using System.Reflection;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;

    /// <summary>
    /// The crash handler dialog view model.
    /// </summary>
    internal class CrashHandlerDialogViewModel : ViewModelBase
    {
        #region Constants

        /// <summary>
        /// The report help uri.
        /// </summary>
        private const string ReportHelpUri = @"https://jbrowne.me.uk/dev/faq.php?topic=reporting";

        /// <summary>
        /// The report page uri.
        /// </summary>
        private const string ReportPageUri = @"https://jbrowne.me.uk/dev/submit.php";

        #endregion

        #region Fields

        /// <summary>
        /// The exception.
        /// </summary>
        private readonly Exception exception;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="CrashHandlerDialogViewModel"/> class.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        public CrashHandlerDialogViewModel(Exception e)
        {
            this.exception = e;
            this.CloseWindowCommand = new DelegateCommand(w => (w as Window).Close());
            this.ReportButtonCommand = new DelegateCommand(o => Process.Start(ReportPageUri));
            this.ReportHelpCommand = new DelegateCommand(o => Process.Start(ReportHelpUri));
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the close window command.
        /// </summary>
        public ICommand CloseWindowCommand { get; private set; }

        /// <summary>
        /// Gets the developer info.
        /// </summary>
        public string DeveloperInfo
        {
            get
            {
                return this.GenerateDeveloperTabText();
            }
        }

        /// <summary>
        /// Gets the exception message.
        /// </summary>
        public string ExceptionMessage
        {
            get
            {
                return this.exception.Message;
            }
        }

        /// <summary>
        /// Gets the exception type.
        /// </summary>
        public string ExceptionType
        {
            get
            {
                return this.exception.GetType().Name;
            }
        }

        /// <summary>
        /// Gets the report button command.
        /// </summary>
        public ICommand ReportButtonCommand { get; private set; }

        /// <summary>
        /// Gets the report help command.
        /// </summary>
        public ICommand ReportHelpCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// The generate developer tab text.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string GenerateDeveloperTabText()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(@"{0}: {1}", this.exception.GetType(), this.exception.Message);
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat(
                @"{0} ({1})", Environment.OSVersion, Environment.Is64BitOperatingSystem ? "64 bit" : "32 bit");
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat(@"CLR {0}", Environment.Version);
            stringBuilder.AppendLine();
            stringBuilder.AppendFormat(@"Build {0}", Assembly.GetExecutingAssembly().GetName().Version);
            stringBuilder.AppendLine();
            stringBuilder.AppendLine();
            stringBuilder.Append(this.exception.StackTrace);

            Exception innerException = this.exception.InnerException;
            while (innerException != null)
            {
                stringBuilder.AppendLine();
                stringBuilder.AppendLine("--- Inner exception ---");
                stringBuilder.Append(innerException.StackTrace);

                innerException = innerException.InnerException;
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}