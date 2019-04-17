namespace Powershell5.Helpers
{
    using System;

    public interface IPowerShellDiContainer
    {
        void Register<T>() where T : class;

        void Register<T>(string name)
            where T : class;

        void Register<TInterface, TImplementation>() where TImplementation : class;

        void Register<TInterface, TImplementation>(string name) where TImplementation : class;

        void Register<T>(Func<T> factoryMethod);

        void Register(Type abstraction, Type implementation);

        void Register(Type abstraction, Type implementation, string name);

        void RegisterSingleton<T>();

        void RegisterSingleton<TInterface, TImplementation>()
            where TImplementation : class;

        void RegisterSingleton<T>(Func<T> factoryMethod);

        void RegisterSingleton<TInterface, TImplementation>(string name)
            where TImplementation : class;

        void RegisterSingleton(Type abstraction, Type implementation);

        void RegisterSingleton(Type abstration, Type implementation, string name);

        object Resolve(Type type);

        object Resolve(Type type, string name);
    }
}