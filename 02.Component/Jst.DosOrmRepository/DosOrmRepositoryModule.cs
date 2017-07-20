using Jst.Core;
using Jst.Core.Ioc;
using Jst.Core.IRepository;

namespace Jst.DosOrmRepository
{
    public class DosOrmRepositoryModule : JstAppModule
    {

        public override void PreInit(IIocManager instance)
        {
            if (!instance.IsRegister(typeof(IRepository<>)))
            {
                instance.RegisterGeneric(typeof(DosOrmRepositoryBase<>), typeof(IRepository<>));
            }
            instance.RegisterGeneric(typeof(DosOrmRepositoryBase<>), typeof(IDosOrmRepository<>));
            base.PreInit(instance);
        }
    }
}
