using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TUI
{
    public class Separator: System.Windows.Controls.Separator
    {
        static Separator()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Separator),
                new FrameworkPropertyMetadata(typeof(Separator)));
        }

        public Separator()
            : base()
        {
        }        
    }
}
