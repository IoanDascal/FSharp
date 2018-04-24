(*
   Implement in F# next C++ function:
 int re(int i)
 {
     if (i<9) 
         return 3+re(i+2);
     else if (i==9) 
             return -2;
     else 
         return 1+re(i-1);
 } 
*)

let rec re i=
    match i<9 with
    | true -> 3+re (i+2)
    | false -> match i=9 with
               | true -> -2
               | false -> 1+re (i-1)

let res=re 1
printfn "%i" res
let res1=re 14
printfn "%i" res1