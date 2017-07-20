using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jst.Core.Ioc
{
    public interface IIocResolver
    {
        #region Resolves
        /// <summary>
        /// 实例化对象
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        TInterface Resolve<TInterface>(string name="");

        #endregion
    }
}
