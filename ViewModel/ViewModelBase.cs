namespace TodoList.ViewModel
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// The view model base.
    /// </summary>
    internal abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Public Events

        /// <summary>
        /// The property changed event.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// The on property changed event handler.
        /// </summary>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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