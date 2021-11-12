using System;
using System.Collections.Generic;

namespace MyLinqLib
{
  public static class MyLinqExtensions
  {
      #region SelectElement
      
      public static T First<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          foreach (var variable in list)
          {
              if (function == null || function(variable)) return variable;
          }

          return default;
      }
      
      public static T FirstOrDefault<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          foreach (var variable in list)
          {
              if (function != null && function(variable)) return variable;
              if (function == null) return variable;
          }
          return default;
      }
      
      public static T Last<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          return list.Reverse(function).First();
      }
      
      public static T LastOrDefault<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          return list.Reverse(function).FirstOrDefault(function);
      }
      
      public static T Single<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if(function == null || function(variable)) result.Add(variable);
          }

          if (result.Count() > 1) throw InvalidOperationException;
          return result[0];
      }

      public static Exception InvalidOperationException { get; set; }

      public static T SingleOrDefault<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if(function == null || function(variable)) result.Add(variable);
          }

          if (result.Count() > 1) throw InvalidOperationException;
          if (result.Count() == 1) return result[0];
          return default;
      }
      
      public static T ElementAt<T>(this IEnumerable<T> list, int index)
      {
          T result = default;
          int count = 0;
          foreach (var variable in list)
          {
              if (count == index) result = variable;
              count++;
          }
          return result;
      }
      
      public static T ElementAtOrDefault<T>(this IEnumerable<T> list, int index)
      {
          return list.ElementAt(index);
      }
      #endregion

      #region Aggregation
      
      public static int Average(this IEnumerable<int> list)
      {
          int sum = 0;
          foreach (var variable in list)
          {
              sum += variable;
          }

          return sum/list.Count();
      }
      
      public static double Average(this IEnumerable<double> list)
      {
          double sum = 0;
          foreach (var variable in list)
          {
              sum += variable;
          }
          return sum/list.Count();
      }
      
      public static int Average<T>(this IEnumerable<T> list, Func<T,int> function)
      {
          int sum = 0;
          foreach (var variable in list)
          {
              sum += function(variable);
          }

          return sum/list.Count();
      }
      
      public static double Average<T>(this IEnumerable<T> list, Func<T,double> function)
      {
          double sum = 0;
          foreach (var variable in list)
          {
              sum += function(variable);
          }
          return sum/list.Count();
      }
      
      public static int Count<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          int count = 0;
          foreach (var variable in list)
          {
              if (function == null || function(variable)) count++;
          }

          return count;
      }
      
      public static int Sum(this IEnumerable<int> list)
      {
          int sum = 0;
          foreach (var variable in list)
          {
              sum += variable;
          }

          return sum;
      }
      
      public static double Sum(this IEnumerable<double> list)
      {
          double sum = 0;
          foreach (var variable in list)
          {
              sum += variable;
          }
          return sum;
      }
      
      public static int Sum<T>(this IEnumerable<T> list, Func<T, int> function)
      {
          int sum = 0;
          foreach (var variable in list)
          {
              sum += function(variable);
          }

          return sum;
      }
      
      public static double Sum<T>(this IEnumerable<T> list, Func<T, double> function)
      {
          double sum = 0;
          foreach (var variable in list)
          {
              sum += function(variable);
          }
          return sum;
      }
      
      public static int Max(this IEnumerable<int> list)
      {
          int max = Int32.MinValue;
          foreach (var variable in list)
          {
              if (max < variable) max = variable;
          }
          return max;
      }
      
      public static double Max(this IEnumerable<double> list)
      {
          double max = Double.MinValue;
          foreach (var variable in list)
          {
              if (max < variable) max = variable;
          }
          return max;
      }
      
      public static int Max<T>(this IEnumerable<T> list, Func<T, int> function)
      {
          int max = Int32.MinValue;
          foreach (var variable in list)
          {
              if (max < function(variable)) max = function(variable);
          }
          return max;
      }
      
      public static double Max<T>(this IEnumerable<T> list, Func<T, double> function)
      {
          double max = Double.MinValue;
          foreach (var variable in list)
          {
              if (max < function(variable)) max = function(variable);
          }
          return max;
      }
      
      public static int Min(this IEnumerable<int> list)
      {
          int min = Int32.MaxValue;
          foreach (var variable in list)
          {
              if (min > variable) min = variable;
          }
          return min;
      }
      
      public static double Min(this IEnumerable<double> list)
      {
          double min = Double.MaxValue;
          foreach (var variable in list)
          {
              if (min > variable) min = variable;
          }
          return min;
      }
      
      public static int Min<T>(this IEnumerable<T> list, Func<T, int> function)
      {
          int min = Int32.MaxValue;
          foreach (var variable in list)
          {
              if (min > function(variable)) min = function(variable);
          }
          return min;
      }
      
      public static double Min<T>(this IEnumerable<T> list, Func<T, double> function)
      {
          double min = Double.MaxValue;
          foreach (var variable in list)
          {
              if (min > function(variable)) min = function(variable);
          }
          return min;
      }
      #endregion

      #region Filters

      public static List<T> Where<T>(this IEnumerable<T> list, Func<T, bool> function)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if(function(variable)) result.Add(variable);
          }

          return result;
      }
      
      public static List<T> Distinct<T>(this IEnumerable<T> list)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if(!result.Contains(variable)) result.Add(variable);
          }

          return result;
      }
      
      public static List<T> Take<T>(this IEnumerable<T> list, int number)
      {
          var result = new List<T>();
          int count = 0;
          foreach (var variable in list)
          {
              if (count == number) break;
              result.Add(variable);
              count++;
          }

          return result;
      }
      
      public static List<T> TakeWhile<T>(this IEnumerable<T> list, Func<T, bool> function)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if (function(variable)) result.Add(variable);
              else break;
          }
          return result;
      }
      
      public static List<T> Skip<T>(this IEnumerable<T> list, int number)
      {
          var result = new List<T>();
          int count = 0;
          foreach (var variable in list)
          {
              if (count > number) result.Add(variable);
              count++;
          }
          return result;
      }
      
      public static List<T> SkipWhile<T>(this IEnumerable<T> list, Func<T, bool> function)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              if (!function(variable)) result.Add(variable);
          }
          return result;
      }
      
      #endregion

      #region Projizieren
      
      public static List<TResult> Select<TSource,TResult>(this IEnumerable<TSource> list, Func<TSource, TResult> function)
      {
          var result = new List<TResult>();
          foreach (var variable in list)
          {
              result.Add(function(variable));
          }

          return result;
      }
      
      #endregion
      
      public static List<T> OrderBy<T,TKey>(this List<T> list, Func<T, TKey> function)
      {
          list.Sort((a,b) => Comparer<TKey>.Default.Compare(function(a),function(b)));
          return list;
      }
      
      public static List<T> OrderByDescending<T,TKey>(this IEnumerable<T> list, Func<T, TKey> function)
      {
          var result = new List<T>();
          result.AddRange(list);
          result.Reverse();
          return result;
      }
      
      public static List<T> Reverse<T>(this IEnumerable<T> list, Func<T, bool> function = null)
      {
          var result = new List<T>();
          foreach (var variable in list)
          {
              result.Add(variable);
          }

          result.Reverse();
          return result;
      }
  }
}
