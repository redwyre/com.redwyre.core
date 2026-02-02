using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

namespace redwyre.Core.MVVM
{
    public static class UIToolKitConverters
    {
#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
#endif
        public static void RegisterConverters()
        {
            RegisterNamedConverter("BoolTrueToVisibilityVisible", (ref bool b) => b ? new StyleEnum<Visibility>(Visibility.Visible) : new StyleEnum<Visibility>(Visibility.Hidden));
            RegisterNamedConverter("BoolTrueToVisibilityHidden", (ref bool b) =>  b ? new StyleEnum<Visibility>(Visibility.Hidden) : new StyleEnum<Visibility>(Visibility.Visible));

            RegisterNamedConverter("BoolTrueToDisplayStyleFlex", (ref bool b) => b ? new StyleEnum<DisplayStyle>(DisplayStyle.Flex) : new StyleEnum<DisplayStyle>(DisplayStyle.None));
            RegisterNamedConverter("BoolTrueToDisplayStyleNone", (ref bool b) => b ? new StyleEnum<DisplayStyle>(DisplayStyle.None) : new StyleEnum<DisplayStyle>(DisplayStyle.Flex));
        }

        private static void RegisterNamedConverter<TSource, TDestination>(string id, TypeConverter<TSource, TDestination> converter)
        {
            var converterGroup = new ConverterGroup(id);

            converterGroup.AddConverter(converter);

            ConverterGroups.RegisterConverterGroup(converterGroup);
        }
    }
}
