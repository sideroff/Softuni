using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_Custom_LINQ
{
    public static  class Extentions
    {
        //from 07.12.2015 Softuni Excercize
        public static T FirstOrDefault<T>(this IEnumerable<T> colleciton, Predicate<T> condition)
        {
            var value = default(T);
            foreach (var val in colleciton)
            {
                if (condition(val))
                {
                    value = val;
                    break;
                }
            }
            return value;
        }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> newList = new List<T>();
            foreach (var val in collection)
            {
                if (predicate(val))
                {
                    newList.Add(val);
                    continue;
                }
                break;
            }
            return newList;
        }

        public static void ForEachIn<T>(this IEnumerable<T> collection, Action<T> action)
        {
            foreach (var val in collection)
            {
                action(val);
            }
        }

        public static void foreeach<T>(this T[,] array, Action<T> action)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int k = 0; k < array.GetLength(1); k++)
                {
                    action(array[i, k]);
                }
            }
        }

        //from Delegates Homework
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            List<T> newList = new List<T>();
            foreach (var val in collection)
            {
                if (!predicate(val))
                {
                    newList.Add(val);
                    continue;
                }
            }
            return newList;
        }

        public static TSelector NewMax<TSource, TSelector>(this IEnumerable<TSource> source, Func<TSource, TSelector> selector )
        {
            return Enumerable.Max(Enumerable.Select(source, selector));
        }


    }
}
