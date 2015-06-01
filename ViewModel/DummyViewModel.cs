namespace TodoList.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Reflection;
    using System.Windows.Input;

    using TodoList.Model;

    /// <summary>
    /// The dummy view model.
    /// </summary>
    internal class DummyViewModel : ViewModelBase
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="DummyViewModel" /> class.
        /// </summary>
        public DummyViewModel()
        {
            if (!IsInDesignMode())
            {
                return;
            }

            Items = new ObservableCollection<TodoTask>();
            this.CurrentItem = new TodoTask(
                "Selected task", false, DateTime.Now, "This is a description for the selected item.");
            this.Items.Add(this.CurrentItem);
            this.Items.Add(new TodoTask("Unselected task", false, DateTime.Now));
            this.Items.Add(new TodoTask("Done task", true, DateTime.Now));
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the add command.
        /// </summary>
        public ICommand AddCommand { get; private set; }

        /// <summary>
        ///     Gets or sets the current item.
        /// </summary>
        public TodoTask CurrentItem { get; set; }

        /// <summary>
        ///     Gets a value indicating whether there is a current item.
        /// </summary>
        public bool HasCurrentItem
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        ///     Gets the items.
        /// </summary>
        public ObservableCollection<TodoTask> Items { get; private set; }

        /// <summary>
        ///     Gets the remove command.
        /// </summary>
        public ICommand RemoveCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        ///     Checks if is in design mode.
        /// </summary>
        /// <returns>
        ///     True if in design mode.
        /// </returns>
        private static bool IsInDesignMode()
        {
            return Assembly.GetExecutingAssembly().Location.Contains("VisualStudio");
        }

        #endregion
    }
}