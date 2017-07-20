using Nelibur.ObjectMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Utils.Extension
{
    /// <summary>
    /// TinyMapper Extension
    /// </summary>
    public static class MapperExtension
    {
        /// <summary>
        /// 映射对象
        /// </summary>
        /// <typeparam name="Target"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        public static Target MapTo<Target>(this object source)
        {
            Target target = default(Target);
            try
            {
                target = TinyMapper.Map<Target>(source);
            }
            catch (Exception)
            {
            }
            return target;
        }
    }
}
