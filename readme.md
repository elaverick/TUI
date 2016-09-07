# Text User Interface for WPF #

This library provides a series of controls to simulate an old school text user interface (TUI) similar the one provided by Turbo Vision.

-------

**Window**

Use this in place of the normal WPF Window control to gain TUI styled Windows. Additional properties exist to choose which window controls appear in the chrome.  These are:

    IsCloseVisible
    IsMaximiseRestoreVisible
    IsMinimizeVisible

**Scrollbars**

If you wish to include styled scrollbars in your application you should add the following to your App.xaml file:

Declare a namespace for TUI -

    xmlns:TUI="clr-namespace:TUI;assembly=TUI"

Add a resource dictionary to the Application and pull in the TUI:ScrollBar dictionary -

    <Application.Resources>
        <ResourceDictionary>
            <ResourceDictionary.MergedDictionaries>
                <TUI:ScrollBar/>
            </ResourceDictionary.MergedDictionaries>
        </ResourceDictionary>
    </Application.Resources>

 
