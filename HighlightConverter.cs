using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;

namespace TUI
{
    public class HighlightConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string start = "", accessorKey = "", end = "";
            Brush colour = Brushes.Yellow;

            if (values.Length < 1 || values.Length>2 || values[0] == null || (values[0] as string) == null)
            {
                return null;
            }
            string inputString = (string)values[0];
            if (values.Length == 2)
            {
                if (values[1] as Brush == null)
                    throw new ArgumentException();
                colour = (Brush)values[1];
            }

            if (inputString.Contains('_'))
            {
                start = inputString.Substring(0, inputString.IndexOf('_'));
                accessorKey = inputString.Substring(inputString.IndexOf('_') + 1, 1);
                end = inputString.Substring(inputString.IndexOf('_') + 2);
            }

            var span = new Span();
            if (inputString.Contains('_'))
            {
                if (start.Length > 0)
                    span.Inlines.Add(new Run(start));
                span.Inlines.Add(new Run(accessorKey) { Foreground = colour });
                if (end.Length > 0)
                    span.Inlines.Add(new Run(end));
            }
            else
                span.Inlines.Add(new Run(inputString));
            return span;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
