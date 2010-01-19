namespace PauloMorgado.TestTools.TypeMock.ArrangeActAssert
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Linq.Expressions;

    public interface IVerifyHandler
    {
        void WasNotCalled(Expression<Action> expression);
        void WasCalledWithAnyArguments(Expression<Action> expression);
        void WasCalledWithExactArguments(Expression<Action> expression);
        global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments(Expression<Action> expression);
        void WasNotCalled<T>(Expression<Func<T>> expression);
        void WasCalledWithAnyArguments<T>(Expression<Func<T>> expression);
        void WasCalledWithExactArguments<T>(Expression<Func<T>> expression);
        global::TypeMock.ArrangeActAssert.IArgumentsMatcher WasCalledWithArguments<T>(Expression<Func<T>> expression);
    }
}
