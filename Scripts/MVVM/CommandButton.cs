using System;
using System.Windows.Input;
using Unity.Properties;
using UnityEngine;
using UnityEngine.UIElements;

[assembly: MakeSerializable(typeof(object))]

#nullable enable

namespace redwyre.Core.MVVM
{
    /// <summary>
    /// CommandButton is a button that can be bound to a ICommand. It 
    /// will disable itself if the command is unable to be executed.
    /// </summary>
    [UxmlElement]
    public partial class CommandButton : Button
    {
        ICommand? command;

        // Unity does not currently allow for nullability annotations on UxmlAttribute properties (6000.0.47)
#nullable disable
        [UxmlObjectReference(types = new System.Type[] { })]
        [CreateProperty]
        public ICommand Command
        {
            get => command;
            set
            {
                if (command == value) return;

                if (command != null)
                {
                    command.CanExecuteChanged -= OnCanExecuteChanged;
                }

                command = value;

                if (command != null)
                {
                    command.CanExecuteChanged += OnCanExecuteChanged;
                }

                OnCanExecuteChanged(null, EventArgs.Empty);
            }
        }

        //[UxmlObjectReference(types = new[] { typeof(object) })]

        [UxmlAttribute]
        [CreateProperty]
        public object CommandParameter { get; set; }
#nullable enable

        public CommandButton()
        {
            RegisterCallback<ClickEvent>(OnClick);
        }

        private void OnClick(ClickEvent evt)
        {
            if (Command != null && Command.CanExecute(CommandParameter))
            {
                Command.Execute(CommandParameter);
            }
        }

        private void OnCanExecuteChanged(object? sender, EventArgs eventArgs)
        {
            SetEnabled(Command?.CanExecute(CommandParameter) ?? true);
        }
    }
}
