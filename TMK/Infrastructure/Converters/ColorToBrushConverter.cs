using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using TMK.Infrastructure.Converters.Base;

namespace TMK.Infrastructure.Converters
{
    [ValueConversion(typeof(System.Drawing.Color), typeof(Brush))]
    [MarkupExtensionReturnType(typeof(ColorToBrushConverter))]

    public class ColorToBrushConverter : ConverterBase
    {
        #region Overrides of ConverterBase

        public override object Convert(object v, Type t, object p, CultureInfo c)
        {
            if (v == null) return Colors.Transparent;
            //System.Drawing.Color drColor = (System.Drawing.Color)v;
            //Color color = Color.FromArgb(drColor.A, drColor.R, drColor.G, drColor.B);
            //return new SolidColorBrush(color);
            return new SolidColorBrush((Color)v);
        }

        #endregion
    }
}
