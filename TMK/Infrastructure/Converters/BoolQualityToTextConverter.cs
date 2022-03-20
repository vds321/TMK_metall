#nullable enable
using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using TMK.Infrastructure.Converters.Base;

namespace TMK.Infrastructure.Converters
{
    [ValueConversion(typeof(bool?), typeof(string))]
    [MarkupExtensionReturnType(typeof(BoolQualityToTextConverter))]
    public class BoolQualityToTextConverter : ConverterBase
    {
        #region Overrides of ConverterBase

        public override string? Convert(object? v, Type t, object? p, CultureInfo c)
        {
            if (v == null) return null;
            bool IsNowUpdating = (bool)v;
            return IsNowUpdating ? "Хорошее" : "Брак";
        }

        #endregion
    }
}
