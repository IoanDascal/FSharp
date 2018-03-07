/// In the Fibonacci sequence each number is the sum of the previous two numbers.
///If we hold the values of the previous two numbers in accumulating parameters,
/// then we can calculate the next fib number very easy
/// The accumulator variables correspond to fib(n-1) and fib(n-2)

let fib n=
    let rec loop acc1 acc2=function
        | n when n=0I -> acc1
        | n -> loop acc2 (acc1+acc2) (n-1I)
    loop 0I 1I n 

[0I..15I] |> Seq.iter (fun x -> printfn "fib(%O)=%O" x (fib x))