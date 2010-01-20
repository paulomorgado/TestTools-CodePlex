//-----------------------------------------------------------------------
// <copyright file="ExpressionExtensions.cs"
//            project="PauloMorgado.TestTools"
//            solution="PMTestTools"
//            assembly="PauloMorgado.TestTools"
//            company="Paulo Morgado">
//     Copyright (c) Paulo Morgado. All rights reserved.
// </copyright>
// <author>Paulo Morgado</author>
// <summary></summary>
//-----------------------------------------------------------------------

namespace PauloMorgado.TestTools.Linq.Expressions
{
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// Extensions for expressions.
    /// </summary>
    /// <remarks>Kudos to <see href="http://marcgravell.blogspot.com/">Marc Gravell</see> and his <see href="http://code.google.com/p/protobuf-net/">protobuf-net</see></remarks>
    public static class ExpressionExtensions
    {
        /// <summary>
        /// Gets the <see cref="PropertyInfo" /> of a property access expression.
        /// </summary>
        /// <param name="self">The porperty access expression.</param>
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
        /// <seealso href="http://code.google.com/p/protobuf-net/source/browse/trunk/protobuf-net.Extensions/ServiceModel/Client/ProtoClientExtensions.cs">ProtoClientExtensions.Evaluate</seealso>
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
        /// <param name="result">The result of the evaluation of the expression.</param>
        /// <returns><see langword="true" /> if the expression was evaluated successfully; otherwise, <see langword="false" />.</returns>
        /// <seealso href="http://code.google.com/p/protobuf-net/source/browse/trunk/protobuf-net.Extensions/ServiceModel/Client/ProtoClientExtensions.cs">ProtoClientExtensions.TryEvaluate</seealso>
        public static bool TryEvaluate(this Expression expression, out object result)
        {
            if (expression == null)
            {
                // used for static fields, etc   
                result = null;
                return true;
            }

            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    result = ((ConstantExpression)expression).Value;
                    return true;
                case ExpressionType.MemberAccess:
                    MemberExpression me = (MemberExpression)expression;
                    object target;
                    if (TryEvaluate(me.Expression, out target))
                    { // instance target
                        switch (me.Member.MemberType)
                        {
                            case MemberTypes.Field:
                                result = ((FieldInfo)me.Member).GetValue(target);
                                return true;
                            case MemberTypes.Property:
                                result = ((PropertyInfo)me.Member).GetValue(target, null);
                                return true;
                        }
                    }

                    break;
            }

            result = null;
            return false;
        }
    }
}
