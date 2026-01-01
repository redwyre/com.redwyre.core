using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Properties;
using UnityEngine.UIElements;

#nullable enable

namespace redwyre.Core.MVVM
{
    /// <summary>
    /// Base class for ViewModels that implements INotifyPropertyChanged.
    /// </summary>
    public class ObservableObject : INotifyBindablePropertyChanged
    {
        /// <summary>
        /// A way to allow binding to the data source itself.
        /// </summary>
        [CreateProperty] public System.Object Self => this;

        public event EventHandler<BindablePropertyChangedEventArgs>? propertyChanged;

        public void SetProperty<T>(ref T value, T newValue, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(value, newValue))
                return;

            value = newValue;

            Notify(propertyName);
        }

        public void Notify([CallerMemberName] string propertyName = "")
        {
            propertyChanged?.Invoke(this, new BindablePropertyChangedEventArgs(propertyName));
        }
    }
}
