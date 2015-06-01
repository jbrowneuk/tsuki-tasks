namespace TodoList.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows;
    using System.Windows.Input;

    using TodoList.Model;

    /// <summary>
    ///     The main window view model.
    /// </summary>
    internal class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        /// <summary>
        ///     The non unit-testable user interface code wrapper.
        /// </summary>
        private readonly IUiWrapper uiWrapper;

        /// <summary>
        ///     The current item.
        /// </summary>
        private TodoTask currentItem;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowViewModel"/> class.
        /// </summary>
        /// <param name="wrapper">
        /// The wrapper to user-interface calls.
        /// </param>
        public MainWindowViewModel(IUiWrapper wrapper)
        {
            this.uiWrapper = wrapper;
            this.AddCommand = new DelegateCommand(this.NewTask);
            this.RemoveCommand = new DelegateCommand(this.RemoveTask);
            this.InfoCommand = new DelegateCommand(o => this.uiWrapper.OpenAboutWindow());
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
        public TodoTask CurrentItem
        {
            get
            {
                return this.currentItem;
            }

            set
            {
                if (value != null && value.Equals(this.currentItem))
                {
                    return;
                }

                this.currentItem = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     Gets a value indicating whether there is a current item.
        /// </summary>
        public bool HasCurrentItem
        {
            get
            {
                return this.CurrentItem != null;
            }
        }

        /// <summary>
        ///     Gets the info command.
        /// </summary>
        public ICommand InfoCommand { get; private set; }

        /// <summary>
        ///     Gets the items.
        /// </summary>
        public ObservableCollection<TodoTask> Items
        {
            get
            {
                return ((App)Application.Current).ItemList.Items;
            }
        }

        /// <summary>
        ///     Gets the remove command.
        /// </summary>
        public ICommand RemoveCommand { get; private set; }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new task.
        /// </summary>
        /// <param name="unused">
        /// Not used.
        /// </param>
        private void NewTask(object unused)
        {
            this.CurrentItem = new TodoTask();
            this.Items.Add(this.CurrentItem);
        }

        /// <summary>
        /// Removes the current task.
        /// </summary>
        /// <param name="listBoxItem">
        /// <see cref="TodoTask"/> to be removed. Leave null to delete the current item.
        /// </param>
        private void RemoveTask(object listBoxItem)
        {
            if (this.CurrentItem == null && listBoxItem == null)
            {
                return;
            }

            var item = listBoxItem as TodoTask;
            TodoTask task = item ?? this.CurrentItem;

            this.Items.Remove(task);

            if (task == this.CurrentItem)
            {
                this.CurrentItem = null;
            }
        }

        #endregion
    }
}