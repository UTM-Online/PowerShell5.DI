﻿// ***********************************************************************
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

        /// <summary>Registers the factory.</summary>
        /// <typeparam name="TInterface">  The interface being registered with container</typeparam>
        /// <typeparam name="TImplementation">  The backing concrete type that implements the TInterface</typeparam>
        /// <param name="factoryMethod">The factory method that generates an instance of TImplementation.</param>
        /// <param name="name">The unique name of the TInterface TImplementation registered pair.</param>
        void RegisterFactory<TInterface, TImplementation>(Func<TImplementation> factoryMethod, string name)
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
        /// Registers a singleton.
        /// </summary>
        /// <typeparam name="T">The type of the singleton being registered</typeparam>
        void RegisterSingleton<T>();

        /// <summary>
        /// Registers a singleton.
        /// </summary>
        /// <typeparam name="TInterface">The type of the t interface.</typeparam>
        /// <typeparam name="TImplementation">The type of the t implementation.</typeparam>
        void RegisterSingleton<TInterface, TImplementation>()
            where TImplementation : class, TInterface;

        /// <summary>Registers a singleton.</summary>
        /// <typeparam name="TInterface">The Interface Being Registered</typeparam>
        /// <typeparam name="TImplementation">The Objecting being mapped to the interface</typeparam>
        /// <param name="factoryMethod">The factory method.</param>
        void RegisterSingleton<TInterface, TImplementation>(Func<TInterface, TImplementation> factoryMethod)
            where TImplementation : class, TInterface;

        void RegisterSingleton<T>(T item) where T : class;

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
        /// <returns>The registered type boxed in an <see cref="object"/>.</returns>
        object Resolve(Type type);

        /// <summary>
        /// Resolves the specified type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="name">The name.</param>
        /// <returns>The registered type with the specified name boxed in an <see cref="object"/>.</returns>
        object Resolve(Type type, string name);

        /// <summary>Resolves the specified type</summary>
        /// <typeparam name="T">The type being returned from the container</typeparam>
        /// <returns>  An instance of the requested type</returns>
        T Resolve<T>();

        /// <summary>Resolves the specified type by its name.</summary>
        /// <typeparam name="T">The type being returned from the container</typeparam>
        /// <param name="name">The name of the registered type being returned from the container</param>
        /// <returns>  An instance of the registered type resolved by its name</returns>
        T Resolve<T>(string name);
    }
}