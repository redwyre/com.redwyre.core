using UnityEngine.UIElements;

namespace redwyre.Core.MVVM
{
    /// <summary>
    /// SystemObjectElement is a UI element that represents a System.Object. 
    /// This is used to keep the UI inline with everything else.
    /// </summary>
    public class SystemObjectElement : BaseField<System.Object>
    {
        public SystemObjectElement(string label)
            : base(label, new Label("System.Object for binding")
            {
                style = {
                    flexGrow = 1
                },
                enabledSelf = false
            })
        {
        }
    }
}
