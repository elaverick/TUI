using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace TUI
{
    public class GroupBox : System.Windows.Controls.GroupBox
    {
        static GroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GroupBox),
                new FrameworkPropertyMetadata(typeof(GroupBox)));
        }

        public GroupBox()
            : base()
        {
        }        
    }
}
