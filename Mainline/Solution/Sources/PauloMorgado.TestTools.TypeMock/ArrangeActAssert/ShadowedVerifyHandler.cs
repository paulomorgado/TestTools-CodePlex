namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;

    internal class ShadowedVerifyHandler : IVerifyHandler
    {
        public static readonly ShadowedVerifyHandler Instance = new ShadowedVerifyHandler();

        private ShadowedVerifyHandler()
        {
        }

        public void WasNotCalled(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasNotCalled))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public void WasCalledWithAnyArguments(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithAnyArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public void WasCalledWithExactArguments(Expression<Action> expression)
        {
            ((Action<Action>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithExactArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments(Expression<Action> expression)
        {
            return ((Func<Action, global::TypeMock.ArrangeActAssert.IArgumentsMatcher>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithArguments))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public void WasNotCalled<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasNotCalled<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public void WasCalledWithAnyArguments<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithAnyArguments<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public void WasCalledWithExactArguments<T>(Expression<Func<T>> expression)
        {
            ((Action<Func<T>>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithExactArguments<T>))
                .Invoke((MethodCallExpression)(expression.Body));
        }

        public global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments<T>(Expression<Func<T>> expression)
        {
            return ((Func<Func<T>, global::TypeMock.ArrangeActAssert.IArgumentsMatcher>)(global::TypeMock.ArrangeActAssert.Isolate.Verify.WasCalledWithArguments<T>))
                    .Invoke((MethodCallExpression)(expression.Body));
        }
    }
}
