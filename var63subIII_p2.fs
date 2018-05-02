(*
    Implement in F# next function:
 int f(int b,int i) 
 {
     if(i>=1)  
         return f(b,i-1)*b+a[i]; 
     else 
         return 0; 
 } 
*)

let a=[|0;1;2;0|]
let rec f b i=
    match i>=1 with
    | false -> 0
    | true -> f b (i-1)*b+a.[i]

let res=f 2 1
printfn "%i" res
let res1=f 3 3
printfn "%i" res1