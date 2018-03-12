(*
    Implement in F# next function :
int f(int n,int y) 
{ 
    if(n!=0) 
    { 
        y=y+1; 
        return y+f(n-1,y);  
    } 
    else 
        return 0; 
}   
*)
let rec f n y=
    match n with
    | 0 -> 0
    | _ -> y+1+f (n-1) (y+1)

let res=f 3 1
printfn "f=%i" res