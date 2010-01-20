//-----------------------------------------------------------------------
// <copyright file="IVerifyHandler.cs"
//            project="PauloMorgado.TestTools.TypeMock"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools.TypeMock"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>Contains methods for verifying the method calls and checking their arguments.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// Contains methods for verifying the method calls and checking their arguments.
    /// </summary>
    public interface IVerifyHandler
    {
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
        void WasCalledWithAnyArguments(Expression<Action> expression);

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
        void WasCalledWithAnyArguments<T>(Expression<Func<T>> expression);

        /// <summary>
        /// Verifies that a method was called, and checking its arguments using custom verifier.
        /// </summary>
        /// <param name="expression">A void method in the form of a Lambda Expression to verify if it was called.</param>
        /// <returns>
        /// An <see cref="TypeMock.ArrangeActAssert.IArgumentsMatcher" /> instance.
        /// </returns>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithArguments"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments(Expression<Action> expression);

        /// <summary>
        /// Verifies that a method was called, and checking its arguments
        /// using custom verifier.
        /// </summary>
        /// <typeparam name="T">The return type of the method to verify.</typeparam>
        /// <param name="expression">A method returning a value in the form of a Lambda Expression that we want
        /// to verify if was called.</param>
        /// <returns>
        /// An <see cref="TypeMock.ArrangeActAssert.IArgumentsMatcher" /> instance.
        /// </returns>
        /// <remarks>
        /// <see cref="M:TypeMock.ArrangeActAssert.IVerifyHandler.WasCalledWithArguments`1"/>
        /// </remarks>
        /// <exception cref="TypeMock.VerifyException">
        /// Thrown if the method, or chain of methods was called at least once.
        /// </exception>
        global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments<T>(Expression<Func<T>> expression);

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
        void WasCalledWithExactArguments(Expression<Action> expression);

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
        void WasCalledWithExactArguments<T>(Expression<Func<T>> expression);

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
        void WasNotCalled(Expression<Action> expression);

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
        void WasNotCalled<T>(Expression<Func<T>> expression);
    }
}
