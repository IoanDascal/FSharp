(*
    Implement in F# next C++ function:
 int t (int i, int v[])
 {
     if(i==0) 
         return 0;
     if(v[i]!=v[i-1]) 
         return t(i-1,v);
     return 1;
 }
*)

let v=[|973;51;75;350;350;5|]
let rec t i (v:array<int>)=
    if i=0 then 0 else if v.[i]<>v.[i-1] then t (i-1) v else 1

let res=t 0 v + t 3 v
printfn "%i" res

let res1=t 1 v + t 4 v
printfn "%i" res1

let res2=t 4 v + t 5 v
printfn "%i" res2

let res3=t 3 v + t 4 v
printfn "%i" res3