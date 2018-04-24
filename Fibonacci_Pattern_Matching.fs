(*    Pattern Matching Syntax

    Pattern matching resembles this:
        match expr with
        | pat1 -> result1
        | pat2 -> result2
        | pat3 when expr2 -> reult3
        | _ -> defaultResult

    Each | defines a condition, the -> means "if the condition is true, return this value..."
    The _ is the default pattern, meaning that it matches anything.
*)
open System
let rec fib n=
    match n with
    | 0 -> 0
    | 1 -> 1
    | _ ->fib (n-1)+fib (n-2)

Console.WriteLine(fib 30)