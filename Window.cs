using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace TUI
{
    public class Window : System.Windows.Window
    {
        static Window()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Window),
           new FrameworkPropertyMetadata(typeof(Window)));
        }

        public Window (): base()
        {
            this.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
            this.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));

        }

        public bool IsCloseVisible
        {
            get { return (bool)GetValue(IsCloseVisibleProperty); }
            set { SetValue(IsCloseVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CloseVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCloseVisibleProperty =
            DependencyProperty.Register("IsCloseVisible", typeof(bool), typeof(Window), new PropertyMetadata(true));

        public bool IsMaximiseRestoreVisible
        {
            get { return (bool)GetValue(IsMaximiseRestoreVisibleProperty); }
            set { SetValue(IsMaximiseRestoreVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaximiseRestoreVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMaximiseRestoreVisibleProperty =
            DependencyProperty.Register("IsMaximiseRestoreVisible", typeof(bool), typeof(Window), new PropertyMetadata(true));

        public bool IsMinimizeVisible
        {
            get { return (bool)GetValue(IsMinimizeVisibleProperty); }
            set { SetValue(IsMinimizeVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMinimizeVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMinimizeVisibleProperty =
            DependencyProperty.Register("IsMinimizeVisible", typeof(bool), typeof(Window), new PropertyMetadata(true));        

        private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode != ResizeMode.NoResize;
        }

        private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = this.ResizeMode == ResizeMode.CanResize || this.ResizeMode == ResizeMode.CanResizeWithGrip;
        }

        private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.CloseWindow(this);
        }

        private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MaximizeWindow(this);
        }

        private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
        {
           SystemCommands.RestoreWindow(this);
        }
    }
}
