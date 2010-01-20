//-----------------------------------------------------------------------
// <copyright file="ShadowedVerifyHandler.cs"
//            project="PauloMorgado.TestTools.TypeMock"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools.TypeMock"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>Implementation of IVerifyHandler.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Implementation of <see cref="T:IVerifyHandler"/>.
    /// </summary>
    internal class ShadowedVerifyHandler : IVerifyHandler
    {
        /// <summary>
        /// The instance of <see cref="T:ShadowedVerifyHandler"/> to be used as an <see cref="T:IVerifyHandler"/> instance.
        /// </summary>
        public static readonly ShadowedVerifyHandler Instance = new ShadowedVerifyHandler();

        /// <summary>
        /// Prevents a default instance of the <see cref="ShadowedVerifyHandler"/> class from being created.
        /// </summary>
        private ShadowedVerifyHandler()
        {
        }

        /// <summary>
        /// Verifies that a method was called, without checking its arguments.
        /// </summary>
        /// <param name="expression">A void method in the form of a Lambda Expression to verify if it was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithAnyArguments"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasCalledWithAnyArguments(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithAnyArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was called, and checking its arguments using custom verifier.
        /// </summary>
        /// <param name="expression">A void method in the form of a Lambda Expression to verify if it was called.</param>
        /// <returns>
        /// An <see cref="TypeMock.ArrangeActAssert.IArgumentsMatcher"/> instance.
        /// </returns>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithArguments"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments(Expression<Action> expression)
        {
            return ((Func<Action, global::TypeMock.ArrangeActAssert.IArgumentsMatcher>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was called, without checking its arguments.
        /// </summary>
        /// <typeparam name="T">The return type of the method to verify.</typeparam>
        /// <param name="expression">A method returning a value in the form of a Lambda Expression that we want
        /// to verify if was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithAnyArguments`1"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasCalledWithAnyArguments<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithAnyArguments<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was called, and checking its arguments
        /// using custom verifier.
        /// </summary>
        /// <typeparam name="T">The return type of the method to verify.</typeparam>
        /// <param name="expression">A method returning a value in the form of a Lambda Expression that we want
        /// to verify if was called.</param>
        /// <returns>
        /// An <see cref="TypeMock.ArrangeActAssert.IArgumentsMatcher"/> instance.
        /// </returns>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithArguments`1"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments<T>(Expression<Func<T>> expression)
        {
            return ((Func<Func<T>, global::TypeMock.ArrangeActAssert.IArgumentsMatcher>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithArguments<T>))
                    .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was called, and checking its arguments.
        /// </summary>
        /// <param name="expression">A void method in the form of a Lambda Expression to verify if it was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithExactArguments"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasCalledWithExactArguments(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithExactArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was called, and checking its arguments.
        /// </summary>
        /// <typeparam name="T">The return type of the method to verify.</typeparam>
        /// <param name="expression">A method returning a value in the form of a Lambda Expression that we want
        /// to verify if was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithExactArguments`1"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasCalledWithExactArguments<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithExactArguments<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was not called regardless of parameters.
        /// </summary>
        /// <param name="expression">A void method in the form of a Lambda Expression to verify if it was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasNotCalled"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasNotCalled(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasNotCalled))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        /// <summary>
        /// Verifies that a method was not called regardless of parameters.
        /// </summary>
        /// <typeparam name="T">The return type of the method to verify.</typeparam>
        /// <param name="expression">A method returning a value in the form of a Lambda Expression that we want
        /// to verify if was called.</param>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasNotCalled`1"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        public void WasNotCalled<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasNotCalled<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }
    }
}
