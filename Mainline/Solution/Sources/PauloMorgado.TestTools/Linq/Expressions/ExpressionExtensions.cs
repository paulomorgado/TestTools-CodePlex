namespace PauloMorgado.TestTools.Linq.Expressions
{
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extensions for expressions.
    /// </summary>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Gets the <see cref="PropertyInfo" /> of a property access expression.
        /// </summary>
        /// <param name="self">The self.</param>
        /// <returns>The <see cref="PropertyInfo" /> of the property access expression.</returns>
        /// <remarks>The expression must be a property access expression.</remarks>
        public static PropertyInfo GetProperty(this LambdaExpression self)
        {
            return (PropertyInfo)((MemberExpression)(self.Body)).Member;
        }

        /// <summary>
        /// Evaluates the specified expression.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <returns>The result of the evaluation of the expression.</returns>
        public static object Evaluate(this Expression expression)
        {
            object value;

            if (!TryEvaluate(expression, out value))
            {
                // use compile / invoke as a fall-back          
                value = Expression.Lambda(expression).Compile().DynamicInvoke();
            }

            return value;
        }

        /// <summary>
        /// Evaluates the specified expression.
        /// A return value indicates whether the evaluation of the expression succeeded or failed.
        /// </summary>
        /// <param name="expression">The expression to evaluate.</param>
        /// <param name="expression">The result of the evaluation of the expression.</param>
        /// <returns><see langword="true" /> if the expression was evaluated successfully; otherwise, <see langword="false" />.</returns>
        public static bool TryEvaluate(this Expression operation, out object expression)
        {
            if (operation == null)
            {
                // used for static fields, etc   
                expression = null;
                return true;
            }

            switch (operation.NodeType)
            {
                case ExpressionType.Constant:
                    expression = ((ConstantExpression)operation).Value;
                    return true;
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)operation;
                    object target;
                    if (TryEvaluate(me.Expression, out target))
                    { // instance target
                        switch (me.Member.MemberType)
                        {
                            case MemberTypes.Field:
                                expression = ((FieldInfo)me.Member).GetValue(target);
                                return true;
                            case MemberTypes.Property:
                                expression = ((PropertyInfo)me.Member).GetValue(target, null);
                                return true;
                        }
                    }

                    break;
            }

            expression = null;
            return false;
        }
    }
}
