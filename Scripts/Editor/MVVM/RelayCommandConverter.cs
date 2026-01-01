using UnityEditor.UIElements;
using redwyre.Core.MVVM;

namespace redwyre.Core.Editor.MVVM
{
    /// <summary>
    /// A dummy converter for RelayCommand. This is just to please UIToolKit, 
    /// because the RelayCommand is never serialized it will never actually be used.
    /// </summary>
    public class RelayCommandConverter : UxmlAttributeConverter<RelayCommand>
    {
        public override RelayCommand FromString(string value) => new RelayCommand((parameter) => { });

        public override string ToString(RelayCommand value) => "RelayCommand";
    }
}
