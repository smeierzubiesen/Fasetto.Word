using System.ComponentModel;
using System.Runtime.CompilerServices;
using PropertyChanged;

namespace Fasetto.Word
{
    /// <summary>
    /// A base view model that fires PropertyChanged as required
    /// </summary>
    internal class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when a child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire a <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name">The name of the changed property</param>
        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}