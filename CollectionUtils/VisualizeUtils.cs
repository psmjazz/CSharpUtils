
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PJ.Utils
{
    public static class VisualizeUtils
    {
        public static string Visualize<T>(this T[] array)
        {
            StringBuilder sb = new StringBuilder("[");
            foreach(var e in array)
            {
                sb.Append($"{e}, ");
            }
            sb.Replace(", ", "]", sb.Length-2, 2);
            return sb.ToString();
        }

        public static string Visualize<T>(this T[,] arr)
        {
            int rowCount = arr.GetLength(0);
            int colCount = arr.GetLength(1);
            StringBuilder sb = new StringBuilder("[");

            for(int i = 0; i<rowCount; i++)
            {
                sb.Append("[");
                for(int j = 0; j <colCount; j++)
                {
                    sb.Append($"{arr[i, j]}, ");
                }
                sb.Replace(", ", "],\n", sb.Length-2, 2);
            }
            sb.Replace(",\n", "]", sb.Length-2, 2);

            
            return sb.ToString();
        }

        public static string Visualize<T>(this List<T> list)
        {
            StringBuilder sb = new StringBuilder("[");
            foreach(var e in list)
            {
                sb.Append($"{e}, ");
            }
            sb.Replace(", ", "]", sb.Length-2, 2);
            return sb.ToString();
        }

        public static string Visualize<T>(this Stack<T> stack)
        {
            var sb = new StringBuilder("<=> ");

            foreach(var e in stack)
            {
                sb.Append($"{e}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }
        public static string Visualize(this Stack stack)
        {
            var sb = new StringBuilder("<=> ");

            foreach(var e in stack)
            {
                sb.Append($"{e}, ");
            }
            sb.Remove(sb.Length - 2, 2);
            return sb.ToString();
        }

        public static string Visualize(this Queue queue)
        {
            var sb = new StringBuilder("<= ");
            
            foreach(var e in queue)
            {
                sb.Append($"{e}, ");
            }
            sb.Replace(", ", " <=", sb.Length - 2, 2);
            return sb.ToString();
        } 
        public static string Visualize<T>(this Queue<T> queue)
        {
            var sb = new StringBuilder("<= ");
            
            foreach(var e in queue)
            {
                sb.Append($"{e}, ");
            }
            sb.Replace(", ", " <=", sb.Length - 2, 2);
            return sb.ToString();
        } 

        public static string Visualize<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, bool pretty = false) where TKey : notnull
        {
            string margin = pretty? "\n    " : " "; 
            string replace = pretty? "\n}" : " }";
            var sb = new StringBuilder($"{{{margin}");
            foreach(var kv in dictionary)
            {
                sb.Append($"{{{kv.Key}, {kv.Value}}},{margin}");
            }
            sb.Replace($",{margin}", replace, sb.Length-(margin.Length + 1), margin.Length + 1);

            return sb.ToString();
        }
    }
}