using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace  DependencyInjection
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Method)]
    public sealed class InjectAttribute : Attribute
    {
        public InjectAttribute()
        {}
    }

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class ProvideAttribute : Attribute
    {
        public ProvideAttribute()
        {}
    }

    public interface IDependencyProvider
    {
        
    }

    public class Injector : MonoBehaviour
    {
        const BindingFlags BindingFlags = System.Reflection.BindingFlags.Default | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public;
        readonly Dictionary<Type, object> registry = new Dictionary<Type, object>();
    }
}
