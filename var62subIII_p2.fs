(*
    Implement in F# next C++ function:
 void f(int n,int &a)
 { 
     int c;
     if(n!=0)
     {
         c=n%10;
         if(a<c) 
             a=c;
         f(n/10,a);
     }
 }  
*)

let rec f n a=
    match n<>0 with
    | false -> a
    | true -> let c=n%10
              let a=if a<c then c else a
              f (n/10) a

let res=f 4962 0
printfn "%i" res
let res1=f 4962 52
printfn "%i" res1
let res2=f 4362 0
printfn "%i" res2
let res3=f 4962 11
printfn "%i" res3       