(*
    Implement in F# next C++ function:
 void divi(long i)
 {
     if(α==0)
         cout<< β;
     else 
         divi(i-1);
 } 
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec divi i=
    if n%i=0 then printfn "%i" i else divi (i-1)

let res= divi (n-1)