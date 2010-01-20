//-----------------------------------------------------------------------
// <copyright file="IsolateShadowed.cs"
//            project="PauloMorgado.TestTools.TypeMock"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools.TypeMock"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>Extensions to the Isolator Arrange/Act/Assert API to work with Visual Studio shadowed objects.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Extensions to the <see href="http://www.typemock.com/">Isolator</see> Arrange/Act/Assert API to work with Visual Studio shadowed objects.
    /// </summary>
    /// <seealso cref="T:TypeMock.ArrangeActAssert.Isolate"/>
    /// <seealso cref="T:Microsoft.VisualStudio.TestTools.UnitTesting.Microsoft.VisualStudio.TestTools.UnitTesting"/>
    public static class IsolateShadowed
    {
        /// <summary>
        /// Gets a verifying shadowed object that can verify calls were made or not, and check if their arguments were sent correctly.
        /// </summary>
        /// <value>An <see cref="T:PauloMorgado.TestTools.TypeMock.ArrangeActAssert.IVerifyHandler"/> interface reference.</value>
        /// <remarks>
        /// Because of the nature of fluent interface, you need to use <see cref="P:Verify"/> with one of its proceeding methods.
        /// </remarks>
        public static global::PauloMorgado.TestTools.TypeMock.ArrangeActAssert.IVerifyHandler Verify
        {
            get { return global::PauloMorgado.TestTools.TypeMock.ArrangeActAssert.ShadowedVerifyHandler.Instance; }
        }

        /// <summary>
        /// Sets behavior for a specific method on a an object.
        /// </summary>
        /// <param name="expression">The expression calling a method to set behavior on.</param>
        /// <returns>An <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler"/> interface reference.</returns>
        /// <remarks>
        /// Because of the nature of fluent interface, <see cref="M:WhenCalled`1(Expression`1[Action])"/> should be used with its proceeding methods.
        /// <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler"/>
        /// </remarks>
        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler WhenCalled(Expression<Action> expression)
        {
            return ((Func<object, string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler>)(global::TypeMock.ArrangeActAssert.Isolate.NonPublic.WhenCalled))
                .InvokeNonPublic((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Sets behavior for a specific static method on a class.
        /// </summary>
        /// <param name="expression">The expression calling a static method to set behavior on.</param>
        /// <typeparam name="T">The type to set method behavior on. Applies to static methods.</typeparam>
        /// <returns>An <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler"/> interface reference.</returns>
        /// <remarks>
        /// Because of the nature of fluent interface, <see cref="M:WhenCalled`1(Expression`1[Func`1])"/> should be used with its proceeding methods.
        /// <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler"/>
        /// </remarks>
        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler WhenCalled<T>(Expression<Func<T>> expression)
        {
            return ((Func<string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler>)(global::TypeMock.ArrangeActAssert.Isolate.NonPublic.WhenCalled<T>))
                .InvokeNonPublic((MethodCallExpression)(expression.Body));
        }
    }
}
