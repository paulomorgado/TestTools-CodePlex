namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    internal static class ExpressionHelpers
    {
        public static TIsolationResult Invoke<TResult, TIsolationResult>(this Func<Func<TResult>, TIsolationResult> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            return isolation(() => (TResult)(method.Invoke(target, args)));
        }

        public static TIsolationResult Invoke<TIsolationResult>(this Func<Action, TIsolationResult> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            return isolation(() => method.Invoke(target, args));
        }

        public static void Invoke<T>(this Action<Func<T>> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            isolation(() => (T)(method.Invoke(target, args)));
        }

        public static void Invoke(this Action<Action> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            isolation(() => method.Invoke(target, args));
        }

        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler InvokeNonPublic(
            this Func<object, string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            return isolation(target, method.Name);
        }

        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler InvokeNonPublic(
            this Func<string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler> isolation,
            MethodCallExpression methodCallExpression)
        {
            MethodInfo method;
            object target;
            object[] args;
            methodCallExpression.Parse(out  method, out  target, out  args);

            return isolation(method.Name);
        }
    }
}
