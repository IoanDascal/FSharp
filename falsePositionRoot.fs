(*
    Method for finding roots of an equation
*)

let MAxITER=1000000
let func=(fun x -> x**3.0-x**2.0+2.0)
let falsePosition (f: float -> float) (a:float) (b:float) =
    match (f a)*(f b)>0.0 with
    | true -> None
    | false -> let rec forLoop a b c i=
                   match i<=MAxITER with
                   | false -> Some c
                   | true -> match (f c) with
                             | 0.0 -> Some c
                             | _ -> match (f c)*(f a)<0.0 with
                                    | true -> forLoop a c ((a*(f b)-b*(f a))/((f b)-(f a))) (i+1)
                                    | false -> forLoop c b ((a*(f b)-b*(f a))/((f b)-(f a))) (i+1)
               forLoop a b a 0

let res1=falsePosition func -1.0 30.0
if res1.IsSome then
    printfn "%f" res1.Value
else
    printfn "Wrong a and b"
               