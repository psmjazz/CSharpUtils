
using System;
using System.Collections;
using System.Collections.Generic;
using PJ.Utils;

using Macro = SampleMacro;
public static class VisulaizeSample
{
    public static void Test()
    {
        Macro.PrintMain("Visualize Sample");
        Macro.PrintSub("Visualize Array");
        int[] array = new int[]{1,2,3,4};
        Console.WriteLine("1d array : " + array.Visualize());
        // > [1, 2, 3, 4]
        int[,] array2d = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}};
        Console.WriteLine("2d array : \n" + array2d.Visualize());
        // > [[1, 2, 3, 4],
        // > [5, 6, 7, 8],
        // > [9, 10, 11, 12]]

        Macro.PrintSub("Visualize List");
        List<int> list = new List<int>(array);
        Console.WriteLine(list.Visualize());
        // > [1, 2, 3, 4]

        Macro.PrintSub("Visualize Stack");
        Stack stack = new Stack(array);
        Console.WriteLine(stack.Visualize());
        // > <=> 4, 3, 2, 1
        stack.Pop();
        Console.WriteLine(stack.Visualize());
        // > <=> 3, 2, 1
        stack.Push(6);
        Console.WriteLine(stack.Visualize());
        // > <=> 6, 3, 2, 1

        Macro.PrintSub("Visualize Queue");
        Queue queue = new Queue(array);
        Console.WriteLine(queue.Visualize());
        // > <= 1, 2, 3, 4 <=
        queue.Enqueue(5);
        Console.WriteLine(queue.Visualize());
        // > <= 1, 2, 3, 4, 5 <=
        queue.Dequeue();
        Console.WriteLine(queue.Visualize());
        // > <= 2, 3, 4, 5 <=

        Macro.PrintSub("Visualize Dictionary");
        Dictionary<string, int> d = new Dictionary<string, int>()
        {
            {"hi", 0},
            {"hello", 100},
            {"bye", 5}
        };
        Console.WriteLine(d.Visualize(pretty: true));
        // > {
        // >     {hi, 0},
        // >     {hello, 100},
        // >     {bye, 5}
        // > }
        Console.WriteLine(d.Visualize());
        // > { {hi, 0}, {hello, 100}, {bye, 5} }
    }
}