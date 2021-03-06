﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypePolyfills.cs" company="RHEA System S.A.">
//   Copyright (c) 2017 RHEA System S.A.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace CDP4Common.Polyfills
{
    using System;
    using System.Linq;
    using System.Reflection;

#if NET45 || NET451 || NET452 || NET46 || NET461 || NET462 || NET47

    /// <summary>
    /// The purpose of the <see cref="TypePolyfills"/> class is to provide extension methods on the <see cref="Type"/>
    /// class that can be used from the full dotnet framework and dotnetstandard. All the methods start with the word
    /// Query to distinquish them from the methods that are available in the dotnet framework and netstandard
    /// </summary>
    public static class TypePolyfills
    {
        /// <summary>
        /// Gets the System.Reflection.Assembly in which the type is declared. For generic
        ///  types, gets the System.Reflection.Assembly in which the generic type is defined.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// An System.Reflection.Assembly instance that describes the assembly containing
        /// the current type. For generic types, the instance describes the assembly that
        /// contains the generic type definition, not the assembly that creates and uses
        /// a particular constructed type.
        /// </returns>
        public static Assembly QueryAssembly(this Type type)
        {
            return type.Assembly;
        }

        /// <summary>
        /// Gets a value indicating whether the System.Type is a value type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is a value type; otherwise, false.
        /// </returns>
        public static bool QueryIsValueType(this Type type)
        {
            return type.IsValueType;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is abstract and must be overridden.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is abstract; otherwise, false.
        /// </returns>
        public static bool QueryIsAbstract(this Type type)
        {
            return type.IsAbstract;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is one of the primitive types.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the System.Type is one of the primitive types; otherwise, false.
        /// </returns>
        public static bool QueryIsPrimitive(this Type type)
        {
            return type.IsPrimitive;
        }

        /// <summary>
        /// Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type is a generic type; otherwise, false.
        /// </returns>
        public static bool QueryIsGenericType(this Type type)
        {
            return type.IsGenericType;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Type"/> has been decorated with the provided <see cref="Attribute"/>
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type has been decorated with the specified <see cref="Attribute"/>; otherwise, false.
        /// </returns>
        public static bool QueryIsAttributeDefined<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the <see cref="Attribute"/> of the specified type
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// an instance of the specified <see cref="Attribute"/>; otherwise, null.
        /// </returns>
        public static Attribute QueryGetCustomAttribute<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return attribute;
                }
            }

            return null;
        }

        /// <summary>
        ///  Determines whether an instance of a specified type can be assigned to the current type instance.
        /// </summary>
        /// <typeparam name="TType">
        /// The type to compare with the current type.
        /// </typeparam>
        /// <param name="type">
        /// The current <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if any of the following conditions is true: c and the current instance represent
        /// the same type. c is derived either directly or indirectly from the current instance.
        /// The current instance is an interface that c implements. c is a generic type parameter,
        /// and the current instance represents one of the constraints of c. c represents
        /// a value type, and the current instance represents Nullable<c> .
        /// false if none of these conditions are true, or if c is null.
        /// </returns>
        public static bool QueryIsAssignableFrom(this Type type, Type c)
        {
            return type.IsAssignableFrom(c);
        }

        public static Type QueryBaseType(this Type type)
        {
            return type.BaseType;
        }

        public static bool QueryIsSubclassOf(this Type type, Type c)
        {
            return type.IsSubclassOf(c);
        }

        public static FieldInfo QueryField(this Type type, string name)
        {
            return type.GetField(name);
        }
    }
#else

    /// <summary>
    /// The purpose of the <see cref="TypePolyfills"/> class is to provide extension methods on the <see cref="Type"/>
    /// class that can be used from the full dotnet framework and dotnetstandard. All the methods start with the word
    /// Query to distinquish them from the methods that are available in the dotnet framework and netstandard
    /// </summary>
    public static class TypePolyfills
    {
        /// <summary>
        /// Gets the System.Reflection.Assembly in which the type is declared. For generic
        ///  types, gets the System.Reflection.Assembly in which the generic type is defined.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// An System.Reflection.Assembly instance that describes the assembly containing
        /// the current type. For generic types, the instance describes the assembly that
        /// contains the generic type definition, not the assembly that creates and uses
        /// a particular constructed type.
        /// </returns>
        public static Assembly QueryAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        /// <summary>
        /// Gets a value indicating whether the System.Type is a value type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is a value type; otherwise, false.
        /// </returns>
        public static bool QueryIsValueType(this Type type)
        {
            return type.GetTypeInfo().IsValueType;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is abstract and must be overridden.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the <see cref="Type"/> is abstract; otherwise, false.
        /// </returns>
        public static bool QueryIsAbstract(this Type type)
        {
            return type.GetTypeInfo().IsAbstract;
        }

        /// <summary>
        /// Gets a value indicating whether the <see cref="Type"/> is one of the primitive types.
        /// </summary>
        /// <param name="type">
        /// the subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the System.Type is one of the primitive types; otherwise, false.
        /// </returns>
        public static bool QueryIsPrimitive(this Type type)
        {
            return type.GetTypeInfo().IsPrimitive;
        }

        /// <summary>
        /// Gets a value indicating whether the current type is a generic type.
        /// </summary>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type is a generic type; otherwise, false.
        /// </returns>
        public static bool QueryIsGenericType(this Type type)
        {
            return type.GetTypeInfo().IsGenericType;
        }

        /// <summary>
        /// Gets a value indicating whether the current <see cref="Type"/> has been decorated with the provided <see cref="Attribute"/>
        /// </summary>
        /// <typeparam name="TAttribute">
        /// The type of the subject <see cref="Attribute"/>
        /// </typeparam>
        /// <param name="type">
        /// The subject <see cref="Type"/>
        /// </param>
        /// <returns>
        /// true if the current type has been decorated with the specified <see cref="Attribute"/>; otherwise, false.
        /// </returns>
        public static bool QueryIsAttributeDefined<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return true;
                }
            }

            return false;
        }
        
        public static Attribute QueryGetCustomAttribute<TAttribute>(this Type type)
        {
            var attributes = type.GetTypeInfo().GetCustomAttributes();
            foreach (var attribute in attributes)
            {
                if (attribute.GetType() == typeof(TAttribute))
                {
                    return attribute;
                }
            }

            return null;
        }

        public static bool QueryIsAssignableFrom(this Type type, Type c)
        {
            return type.GetTypeInfo().IsAssignableFrom(c);
        }

        public static Type QueryBaseType(this Type type)
        {
            return type.GetTypeInfo().BaseType;
        }

        public static bool QueryIsSubclassOf(this Type type, Type c)
        {
            return type.GetTypeInfo().IsSubclassOf(c);
        }

        public static FieldInfo QueryField(this Type type, string name)
        {
            return type.GetTypeInfo().GetField(name);
        }
    }

#endif
}
