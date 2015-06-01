namespace TodoList.Model
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The to do task.
    /// </summary>
    public class TodoTask : INotifyPropertyChanged
    {
        #region Static Fields

        /// <summary>
        /// The identifier.
        /// </summary>
        private static int identifier;

        #endregion

        #region Fields

        /// <summary>
        /// Whether done.
        /// </summary>
        private bool done;

        /// <summary>
        /// The last modified time.
        /// </summary>
        private DateTime lastModifiedTime;

        /// <summary>
        /// The notes.
        /// </summary>
        private string notes;

        /// <summary>
        /// The title.
        /// </summary>
        private string title;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoTask"/> class.
        /// </summary>
        public TodoTask()
        {
            identifier++;
            this.Title = string.Format(@"Task {0}", identifier);
            this.LastModifiedTime = DateTime.Now;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TodoTask"/> class.
        /// </summary>
        /// <param name="taskName">
        /// The task name.
        /// </param>
        /// <param name="isDone">
        /// The is done.
        /// </param>
        /// <param name="lastModifiedTime">
        /// The last modified time.
        /// </param>
        /// <param name="notes">
        /// The notes.
        /// </param>
        public TodoTask(string taskName, bool isDone, DateTime lastModifiedTime, string notes = "")
        {
            this.title = taskName;
            this.done = isDone;
            this.notes = notes;
            this.lastModifiedTime = lastModifiedTime;
        }

        #endregion

        #region Public Events

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether done.
        /// </summary>
        public bool Done
        {
            get
            {
                return this.done;
            }

            set
            {
                if (this.done == value)
                {
                    return;
                }

                this.done = value;
                this.OnPropertyChanged();
                this.LastModifiedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the last modified time.
        /// </summary>
        public DateTime LastModifiedTime
        {
            get
            {
                return this.lastModifiedTime;
            }

            set
            {
                if (value.Equals(this.lastModifiedTime))
                {
                    return;
                }

                this.lastModifiedTime = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        /// Gets or sets the notes.
        /// </summary>
        public string Notes
        {
            get
            {
                return this.notes;
            }

            set
            {
                if (this.notes == value)
                {
                    return;
                }

                this.notes = value;
                this.OnPropertyChanged();
                this.LastModifiedTime = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (this.title == value)
                {
                    return;
                }

                this.title = value;
                this.OnPropertyChanged();
                this.LastModifiedTime = DateTime.Now;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed event handler.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion
    }
}