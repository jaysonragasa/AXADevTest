using AXADevTest.APIClient.Interfaces;
using AXADevTest.APIClient.Services;
using GalaSoft.MvvmLight.Ioc;
using System;

namespace AXADevTest.APIClient
{
    public class ServicesLocator : IServicesLocator
    {
        public IUserService UserService => GetSvc<IUserService>();

        public void RegisterServices()
        {
            RegSvc<IUserService>(() => new UserService());
        }

        void RegSvc<T>(Func<T> factory, bool activateImmediately = false) where T : class
        {
            var instance = SimpleIoc.Default.IsRegistered<T>();
            if (!instance)
            {
                SimpleIoc.Default.Register<T>(factory, activateImmediately);
            }
        }

        T GetSvc<T>() where T : class
        {
            return SimpleIoc.Default.GetInstance<T>();
        }
    }
}
