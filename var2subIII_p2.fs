(*
    Implement in F# next function:
void f(long n) 
{ 
    cout<<n%10; 
    if(n!=0)  
    { 
        f(n/100); 
        cout<<n%10;
    }  
}
*)

open System
printf " n="
let n=int32(Console.ReadLine())
let rec f (n:int)=
    printf "%d" (n%10)
    match n with
    | 0 -> ()
    | _ -> f (n/100)
           printf "%d" (n%10)

let res=f n 

