using System;
using System.Windows.Forms;
using Extensibility;
using EnvDTE;
using EnvDTE80;
using Microsoft.VisualStudio.CommandBars;

namespace TextExtensions
{
	/// <summary>The object for implementing an Add-in.</summary>
	/// <seealso class='IDTExtensibility2' />
	public class Connect : IDTExtensibility2, IDTCommandTarget
	{
		/// <summary>Implements the constructor for the Add-in object. Place your initialization code within this method.</summary>
		public Connect()
		{
		}

        private CommandBar GetCommandBarPopup(CommandBar parentCommandBar, string commandBarPopupName)
        {
            CommandBar commandBar = null;
            CommandBarPopup commandBarPopup;

            foreach (CommandBarControl commandBarControl in parentCommandBar.Controls)
            {
                if (commandBarControl.Type == MsoControlType.msoControlPopup)
                {
                    commandBarPopup = (CommandBarPopup)commandBarControl;

                    if (commandBarPopup.CommandBar.Name == commandBarPopupName)
                    {
                        commandBar = commandBarPopup.CommandBar;
                        break;
                    }
                }
            }
            return commandBar;
        }

		/// <summary>Implements the OnConnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being loaded.</summary>
		/// <param term='application'>Root object of the host application.</param>
		/// <param term='connectMode'>Describes how the Add-in is being loaded.</param>
		/// <param term='addInInst'>Object representing this Add-in.</param>
		/// <seealso class='IDTExtensibility2' />
        public void OnConnection(object application, ext_ConnectMode connectMode, object addInInst, ref Array custom)
		{
            _applicationObject = (DTE2)application;
            _addInInstance = (AddIn)addInInst;

		    switch (connectMode)
		    {
		        case ext_ConnectMode.ext_cm_UISetup:
                    CreateCommands();
                    return;
                default:
                    // Do Nothing
                    return;
		    }
		}

        private void CreateCommands()
        {
            var contextGuids = new object[] { };
            var commands = (Commands2)_applicationObject.Commands;

            try
            {
                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortSelection", "Sort Selection",
                        "Method to sort lines of text within a rectangular selection region. If the selection region is not rectangular, this method may give undesired results.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+F";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortSelection");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortLines", "Sort Lines",
                        "Method to sort lines of text from the selection region. This method performs the same whether or not the selection region is rectangular.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+E";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortLines");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToUpper", "Selection ToUpper",
                        "Method to convert text within a selection region to an upper-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+U";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToUpper");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToLower", "Selection ToLower",
                        "Method to convert text within a selection region to a lower-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+L";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToLower");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionCapitalize", "Selection Capitalize",
                        "Method to convert text within a selection region to a capitalized version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+K";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionCapitalize");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteReplace", "Paste Replace",
                        "Method to replace selected text with lines from the clipboard. If the selection region is not rectangular, this method may give undesired results.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+S";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteReplace");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PastePrepend", "Paste Prepend",
                        "Method to prepend selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+A";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PastePrepend");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteAppend", "Paste Append",
                        "Method to append selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.Bindings = "Global::ALT+D";
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteAppend");
                    if (command == null)
                        throw;
                }
            }
            catch (Exception ex)
            {
                // If we are here, then I have no clue... and am suppressing the error.
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\n" + ex.InnerException.Message;

                MessageBox.Show(message);
            }

            // For Code Window
            try
            {
                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortSelection2", "Sort Selection",
                        "Method to sort lines of text within a rectangular selection region. If the selection region is not rectangular, this method may give undesired results.",
                        true, 2, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortSelection2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortLines2", "Sort Lines",
                        "Method to sort lines of text from the selection region. This method performs the same whether or not the selection region is rectangular.",
                        true, 2, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortLines2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToUpper2", "Selection ToUpper",
                        "Method to convert text within a selection region to an upper-case version of that text.",
                        true, 2, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToUpper2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToLower2", "Selection ToLower",
                        "Method to convert text within a selection region to a lower-case version of that text.",
                        true, 2, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToLower2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionCapitalize2", "Selection Capitalize",
                        "Method to convert text within a selection region to a capitalized version of that text.",
                        true, 2, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionCapitalize2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteReplace2", "Paste Replace",
                        "Method to replace selected text with lines from the clipboard. If the selection region is not rectangular, this method may give undesired results.",
                        true, 22, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteReplace2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PastePrepend2", "Paste Prepend",
                        "Method to prepend selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PastePrepend2");
                    if (command == null)
                        throw;
                }

                try
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteAppend2", "Paste Append",
                        "Method to append selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);
                }
                catch (ArgumentException)
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteAppend2");
                    if (command == null)
                        throw;
                }
            }
            catch (Exception ex)
            {
                // If we are here, then I have no clue... and am suppressing the error.
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\n" + ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

        private void CreateUi()
        {
            var contextGuids = new object[] { };
            var commands = (Commands2)_applicationObject.Commands;
            const string editMenuName = "Edit";

            var menuBarCommandBar = ((CommandBars)_applicationObject.CommandBars)["MenuBar"];
            var codeWindowCommandBar = ((CommandBars)_applicationObject.CommandBars)["Code Window"];
            var editPopup = (CommandBarPopup)menuBarCommandBar.Controls[editMenuName];
            if (editPopup == null) return;

            // Inserting these commands in reverse alphabetical order so that they show up in the lists alphabetically.
            // For Edit Menu
            try
            {
                var textExtensionsPopup = (CommandBarPopup)editPopup.Controls.Add(MsoControlType.msoControlPopup, 1, Type.Missing, Type.Missing, Type.Missing);
                if (textExtensionsPopup == null)
                    return;

                textExtensionsPopup.Caption = "Text Extensions";
                textExtensionsPopup.TooltipText = "Extensions for advanced text operations in Visual Studio.";

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortSelection");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortSelection", "Sort Selection",
                        "Method to sort lines of text within a rectangular selection region. If the selection region is not rectangular, this method may give undesired results.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+F";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortLines");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortLines", "Sort Lines",
                        "Method to sort lines of text from the selection region. This method performs the same whether or not the selection region is rectangular.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+E";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToUpper");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToUpper", "Selection ToUpper",
                        "Method to convert text within a selection region to an upper-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+U";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToLower");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToLower", "Selection ToLower",
                        "Method to convert text within a selection region to a lower-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+L";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionCapitalize");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionCapitalize", "Selection Capitalize",
                        "Method to convert text within a selection region to a capitalized version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+K";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteReplace");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteReplace", "Paste Replace",
                        "Method to replace selected text with lines from the clipboard. If the selection region is not rectangular, this method may give undesired results.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+S";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PastePrepend");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PastePrepend", "Paste Prepend",
                        "Method to prepend selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+A";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteAppend");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteAppend", "Paste Append",
                        "Method to append selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                    {
                        command.Bindings = "Global::ALT+D";
                        command.AddControl(textExtensionsPopup.CommandBar);
                    }
                }
            }
            catch (Exception ex)
            {
                // If we are here, then I have no clue... and am suppressing the error.
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\n" + ex.InnerException.Message;

                MessageBox.Show(message);
            }

            // For Code Window
            try
            {
                var textExtensionsPopup = (CommandBarPopup)codeWindowCommandBar.Controls.Add(MsoControlType.msoControlPopup, 1, Type.Missing, Type.Missing, Type.Missing);
                if (textExtensionsPopup == null)
                    return;

                textExtensionsPopup.Caption = "Text Extensions";
                textExtensionsPopup.TooltipText = "Extensions for advanced text operations in Visual Studio.";

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortSelection2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                    
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortSelection2", "Sort Selection",
                        "Method to sort lines of text within a rectangular selection region. If the selection region is not rectangular, this method may give undesired results.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SortLines2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SortLines2", "Sort Lines",
                        "Method to sort lines of text from the selection region. This method performs the same whether or not the selection region is rectangular.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToUpper2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToUpper2", "Selection ToUpper",
                        "Method to convert text within a selection region to an upper-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionToLower2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionToLower2", "Selection ToLower",
                        "Method to convert text within a selection region to a lower-case version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.SelectionCapitalize2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "SelectionCapitalize2", "Selection Capitalize",
                        "Method to convert text within a selection region to a capitalized version of that text.",
                        true, 2, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteReplace2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteReplace2", "Paste Replace",
                        "Method to replace selected text with lines from the clipboard. If the selection region is not rectangular, this method may give undesired results.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PastePrepend2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PastePrepend2", "Paste Prepend",
                        "Method to prepend selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }

                try
                {
                    // Command may already exist.
                    var command = _applicationObject.Commands.Item("TextExtensions.Connect.PasteAppend2");
                    command.AddControl(textExtensionsPopup.CommandBar);
                }
                catch (ArgumentException)
                {
                    //Add a command to the Commands collection:
                    var command = commands.AddNamedCommand2(_addInInstance, "PasteAppend2", "Paste Append",
                        "Method to append selected text with lines from the clipboard. This method performs the same whether or not the selection region is rectangular.",
                        true, 22, ref contextGuids);

                    // Add a control for the command to the TextExtensions menu:
                    if ((command != null))
                        command.AddControl(textExtensionsPopup.CommandBar);
                }
            }
            catch (Exception ex)
            {
                // If we are here, then I have no clue... and am suppressing the error.
                var message = ex.Message;
                if (ex.InnerException != null)
                    message += "\n" + ex.InnerException.Message;

                MessageBox.Show(message);
            }
        }

		/// <summary>Implements the OnDisconnection method of the IDTExtensibility2 interface. Receives notification that the Add-in is being unloaded.</summary>
		/// <param term='disconnectMode'>Describes how the Add-in is being unloaded.</param>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnDisconnection(ext_DisconnectMode disconnectMode, ref Array custom)
		{
		}

		/// <summary>Implements the OnAddInsUpdate method of the IDTExtensibility2 interface. Receives notification when the collection of Add-ins has changed.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />		
		public void OnAddInsUpdate(ref Array custom)
		{
		}

		/// <summary>Implements the OnStartupComplete method of the IDTExtensibility2 interface. Receives notification that the host application has completed loading.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnStartupComplete(ref Array custom)
		{
            CreateUi();
		}

		/// <summary>Implements the OnBeginShutdown method of the IDTExtensibility2 interface. Receives notification that the host application is being unloaded.</summary>
		/// <param term='custom'>Array of parameters that are host application specific.</param>
		/// <seealso class='IDTExtensibility2' />
		public void OnBeginShutdown(ref Array custom)
		{
		}
		
		/// <summary>Implements the QueryStatus method of the IDTCommandTarget interface. This is called when the command's availability is updated</summary>
		/// <param term='commandName'>The name of the command to determine state for.</param>
		/// <param term='neededText'>Text that is needed for the command.</param>
		/// <param term='status'>The state of the command in the user interface.</param>
		/// <param term='commandText'>Text requested by the neededText parameter.</param>
		/// <seealso class='Exec' />
		public void QueryStatus(string commandName, vsCommandStatusTextWanted neededText, ref vsCommandStatus status, ref object commandText)
		{
            if (neededText != vsCommandStatusTextWanted.vsCommandStatusTextWantedNone)
                return;

            switch (commandName)
            {
                case "TextExtensions.Connect.TextExtensions":
                    if (TextExtensionMethods.HasActiveDocument(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PasteAppend":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PastePrepend":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PasteReplace":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SortLines":
                    if (TextExtensionMethods.CanSort(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SortSelection":
                    if (TextExtensionMethods.CanSort(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionToUpper":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionToLower":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionCapitalize":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PasteAppend2":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PastePrepend2":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.PasteReplace2":
                    if (TextExtensionMethods.CanPaste(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SortLines2":
                    if (TextExtensionMethods.CanSort(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SortSelection2":
                    if (TextExtensionMethods.CanSort(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionToUpper2":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionToLower2":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                case "TextExtensions.Connect.SelectionCapitalize2":
                    if (TextExtensionMethods.HasSelection(_applicationObject))
                    {
                        status = vsCommandStatus.vsCommandStatusSupported | vsCommandStatus.vsCommandStatusEnabled;
                    }
                    else
                    {
                        status = vsCommandStatus.vsCommandStatusSupported;
                    }
                    return;
                default:
                    break;
            }
		}

		/// <summary>Implements the Exec method of the IDTCommandTarget interface. This is called when the command is invoked.</summary>
		/// <param term='commandName'>The name of the command to execute.</param>
		/// <param term='executeOption'>Describes how the command should be run.</param>
		/// <param term='varIn'>Parameters passed from the caller to the command handler.</param>
		/// <param term='varOut'>Parameters passed from the command handler to the caller.</param>
		/// <param term='handled'>Informs the caller if the command was handled or not.</param>
		/// <seealso class='Exec' />
		public void Exec(string commandName, vsCommandExecOption executeOption, ref object varIn, ref object varOut, ref bool handled)
		{
            handled = false;
            if (executeOption != vsCommandExecOption.vsCommandExecOptionDoDefault)
                return;

            switch (commandName)
            {
                case "TextExtensions.Connect.TextExtensions":
                    handled = true;
                    return;
                case "TextExtensions.Connect.PasteAppend":
                    handled = true;
                    TextExtensionMethods.PasteAppend(_applicationObject);
                    return;
                case "TextExtensions.Connect.PastePrepend":
                    handled = true;
                    TextExtensionMethods.PastePrepend(_applicationObject);
                    return;
                case "TextExtensions.Connect.PasteReplace":
                    handled = true;
                    TextExtensionMethods.PasteReplace(_applicationObject);
                    return;
                case "TextExtensions.Connect.SortLines":
                    handled = true;
                    TextExtensionMethods.SortLines(_applicationObject);
                    return;
                case "TextExtensions.Connect.SortSelection":
                    handled = true;
                    TextExtensionMethods.SortSelection(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionToUpper":
                    handled = true;
                    TextExtensionMethods.SelectionToUpper(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionToLower":
                    handled = true;
                    TextExtensionMethods.SelectionToLower(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionCapitalize":
                    handled = true;
                    TextExtensionMethods.SelectionCapitalize(_applicationObject);
                    return;
                case "TextExtensions.Connect.PasteAppend2":
                    handled = true;
                    TextExtensionMethods.PasteAppend(_applicationObject);
                    return;
                case "TextExtensions.Connect.PastePrepend2":
                    handled = true;
                    TextExtensionMethods.PastePrepend(_applicationObject);
                    return;
                case "TextExtensions.Connect.PasteReplace2":
                    handled = true;
                    TextExtensionMethods.PasteReplace(_applicationObject);
                    return;
                case "TextExtensions.Connect.SortLines2":
                    handled = true;
                    TextExtensionMethods.SortLines(_applicationObject);
                    return;
                case "TextExtensions.Connect.SortSelection2":
                    handled = true;
                    TextExtensionMethods.SortSelection(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionToUpper2":
                    handled = true;
                    TextExtensionMethods.SelectionToUpper(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionToLower2":
                    handled = true;
                    TextExtensionMethods.SelectionToLower(_applicationObject);
                    return;
                case "TextExtensions.Connect.SelectionCapitalize2":
                    handled = true;
                    TextExtensionMethods.SelectionCapitalize(_applicationObject);
                    return;
                default:
                    break;
            }
		}

		private DTE2 _applicationObject;
		private AddIn _addInInstance;
	}
}