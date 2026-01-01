using UnityEditor;
using UnityEngine.UIElements;
using redwyre.Core.MVVM;

namespace redwyre.Core.Editor.MVVM
{
    /// <summary>
    /// SystemObjectPropertyDrawer is a custom property drawer for the 
    /// SystemObject class. Without this the field will not be displayed in 
    /// the inspector.
    /// </summary>
    [CustomPropertyDrawer(typeof(System.Object))]
    public class SystemObjectPropertyDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var field = new RelayCommandElement(property.displayName);
            field.AddToClassList(RelayCommandElement.alignedFieldUssClassName);

            return field;
        }
    }
}
