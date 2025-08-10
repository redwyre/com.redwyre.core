using UnityEditor;
using UnityEngine.UIElements;

namespace redwyre.Core.MVVM
{
    public static class UIToolKitConverters
    {

#if UNITY_EDITOR
        [InitializeOnLoadMethod]
#else
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        public static void RegisterConverters()
        {
            ConverterGroups.RegisterGlobalConverter((ref RelayCommand x) =>
            {
                return (RelayCommand)x;
            });
        }
    }
}