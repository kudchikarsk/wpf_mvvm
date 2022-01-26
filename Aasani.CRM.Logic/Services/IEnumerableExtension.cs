using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Aasani.CRM.Logic
{
    public static class IEnumerableExtension
    {
        public static IEnumerable<T> OrderByName<T>(this IEnumerable<T> @this, string propName)
        {
            ParameterExpression parameterExpression = Expression.Parameter(typeof(T), "contact");
            MemberExpression propertAccessExpression = Expression.Property(parameterExpression, propName);
            var query = Expression.Lambda(propertAccessExpression, parameterExpression).Compile();
            var methods = typeof(Enumerable).GetMethods();
            var orderByMethod = methods.First(m => m.Name == "OrderBy" && m.GetParameters().Length == 2);
            var genericOrderByMethod = orderByMethod.MakeGenericMethod(new[] { typeof(T), propertAccessExpression.Type });
            return (IEnumerable<T>)
                genericOrderByMethod.Invoke(null, new object[] { @this, query });
        }
    }
}
