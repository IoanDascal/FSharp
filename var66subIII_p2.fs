(*
    Implement in F# next function:
 int func(int x) 
 { 
     if (x<=0) 
         return 3 ; 
     else 
         return func(x-3)*4 ; 
 } 
*)

let rec func x=
    match x<=0 with
    | true -> 3
    | false -> func (x-3)*4

let res=func 10
printfn "%i" res