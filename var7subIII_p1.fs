(*
    Implement in F# next C++ function:
 void f(long int n)
 { 
     if (n!=0)
     {
         if (n%2 == 0)
             cout<<n%10; 
         f(n/10);
     }
 }
*)

let rec f n=
    match n<>0 with
    | false -> ()
    | true -> if n%2=0 then 
                  printf "%i" (n%10) 
              f (n/10)

let res=f 12345
printfn ""
