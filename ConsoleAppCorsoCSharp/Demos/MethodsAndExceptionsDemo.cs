using System;

// Methods and Exceptions demo (C#12, .NET8)
// Official docs:
// - Methods & parameters: https://learn.microsoft.com/dotnet/csharp/language-reference/keywords/method-parameters
// - Named/optional args: https://learn.microsoft.com/dotnet/csharp/programming-guide/classes-and-structs/named-and-optional-arguments
// - Exception handling: https://learn.microsoft.com/dotnet/csharp/language-reference/statements/exception-handling-statements
public static class MethodsAndExceptionsDemo
{
 public static void Run()
 {
 Header("Methods: parameters, named & optional, ref/out/in");
 int n =10;
 Increment(ref n); // ref: must be initialized; callee can modify
 Console.WriteLine($"After Increment(ref): n={n}");

 GetCircle(2.0, out double area, out double perimeter); // out: set in callee
 Console.WriteLine($"Circle r=2 -> area={area:F2}, perim={perimeter:F2}");

 int scaled = Scale(5, factor:3); // named + optional parameter (default factor=1)
 Console.WriteLine($"Scale(5, factor:3)={scaled}; Scale(5)={Scale(5)}");

 int sum = SumAll(1,2,3,4); // params
 Console.WriteLine($"SumAll(1,2,3,4)={sum}");

 if (int.TryParse("1640", out int parsed)) // out var pattern
 Console.WriteLine($"TryParse ok: {parsed}");

 int a =7, b =8;
 int ro = ReadOnlySum(in a, in b); // in: pass by readonly reference
 Console.WriteLine($"ReadOnlySum(in {a}, in {b})={ro}");

 Header("Exceptions: try/catch, filters, finally, throw");
 try
 {
 Console.WriteLine($"SafeDivide(10,0) ->");
 Console.WriteLine(SafeDivide(10,0));
 }
 catch (DivideByZeroException ex) when (ex.Message.Contains("denominator")) // filter with 'when'
 {
 Console.WriteLine($"Caught with filter: {ex.Message}");
 }
 finally
 {
 Console.WriteLine("Finally always runs (cleanup).");
 }
 }

 private static void Increment(ref int x) => x++;
 private static void GetCircle(double r, out double area, out double perimeter)
 {
 area = Math.PI * r * r;
 perimeter =2 * Math.PI * r;
 }
 private static int Scale(int value, int factor =1) => value * factor;
 private static int SumAll(params int[] nums)
 {
 int acc =0;
 foreach (var v in nums) acc += v;
 return acc;
 }
 private static int ReadOnlySum(in int x, in int y) => x + y;

 private static int SafeDivide(int numerator, int denominator)
 {
 if (denominator ==0)
 throw new DivideByZeroException("SafeDivide: denominator must be non-zero.");
 return numerator / denominator;
 }

 private static void Header(string title) => Console.WriteLine($"\n=== {title} ===");
}
