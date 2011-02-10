using System;
using System.Collections.Generic;

namespace nothinbutdotnetstore.core
{
    public static class EnumerableExtensions
    {
        public static ReturnType get_result_of_visit_all_items_with<T,ReturnType>(this IEnumerable<T> items, ValueReturningVisitior<T,ReturnType> visitor)
        {
            visit_all_items_with(items, visitor);
            return visitor.get_result();
        }

        public static void visit_all_items_with<T>(this IEnumerable<T> items, Visitor<T> visitor)
        {
            for_each(items, visitor.process);
        }

        public static void for_each<T>(this IEnumerable<T> items, Action<T> visitor)
        {
            foreach (var item in items) visitor(item);
        }
    }
}