namespace Fasetto.Word
{
    using System;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        #region Public Methods

        /// <summary>
        /// Compiles an expression and gets the functions return value
        /// </summary>
        /// <typeparam name="T">The type of the return value</typeparam>
        /// <param name="lamba">The <see cref="LambdaExpression"/> to compile.</param>
        /// <returns>The compiled expressions value</returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lamba)
        {
            return lamba.Compile().Invoke();
        }

        /// <summary>
        /// Sets the underlying property's value to the given value from an expression that contains
        /// the property
        /// </summary>
        /// <typeparam name="T">The <see cref="Type"/> of value to set</typeparam>
        /// <param name="lambda">The expression</param>
        /// <param name="value">The value to set the property to</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda, T value)
        {
            //Converts a lambda '()=>some.Property' to 'some.Property' (provided the lambda expression!=null)

            if (!((lambda as LambdaExpression).Body is MemberExpression expression)) return;

            // Get the property information so we can set it accordingly
            var propertyInfo = (PropertyInfo)expression.Member;

            var target = Expression.Lambda(expression.Expression).Compile().DynamicInvoke();

            // Set the property value.
            propertyInfo?.SetValue(target, value);
        }

        #endregion Public Methods
    }
}