namespace TodoList.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Xml.Serialization;

    /// <summary>
    ///     The item loader.
    /// </summary>
    internal class ItemLoader
    {
        #region Constants

        /// <summary>
        ///     The file name.
        /// </summary>
        private const string FileName = @"items.xml";

        #endregion

        #region Fields

        /// <summary>
        ///     The serializer.
        /// </summary>
        private readonly XmlSerializer serializer;

        /// <summary>
        ///     The file name cache.
        /// </summary>
        private string fileNameCache;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="ItemLoader" /> class.
        /// </summary>
        public ItemLoader()
        {
            this.serializer = new XmlSerializer(typeof(ObservableCollection<TodoTask>));
            this.LoadItems();
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets the items.
        /// </summary>
        public ObservableCollection<TodoTask> Items { get; private set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     Call to save items.
        /// </summary>
        public void SaveItems()
        {
            using (var streamWriter = new StreamWriter(this.GetFullFileName(), false))
            {
                this.serializer.Serialize(streamWriter, this.Items);
            }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The get full file name.
        /// </summary>
        /// <returns>
        ///     The path as a <see cref="string" />.
        /// </returns>
        private string GetFullFileName()
        {
            if (string.IsNullOrEmpty(this.fileNameCache))
            {
                string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
                string directory = Path.Combine(appData, "Tsuki");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                this.fileNameCache = Path.Combine(directory, FileName);
            }

            return this.fileNameCache;
        }

        /// <summary>
        ///     Call to load items.
        /// </summary>
        private void LoadItems()
        {
            if (!File.Exists(this.GetFullFileName()))
            {
                this.Items = new ObservableCollection<TodoTask>();
                return;
            }

            using (var fileStream = new FileStream(this.GetFullFileName(), FileMode.Open))
            {
                try
                {
                    this.Items = (ObservableCollection<TodoTask>)this.serializer.Deserialize(fileStream);
                }
                catch (Exception)
                {
                    this.Items = new ObservableCollection<TodoTask>();
                }
            }
        }

        #endregion
    }
}