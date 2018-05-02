(*
    The bisection method is used for finding the roots of an eequation.
*)

let rec bisection (f:float->float) (a:float) (b:float) (tolerance:float)=
    match (f a)*(f b)>0.0 with
    | true -> None
    | false -> let middle=(a+b)/2.0
               match abs(middle-b)<=tolerance with
               | true -> Some middle
               | false -> match (f a)*(f middle)>0.0 with
                          | true -> bisection f middle b tolerance
                          | false -> bisection f a middle tolerance

let func=(fun x -> x*x-8.0*x+15.0)
let root1=bisection func 0.0 5.0 0.001
if root1.IsSome then 
     printfn "%f" root1.Value
else
    printfn "Not right values for a and b"
let root2=bisection func 0.0 -5.0 0.001
if root2.IsSome then
    printfn "%f" root2.Value
else
    printfn "Not right values for a and b"