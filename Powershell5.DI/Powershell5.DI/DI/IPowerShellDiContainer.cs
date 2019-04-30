// ***********************************************************************
// Assembly         : UTMO.Powershell5.DI
// Author           : joirwi
// Created          : 04-18-2019
//
// Last Modified By : joirwi
// Last Modified On : 04-18-2019
// ***********************************************************************
// <copyright file="IPowerShellDiContainer.cs" company="UTM-Online">
//     Copyright ©  2019
// </copyright>
// <summary>The interface provided to allow developers the ability to implement their own DI container.</summary>
// ***********************************************************************
namespace UTMO.Powershell5.DI.DI
{
    using System;

    /// <summary>
    /// Interface IPowerShellDiContainer
    /// </summary>
    public interface IPowerShellDiContainer
    {
        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="T">The type being registered</typeparam>
        void Register<T>() where T : class;

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <typeparam name="T">The type being registered</typeparam>
        /// <param name="name">The name.</param>
        void Register<T>(string name)
            where T : class;

        /// <summary>
        /// Registers this instance.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        void Register<TInterface, TImplementation>() where TImplementation : class, TInterface;

        /// <summary>
        /// Registers the specified name.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        /// <param name="name">The name.</param>
        void Register<TInterface, TImplementation>(string name) where TImplementation : class, TInterface;

        /// <summary>Registers the specified factory method.</summary>
        /// <typeparam name="TInterface">The Interface Being Registered</typeparam>
        /// <typeparam name="TImplementation">The class being mapped to the interface</typeparam>
        /// <param name="factoryMethod">The factory method.</param>
        void RegisterFactory<TInterface, TImplementation>(Func<TInterface, TImplementation> factoryMethod)
            where TImplementation : class, TInterface;

        /// <summary>
        /// Registers the specified abstraction.
        /// </summary>
        /// <param name="abstraction">The abstraction.</param>
        /// <param name="implementation">The implementation.</param>
        void Register(Type abstraction, Type implementation);

        /// <summary>
        /// Registers the specified abstraction.
        /// </summary>
        /// <param name="abstraction">The abstraction.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="name">The name.</param>
        void Register(Type abstraction, Type implementation, string name);

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RegisterSingleton<T>();

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        void RegisterSingleton<TInterface, TImplementation>()
            where TImplementation : class, TInterface;

        /// <summary>Registers the singleton.</summary>
        /// <typeparam name="TInterface">The Interface Being Registered</typeparam>
        /// <typeparam name="TImplementation">The Objecting being mapped to the interface</typeparam>
        /// <param name="factoryMethod">The factory method.</param>
        void RegisterSingleton<TInterface, TImplementation>(Func<TInterface, TImplementation> factoryMethod)
            where TImplementation : class, TInterface;

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        /// <param name="name">The name.</param>
        void RegisterSingleton<TInterface, TImplementation>(string name)
            where TImplementation : class, TInterface;

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <param name="abstraction">The abstraction.</param>
        /// <param name="implementation">The implementation.</param>
        void RegisterSingleton(Type abstraction, Type implementation);

        /// <summary>
        /// Registers the singleton.
        /// </summary>
        /// <param name="abstraction">The abstraction.</param>
        /// <param name="implementation">The implementation.</param>
        /// <param name="name">The name.</param>
        void RegisterSingleton(Type abstraction, Type implementation, string name);

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <returns>System.Object.</returns>
        object Resolve(Type type, string name);
    }
}