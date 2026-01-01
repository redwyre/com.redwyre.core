using UnityEditor.UIElements;

namespace redwyre.Core.Editor.MVVM
{
    /// <summary>
    /// A dummy converter for SystemObject. This is just to please UIToolKit, 
    /// because the SystemObject is never serialized it will never actually be used.
    /// </summary>
    class SystemObjectConverter : UxmlAttributeConverter<System.Object>
    {
        public override object FromString(string value) => new object();

        public override string ToString(object value) => "System.Object";
    }
}
