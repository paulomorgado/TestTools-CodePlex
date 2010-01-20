//-----------------------------------------------------------------------
// <copyright file="ExpressionHelpers.cs"
//      project="PauloMorgado.TestTools.TypeMock"
//      solution="PMTestTools"
//      assembly="PauloMorgado.TestTools.TypeMock"
//      company="Paulo Morgado">
//   Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary>Helpers for expressions.</summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PauloMorgado.TestTools.Linq.Expressions;

    /// <summary>
    /// Helpers for <see cref="T:System.Linq.Expressions.Expression."/>.
    /// </summary>
    internal static class ExpressionHelpers
    {
        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the call to the method.</typeparam>
        /// <typeparam name="TIsolationResult">The type of the isolation operation result.</typeparam>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        /// <returns>The result isolation operation.</returns>
        public static TIsolationResult Invoke<TResult, TIsolationResult>(
          this Func<Func<TResult>, TIsolationResult> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            return isolation(() => (TResult)(method.Invoke(target, args)));
        }

        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <typeparam name="TIsolationResult">The type of the isolation operation result.</typeparam>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        /// <returns>The result isolation operation.</returns>
        public static TIsolationResult Invoke<TIsolationResult>(
          this Func<Action, TIsolationResult> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            return isolation(() => method.Invoke(target, args));
        }

        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <typeparam name="TResult">The type of the result of the call to the method.</typeparam>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        public static void Invoke<TResult>(
          this Action<Func<TResult>> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            isolation(() => (TResult)(method.Invoke(target, args)));
        }

        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        public static void Invoke(
          this Action<Action> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            isolation(() => method.Invoke(target, args));
        }

        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        /// <returns>An <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler" /> interface reference.</returns>
        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler InvokeNonPublic(
          this Func<object, string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            return isolation(target, method.Name);
        }

        /// <summary>
        /// Invokes the specified isolation operation.
        /// </summary>
        /// <param name="isolation">The isolation operation.</param>
        /// <param name="methodCallExpression">The method call expression.</param>
        /// <returns>An <see cref="TypeMock.ArrangeActAssert.INonPublicMethodHandler" /> interface reference.</returns>
        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler InvokeNonPublic(
          this Func<string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler> isolation,
          MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out method, out target, out args);

            return isolation(method.Name);
        }

        /// <summary>
        /// Parses the specified method call expression.
        /// </summary>
        /// <param name="methodCallExpression">The method call expression to parse.</param>
        /// <param name="method">The method information.</param>
        /// <param name="target">The target of the method call.</param>
        /// <param name="args">The arguments of the method call.</param>
        public static void Parse(
            this MethodCallExpression methodCallExpression,
            out MethodInfo method,
            out object target,
            out object[] args)
        {
            var shadowMethod = methodCallExpression.Method;

            target = ((BaseShadow)(methodCallExpression.Object.Evaluate())).Target;

            Type targetType = ((PrivateType)(shadowMethod.DeclaringType.InvokeMember("ShadowedType", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty, null, null, null, CultureInfo.InvariantCulture))).ReferencedType;

            method = targetType.GetMethod(
                shadowMethod.Name,
                BindingFlags.Public | BindingFlags.NonPublic | (shadowMethod.IsStatic ? BindingFlags.Static : BindingFlags.Instance),
                null,
                shadowMethod.CallingConvention,
                shadowMethod.GetParameters().Select(p => p.ParameterType).ToArray(),
                null);

            args = (from arg in methodCallExpression.Arguments select arg.Evaluate()).ToArray();
        }
    }
}
