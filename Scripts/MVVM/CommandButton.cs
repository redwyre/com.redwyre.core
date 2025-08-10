using System;
using System.Windows.Input;
using Unity.Properties;
using UnityEngine.UIElements;

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
        [UxmlObjectReference(types = new System.Type[0])]
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
#nullable enable

        public CommandButton()
        {
            RegisterCallback<ClickEvent>(OnClick);
        }

        private void OnClick(ClickEvent evt)
        {
            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }

        private void OnCanExecuteChanged(object sender, EventArgs eventArgs)
        {
            SetEnabled(Command?.CanExecute(null) ?? true);
        }
    }
}
