
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
            foreach (var _item in source.ToList()) {
                action(_item);
            }
        }
        public static IEnumerable<TResult> Map<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector) {
            foreach (var _item in source) {
                yield return selector(_item);
            }
        }
        public static IEnumerable<TSource> Filter<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate) {
            foreach (var _item in source) {
                if (predicate(_item)) {
                    yield return _item;
                }
            }
        }
        public static IOrderedEnumerable<TSource> Sort<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector){
            return source.OrderBy(keySelector);
        }
        public static TSource Fold<TSource>(this IEnumerable<TSource> source, Func<TSource, TSource, TSource> func) {
            IEnumerator<TSource> _e = source.GetEnumerator();
            _e.MoveNext();
            TSource _result = _e.Current;
            while (_e.MoveNext()) {
                _result = func(_result, _e.Current);
            }
            return _result;
        }
    }
}
