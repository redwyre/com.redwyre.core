using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine.UIElements;

#nullable enable

namespace redwyre.Core.MVVM
{
    /// <summary>
    /// Base class for ViewModels that implements INotifyPropertyChanged.
    /// </summary>
    public class ObservableObject : INotifyBindablePropertyChanged
    {
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
