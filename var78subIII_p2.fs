(*
    Implement in F# next C++ function:
 long sub(long n)
 {
     if (n!=0)
         if(n%2!=0) 
             return 1+sub(n/10);
         else 
             return sub(n/10);
    else 
        return 0;
} 
*)

let rec sub n=
    match n<>0 with
    | false -> 0
    | true -> match n%2<>0 with
              | true -> 1+sub (n/10)
              | false -> sub (n/10)

let res=sub 123986
printfn "res=%i" res
