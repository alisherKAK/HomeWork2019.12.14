using HomeWork2019._12._14.AbstractModels;
using HomeWork2019._12._14.DataAccess;
using HomeWork2019._12._14.Models;
using HomeWork2019._12._14.Services;
using Ninject.Modules;

namespace HomeWork2019._12._14.Web.Ninject
{
    public class NinjectRegistration : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRepository<Post>>().To<DbRepository<Post>>().WithConstructorArgument("context", new InstagramContext());
            this.Bind<IRepository<User>>().To<DbRepository<User>>().WithConstructorArgument("context", new InstagramContext());
        }
    }
}