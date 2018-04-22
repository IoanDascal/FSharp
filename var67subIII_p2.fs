(*
    Implement in F# next function:
 int alfa(int u) 
 {
     if (u==0) 
         return 3; 
     else 
         return alfa(u-1)+3*u-2; 
 }
*)

let rec alfa u=
    match u=0 with
    | true -> 3
    | false -> alfa (u-1)+3*u-2

let res=alfa 6
printfn "%i" res