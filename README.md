# ConsoleAppCorsoCSharp

C#12 / .NET8 console app with didactic demos of core language features.

## What it shows

- Data types: built-in value and reference types, numeric limits, decimal and floating-point special values, bool, char, constants, enums, arrays, tuples, strings (immutability and equality), boxing/unboxing, dynamic, delegates, records, and a readonly struct with init-only properties updated via with expression.
- Branching and loops: if/else, switch, for, foreach, while, do-while, and jump statements (break, continue).

## Structure

- `ConsoleAppCorsoCSharp/Program.cs` — entry point invoking demos
- `ConsoleAppCorsoCSharp/Demos/DataTypesDemo.cs` — data types tour
- `ConsoleAppCorsoCSharp/Demos/BranchingAndLoopsDemo.cs` — selection, iteration, and jump statements
- `ConsoleAppCorsoCSharp/ConsoleAppCorsoCSharp.csproj` — project file targeting .NET8

## Requirements

- .NET8 SDK

## Run

```bash
cd ConsoleAppCorsoCSharp
 dotnet run
```