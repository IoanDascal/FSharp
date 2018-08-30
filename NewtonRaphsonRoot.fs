(*
    Find root
*)

let TOLLERANCE=0.00001 |> double
let func :(double -> double)=(fun x -> x**2.0-2.0)
let derivFunc:(double -> double)=(fun x -> 2.0*x)
let rec NewtonRaphson (f:double->double) (df:double->double) (x:double)=
    let d=df x
    let ntX=x-(f x)/d
    if abs (ntX-x)<TOLLERANCE then
        ntX
    else
        NewtonRaphson f df ntX

let res=NewtonRaphson func derivFunc -1.0
printfn "%.10f" res