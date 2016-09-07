using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace TUI
{
    public class MenuItem : System.Windows.Controls.MenuItem
    {
        static MenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuItem),
               new FrameworkPropertyMetadata(typeof(MenuItem)));
        }

        public MenuItem () : base()
        {
        }

        public Brush HighlightColor
        {
            get { return (Brush)GetValue(HighlightColorProperty); }
            set { SetValue(HighlightColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HighlightColor.  This enables animation, styling, binding, etc...
        [Category("Brush"), Browsable(true), Description("Color of the Access Key")]
        public static readonly DependencyProperty HighlightColorProperty =
            DependencyProperty.Register("HighlightColor", typeof(Brush), typeof(MenuItem), new PropertyMetadata(Brushes.Red));

        
    }
}
