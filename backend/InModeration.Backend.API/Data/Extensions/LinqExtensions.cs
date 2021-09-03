using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace InModeration.Backend.API.Data.Extensions
{
    public static class LinqExtensions
    {
        public static IQueryable<T> WhereIf<T>(this IQueryable<T> set, bool condition, Expression<Func<T, bool>> predicate) where T : class
        {
            var result = set;
            if (condition)
            {
                result = result.Where(predicate);
            }

            return result;
        }

        public static IQueryable<T> IncludeIf<T>(this IQueryable<T> set, bool condition, string propertyPath) where T : class
        {
            var result = set;
            if (condition)
            {
                result = result.Include(propertyPath);
            }

            return result;
        }
    }
}
