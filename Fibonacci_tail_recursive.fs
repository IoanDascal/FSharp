/// In the Fibonacci sequence each number is the sum of the previous two numbers.
///If we hold the values of the previous two numbers in accumulating parameters,
/// then we can calculate the next fib number very easy
/// The accumulator variables correspond to fib(n-1) and fib(n-2)
/// The implementation with accumulators is much faster than the implementation with 
/// continuations

let fibonacciAccumulator n=
    let rec loop acc1 acc2=function
        | n when n=0I -> acc1
        | n -> loop acc2 (acc1+acc2) (n-1I)
    loop 0I 1I n 

printfn "Fibonacci with accumulator"
[0I..40I] |> Seq.iter (fun x -> printfn "fib(%O)=%O" x (fibonacciAccumulator x))

let fibonacciContinuations n=
    let rec loop n cont=
        match n with
        | n when n=0I -> cont 0I
        | n when n=1I -> cont 1I
        | n -> let first x=
                   let second y=
                       cont (x+y)
                   loop (n-2I) second
               loop (n-1I) first
    loop n id

printfn ""
printfn "Fibonacci with continuations "
[0I..40I] |> Seq.iter (fun x -> printfn "fib(%O)=%O" x (fibonacciContinuations x))