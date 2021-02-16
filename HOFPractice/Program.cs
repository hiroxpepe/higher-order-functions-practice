
using System;
using System.Collections.Generic;
using System.Linq;

namespace HOFPractice {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
        }
    }

    public static class Extensions {
        public static void Each<TSource>(this IEnumerable<TSource> source, Action<TSource> action) {
            source.ToList().ForEach(action);
        }
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            return source.Select(selector);
        }
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            return source.Where(predicate);
        }
        public static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector){
            return source.OrderBy(keySelector);
        }
        public static TSource Fold<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func) {
            return source.Aggregate(func);
        }
    }
}
