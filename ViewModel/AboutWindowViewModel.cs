using System.Diagnostics;
using System.Windows.Input;

namespace TodoList.ViewModel
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows;

    /// <summary>
    ///     The about window view model.
    /// </summary>
    internal class AboutWindowViewModel
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutWindowViewModel"/> class.
        /// </summary>
        public AboutWindowViewModel()
        {
            this.HyperlinkResponderCommand = new DelegateCommand(o => Process.Start((string)o));
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the human readable version.
        /// </summary>
        public string HumanReadableVersion
        {
            get
            {
                return this.ParseAssemblyVersion();
            }
        }

        /// <summary>
        ///     Gets the item count.
        /// </summary>
        public int ItemCount
        {
            get
            {
                return ((App)Application.Current).ItemList.Items.Count;
            }
        }

        /// <summary>
        ///     Gets the item left count.
        /// </summary>
        public int ItemLeftCount
        {
            get
            {
                return ((App)Application.Current).ItemList.Items.Count(x => !x.Done);
            }
        }

        /// <summary>
        ///     Gets a command that is called when the hyperlink is clicked.
        /// </summary>
        public ICommand HyperlinkResponderCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     The parsed assembly version.
        /// </summary>
        /// <returns>
        ///     The version number as parsed from the assembly information, formatted.
        /// </returns>
        private string ParseAssemblyVersion()
        {
            Version version = Assembly.GetExecutingAssembly().GetName().Version;

            DateTime buildDays = new DateTime(2000, 1, 1) + TimeSpan.FromDays(version.Build)
                                 + TimeSpan.FromSeconds(version.Revision * 2);

            return string.Format(@"{0}.{1} ({2})", version.Major, version.Minor, buildDays);
        }

        #endregion
    }
}