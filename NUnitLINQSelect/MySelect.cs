using System;
using System.Collections.Generic;
using System.Text;

namespace MyWhereTest
{
    public class _MySelect
    {
        //public IEnumerable<string> HiSelect(IEnumerable<Person> source, Func<Person, string> selectProp)
        //{
        //    List<string> names = new List<string>();

        //    foreach (var s in source)
        //        names.Add(selectProp(s));

        //    return names;
        //}

        //public IEnumerable<object> HiSelect(IEnumerable<Person> source, Func<Person, object> selectProp)
        //{
        //    List<object> names = new List<object>();

        //    foreach (var s in source)
        //        names.Add(selectProp(s));

        //    return names;
        //}

        public IEnumerable<object> HiSelect<T>(IEnumerable<T> source, Func<T, object> selectProp)
        {
            List<object> objects = new List<object>();

            foreach (var s in source)
                objects.Add(selectProp(s));

            return objects;
        }
    }

    public static class MySelect
    {
        public static IEnumerable<TResult> HiSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selectProp)
        {
            foreach (var s in source)
                yield return selectProp(s);
        }
    }
}
