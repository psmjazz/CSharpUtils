# CSharpUtils
C# utility functions

## Visualize

Visiblise Collections
- Array : Supports up to 2 dimensional array
- List
- Stack
- Queue
- Dictionary

### 1 dimensional array
```
int[] array = [1, 2, 3, 4];
Console.WriteLine(array.Visualize());
// > [1, 2, 3, 4]
```
### 2 dimensional array
```
int[,] array2d = {{1, 2, 3, 4}, {5, 6, 7, 8}, {9, 10, 11, 12}};
Console.WriteLine(array2d.Visualize());
// > [[1, 2, 3, 4],
// > [5, 6, 7, 8],
// > [9, 10, 11, 12]]
```
### List
```
Console.WriteLine(list.Visualize());
// > [1, 2, 3, 4]
```
### Stack
```
Stack stack = new Stack(array);
Console.WriteLine(stack.Visualize());
// > <=> 4, 3, 2, 1
stack.Pop();
Console.WriteLine(stack.Visualize());
// > <=> 3, 2, 1
stack.Push(6);
Console.WriteLine(stack.Visualize());
// > <=> 6, 3, 2, 1
```
### Queue
```
Queue queue = new Queue(array);
Console.WriteLine(queue.Visualize());
// > <= 1, 2, 3, 4 <=
queue.Enqueue(5);
Console.WriteLine(queue.Visualize());
// > <= 1, 2, 3, 4, 5 <=
queue.Dequeue();
Console.WriteLine(queue.Visualize());
// > <= 2, 3, 4, 5 <=
```
### Dictionary
```
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
```
## MakeSequence
Make Sequene of array.

### MakeSequence(Func<int, T> nthTerm) 
ith element determined by i
- param of nthTerm means index of array.
- nthTerm returns ith element.

```
// fill all elements with -1
intArr.MakeSequence((ith) => -1);
Console.WriteLine(intArr.Visualize());
// > [-1, -1, -1, -1, -1, -1, -1, -1, -1, -1]

// sequence of odd numbers
intArr.MakeSequence((ith) => ith * 2 + 1);
Console.WriteLine(intArr.Visualize());
// > [1, 3, 5, 7, 9, 11, 13, 15, 17, 19]
// 
```
### MakeSequence(Func<int, SubSequence<T>, T> recurrence) 
ith element determined by previous elements.
- first param of recurrence means index of array
- second param of recurrence is subsequence contains 0 to (i - 1)th elements
- recurrence returns ith element.
```
// fibonacci sequence
// determined by (i-1)th and (i-2)th elements
intArr.MakeSequence((ith, sub) => 
{
    if(ith == 0) return 1;
    else if(ith == 1) return 1;
    else return sub.Get(ith - 1) + sub.Get(ith - 2);
});
Console.WriteLine(intArr.Visualize());
// > [1, 1, 2, 3, 5, 8, 13, 21, 34, 55]

// sequence which ith elements repeats 'a' i times
strArr.MakeSequence((ith, sub) => 
{
    if(ith == 0) return "a";
    else return $"{sub.Get(ith-1)}a";
});
Console.WriteLine(strArr.Visualize());
// > [a, aa, aaa, aaaa, aaaaa, aaaaaa, aaaaaaa, aaaaaaaa, aaaaaaaaa, aaaaaaaaaa]

```