//-----------------------------------------------------------------------
// <copyright file="PrivateTypeExtensions.cs"
//            project="PauloMorgado.TestTools.VisualStudio"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools.VisualStudio"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>Provides extensions to the PrivateType class.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.VisualStudio.UnitTesting
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PauloMorgado.TestTools.Linq.Expressions;

    /// <summary>
    /// Provides extensions to the <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType"/> class.
    /// </summary>
    public static class PrivateTypeExtensions
    {
        /// <summary>
        /// Sets a static array element contained in the wrapped type.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="self">The <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType"/> whose static array element is to be accessed.</param>
        /// <param name="expression">The expression used to retrieve the name of the array.</param>
        /// <param name="value">The value to set the element identified by indices. </param>
        /// <param name="indices">An array of subscripts for identifying the element to set.</param>
        public static void SetStaticArrayElement<T>(
            this global::Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType self,
            Expression<Func<T[]>> expression,
            T value,
            params int[] indices)
        {
            object elementValue = (value is BaseShadow) ? (value as BaseShadow).Target : value;

            self.SetStaticArrayElement(
                expression.GetProperty().Name,
                elementValue,
                indices);
        }

        /// <summary>
        /// Sets a static array element contained in the wrapped type.
        /// </summary>
        /// <typeparam name="T">The type of the elements of the array.</typeparam>
        /// <param name="self">The <see cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType"/> whose static array element is to be accessed.</param>
        /// <param name="expression">The expression used to retrieve the name of the array.</param>
        /// <param name="invokeAttr">A bitmask comprised of one or more <see cref="BindingFlags" /> that specifies how the search for the element is conducted.</param>
        /// <param name="value">The value to set the element identified by indices.</param>
        /// <param name="indices">An array of subscripts for identifying the element to set.</param>
        public static void SetStaticArrayElement<T>(
            this global::Microsoft.VisualStudio.TestTools.UnitTesting.PrivateType self,
            Expression<Func<T[]>> expression,
            BindingFlags invokeAttr,
            T value,
            params int[] indices)
        {
            object elementValue = (value is BaseShadow) ? (value as BaseShadow).Target : value;

            self.SetStaticArrayElement(
                expression.GetProperty().Name,
                invokeAttr,
                elementValue,
                indices);
        }
    }
}
