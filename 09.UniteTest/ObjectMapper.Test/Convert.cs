using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectMapper.Test
{
    public  class CombineConverter : TypeConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            //return base.CanConvertFrom(context, sourceType);
            return typeof(Person) == sourceType;
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}
