using EfRepository.Test.Entities;
using Jst.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfRepository.Test.MyRepositories
{
    public interface IMyRepository : IRepository<int,Customer>
    {
    }
}
