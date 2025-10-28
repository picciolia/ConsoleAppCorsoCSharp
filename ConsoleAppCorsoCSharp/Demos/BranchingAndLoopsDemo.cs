using System;

// Branching and Loops demo (C#12, .NET8)
// Official docs:
// - Statement keywords: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/statement-keywords
// - Selection statements: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements
// - Iteration statements: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements
// - Jump statements: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/jump-statements
public static class BranchingAndLoopsDemo
{
 public static void Run()
 {
 Console.WriteLine("\n=== Branching and Loops Demo ===");

 Header("Selection statements: if / else if / else");
 int number =7;
 if (number >10)
 {
 Console.WriteLine("Greater than10");
 }
 else if (number ==10)
 {
 Console.WriteLine("Equal to10");
 }
 else
 {
 Console.WriteLine("Less than10");
 }

 Header("Selection statements: switch");
 string shape = "circle";
 switch (shape)
 {
 case "circle":
 Console.WriteLine("Drawing a circle");
 break;
 case "square":
 Console.WriteLine("Drawing a square");
 break;
 default:
 Console.WriteLine("Unknown shape");
 break;
 }

 Header("Iteration: for");
 for (int i =0; i <5; i++)
 {
 if (i ==2) continue; // skip2
 Console.Write($"{i} ");
 }
 Console.WriteLine();

 Header("Iteration: foreach");
 string[] names = ["Ana", "Bob", "Cat"];
 foreach (var n in names)
 {
 Console.Write($"{n} ");
 }
 Console.WriteLine();

 Header("Iteration: while");
 int w =0;
 while (w <3)
 {
 Console.Write($"{w} ");
 w++;
 }
 Console.WriteLine();

 Header("Iteration: do-while");
 int d =0;
 do
 {
 Console.Write($"{d} ");
 d++;
 } while (d <3);
 Console.WriteLine();

 Header("Jump statements: break / continue");
 int[] nums = [0,1,2,3,4,5];
 foreach (var n in nums)
 {
 if (n ==4) break; // exit loop
 if (n %2 ==0)
 {
 Console.Write($"{n} ");
 continue; // skip rest of iteration
 }
 }
 Console.WriteLine();
 }

 private static void Header(string title) => Console.WriteLine($"\n=== {title} ===");
}
