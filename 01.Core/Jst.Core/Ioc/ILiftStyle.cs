namespace Jst.Core.Ioc
{
    public interface IDependency
    {

    }

    public interface ISingleInstance: IDependency
    {
    }

    public interface IInstancePerLifetimeScope : IDependency
    {

    }

    public interface IInstancePerDependency : IDependency
    {

    }
}
