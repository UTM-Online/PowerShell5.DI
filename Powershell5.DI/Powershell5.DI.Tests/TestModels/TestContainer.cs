namespace Powershell5.DI.Tests.TestModels
{
    using System;

    using UTMO.Powershell5.DI.DI;

    public class TestContainer : IPowerShellDiContainer
    {
        public void Register<T>()
            where T : class
        {
            throw new NotImplementedException();
        }

        public void Register<T>(string name)
            where T : class
        {
            throw new NotImplementedException();
        }

        public void Register<TInterface, TImplementation>()
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void Register<TInterface, TImplementation>(string name)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void RegisterFactory<TInterface, TImplementation>(Func<TInterface, TImplementation> factoryMethod)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public void RegisterFactory<TInterface, TImplementation>(Func<TImplementation> factoryMethod, string name)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void Register(Type abstraction, Type implementation)
        {
            throw new NotImplementedException();
        }

        public void Register(Type abstraction, Type implementation, string name)
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<T>()
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface, TImplementation>()
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface, TImplementation>(Func<TInterface, TImplementation> factoryMethod)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton<TInterface, TImplementation>(string name)
            where TImplementation : class, TInterface
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton(Type abstraction, Type implementation)
        {
            throw new NotImplementedException();
        }

        public void RegisterSingleton(Type abstraction, Type implementation, string name)
        {
            throw new NotImplementedException();
        }

        public object Resolve(Type type)
        {
            if (type == typeof(string))
            {
                return "DI Successful";
            }
            else
            {
                throw new Exception($"BAD TYPE REQUESTED. Type {typeof(Type).Name} is not a STRING.");
            }
        }

        public object Resolve(Type type, string name)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public T Resolve<T>()
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public T Resolve<T>(string name)
        {
            throw new NotImplementedException();
        }
    }
}