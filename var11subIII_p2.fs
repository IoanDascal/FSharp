(*
    Implement  next C++ function in F#:
int f(int n)
{  
    int c; 
    if (n==0) 
        return 9; 
    else  
    {
        c=f(n/10); 
        if (n%10<c) 
            return n%10; 
        else 
            return c; 
    } 
}   
*)
let rec f n=
    match n with
    | 0 -> 9
    | _ -> let c=f (n/10)
           if n%10<c then 
               n%10
           else 
               c

let res1=f 5
printfn "%i" res1
let res2=f 23159
printfn "%i" res2
           