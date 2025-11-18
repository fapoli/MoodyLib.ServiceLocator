using System;
using System.Collections.Generic;

/// <summary>
/// Provides a simple global service registry, allowing types to be registered and
/// resolved from anywhere in the codebase. This is a minimal implementation of
/// the Service Locator pattern.
/// </summary>
public static class ServiceLocator {
    private static readonly Dictionary<Type, object> services = new Dictionary<Type, object>();

    /// <summary>
    /// Registers an instance of type <typeparamref name="T"/> into the service locator.
    /// If a service of this type was previously registered, it will be overwritten.
    /// </summary>
    /// <param name="instance">The instance to associate with the service type.</param>
    /// <typeparam name="T">The type under which the instance will be registered.</typeparam>
    public static void Register<T>(object instance) {
        services[typeof(T)] = instance;
    }

    /// <summary>
    /// Retrieves the instance registered under type <typeparamref name="T"/>.
    /// </summary>
    /// <returns>
    /// The registered instance of <typeparamref name="T"/>, or <c>null</c> if no service
    /// of that type has been registered.
    /// </returns>
    /// <typeparam name="T">The type of the service to retrieve.</typeparam>
    public static T Resolve<T>() {
        if (!services.ContainsKey(typeof(T))) {
            return default;
        }
        
        return (T)services[typeof(T)];
    }

    /// <summary>
    /// Removes all registered services from the locator.
    /// </summary>
    public static void Reset() {
        services.Clear();
    }
}