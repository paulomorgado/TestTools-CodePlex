namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Linq.Expressions;

    public static class IsolateShadowed
    {
        public static global::PauloMorgado.TestTools.TypeMock.ArrangeActAssert.IVerifyHandler Verify
        {
            get { return global::PauloMorgado.TestTools.TypeMock.ArrangeActAssert.ShadowedVerifyHandler.Instance; }
        }

        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler WhenCalled(Expression<Action> expression)
        {
            return ((Func<object, string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler>)(global::TypeMock.ArrangeActAssert.Isolate.NonPublic.WhenCalled))
                .InvokeNonPublic((MethodCallExpression)(expression.Body));
        }

        public static global::TypeMock.ArrangeActAssert.INonPublicMethodHandler WhenCalled<T>(Expression<Func<T>> expression)
        {
            return ((Func<string, global::TypeMock.ArrangeActAssert.INonPublicMethodHandler>)(global::TypeMock.ArrangeActAssert.Isolate.NonPublic.WhenCalled<T>))
                .InvokeNonPublic((MethodCallExpression)(expression.Body));
        }
    }
}
