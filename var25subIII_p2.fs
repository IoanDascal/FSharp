(*
    Implement in f# next C++ function:
 int f(int n)
 { 
     if (n<=0) 
         return -1;
     if (n%2==0) 
         return 0;
     if (n%3==0) 
         return 0;
     return 1+f(n-10);
} 
*)
let rec f n=
    match n<=0 with
    | true -> -1
    | false -> match n%2=0 with
               | true -> 0
               | false -> match n%3=0 with
                          | true -> 0
                          | false -> 1+(f (n-10))
let res=f 16
printfn "%i" res
let res1=f 47
printfn "%i" res1