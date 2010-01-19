namespace PauloMorgado.TestTools.TypeMock
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using PauloMorgado.TestTools.Linq.Expressions;

    internal static class ExpressionHelpers
    {
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

        public static void Parse(
            this MethodCallExpression methodCallExpression,
            out MethodInfo method,
            out object target,
            out object[] args)
        {
            var shadowMethod = methodCallExpression.Method;

            target = ((BaseShadow)(methodCallExpression.Object.Evaluate())).Target;

            Type targetType = ((PrivateType)(shadowMethod.DeclaringType.InvokeMember("ShadowedType", BindingFlags.Static | BindingFlags.Public | BindingFlags.GetProperty, null, null, null))).ReferencedType;

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
