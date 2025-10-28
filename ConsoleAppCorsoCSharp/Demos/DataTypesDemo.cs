using System;

public static class DataTypesDemo
{
 public static void Run()
 {
 // C# Data Types: didactic tour (C#12, .NET8)
 // Selected references (see list after code):
 // - Built-in types
 // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/built-in-types
 // - Value types
 // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-types#built-in-value-types
 // - Reference types and built-in reference types (string, object, dynamic, delegate)
 // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/reference-types
 // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/reference-types
 // - Boxing/Unboxing
 // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/types/boxing-and-unboxing
 // - Value tuples
 // https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/value-tuples
 // - C# type system
 // https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/types/

 Header("Value Types: integral, floating-point, bool, char");
 // Integral numeric types
 int i =42; // System.Int32
 long l =42L; // System.Int64 (suffix L)
 short sh = -10; // System.Int16
 byte by =255; // System.Byte
 sbyte sby = -128; // System.SByte
 uint ui =123u; // System.UInt32 (suffix u)
 ulong ul =123UL; // System.UInt64
 ushort ush =65535; // System.UInt16
 // Native-sized integers (size depends on platform): nint / nuint
 nint native =123;
 nuint unative =123;

 Console.WriteLine($"int: Min={int.MinValue}, Max={int.MaxValue}, Size={sizeof(int)} bytes");
 Console.WriteLine($"long: Min={long.MinValue}, Max={long.MaxValue}, Size={sizeof(long)} bytes");
 Console.WriteLine($"byte: Min={byte.MinValue}, Max={byte.MaxValue}, Size={sizeof(byte)} bytes");

 // Floating-point numeric types and decimal
 float f =3.14159f; // System.Single (suffix f)
 double d =3.14159; // System.Double
 decimal m =3.14159m; // System.Decimal (suffix m) - high precision (financial)
 Console.WriteLine($"float f={f}");
 Console.WriteLine($"double d={d}");
 Console.WriteLine($"decimal m={m}");

 // Special floating-point values
 double posInf =1.0 /0.0;
 double nan =0.0 /0.0;
 Console.WriteLine($"double: +Infinity={double.IsPositiveInfinity(posInf)}, NaN={double.IsNaN(nan)}");

 // bool and char
 bool isReady = true; // System.Boolean
 char letter = 'A'; // System.Char (UTF-16)
 Console.WriteLine($"bool={isReady}, char='{letter}' (U+{(int)letter:X4})");

 Header("Constants and literals");
 // const allowed for simple types
 const int MeaningOfLife =42;
 const decimal VatRate =0.22m;
 Console.WriteLine($"const int={MeaningOfLife}, const decimal={VatRate}");

 Header("Enums");
 // Enums are value types
 Color c = Color.Red;
 Console.WriteLine($"Enum value={c} ({(int)c})");

 Header("Struct vs Class: value-copy vs reference");
 // Struct: copies the data (value semantics)
 Point ps1 = new(1,2);
 Point ps2 = ps1 with { X =99 }; // use 'with' expression to create a copy with X changed
 Console.WriteLine($"struct: ps1=({ps1.X},{ps1.Y}), ps2=({ps2.X},{ps2.Y})");
 // Class: copies the reference (reference semantics)
 Box bc1 = new(1);
 Box bc2 = bc1; // reference to same object
 bc2.Value =99;
 Console.WriteLine($"class: bc1.Value={bc1.Value}, bc2.Value={bc2.Value}");

 Header("Nullable value types");
 // Nullable<T> (T?) allows null for value types
 int? maybe = null;
 Console.WriteLine($"Nullable int? has value? {maybe.HasValue}, value or default={maybe ?? -1}");
 maybe =7;
 Console.WriteLine($"Now has value? {maybe.HasValue}, value={maybe.Value}");

 Header("Tuples (value tuples)");
 // ValueTuples are value types; support names and deconstruction
 var person = (Id:1, Name: "Alice");
 var (id, name) = person;
 Console.WriteLine($"Tuple person: Id={person.Id}, Name={person.Name}; deconstructed -> {id}, {name}");

 Header("Strings (reference type)");
 // string is a reference type with value-based equality and immutability
 string a = "hello";
 string b = "h";
 b += "ello"; // creates new string; 'b' now references a new instance
 Console.WriteLine($"a == b? {a == b} (value equality)"); // True
 Console.WriteLine($"ReferenceEquals(a,b)? {object.ReferenceEquals(a, b)}"); // Likely False
 Console.WriteLine($"Indexing string: a[1]='{a[1]}'");
 string raw = """
 Multi-line
 "raw" string literal
 """;
 Console.WriteLine("Raw string literal:\n" + raw);

 Header("object, boxing and unboxing");
 // Any type ultimately derives from System.Object
 object obj =123; // boxing of int
 int unboxed = (int)obj; // unboxing back to int
 Console.WriteLine($"Boxing/unboxing: obj type={obj.GetType().Name}, unboxed={unboxed}");

 Header("Arrays (reference types)");
 // Arrays are reference types
 int[] data = [1,2,3];
 MutateArray(data);
 Console.WriteLine($"Array after mutation: [{string.Join(", ", data)}]");

 Header("dynamic (runtime binding)");
 // dynamic defers binding to runtime
 dynamic dyn =5;
 dyn = dyn +3; // OK at runtime
 Console.WriteLine($"dynamic result: {dyn} (type at runtime: {dyn.GetType().Name})");

 Header("Delegates (reference types) and lambdas");
 // delegate is a reference type representing a callable signature
 Action<string> printer = Console.WriteLine;
 printer("Hello from delegate!");

 Header("Records (reference types with value-like equality)");
 // Records provide concise syntax and value-based equality
 Person p1 = new("Alice",30);
 Person p2 = p1 with { Age =31 };
 Console.WriteLine($"Record p1={p1}, p2={p2}, p1==p2? {p1 == p2}");
 Person p3 = new("Alice",30);
 Console.WriteLine($"Record equality (p1 vs p3): {p1 == p3} (value-based)");
 }

 // ---------- Helpers and types ----------
 private static void Header(string title)
 {
 Console.WriteLine($"\n=== {title} ===");
 }

 private static void MutateArray(int[] values)
 {
 if (values.Length >0) values[0] =999;
 }

 // Value type (struct)
 public readonly struct Point(int x, int y)
 {
 public int X { get; init; } = x;
 public int Y { get; init; } = y;
 }

 // Reference type (class)
 public class Box
 {
 public int Value { get; set; }
 public Box(int value) => Value = value;
 }

 // Enum (value type)
 public enum Color
 {
 Red =1,
 Green =2,
 Blue =3
 }

 // Record (reference type with value-based equality)
 public record Person(string Name, int Age);
}
