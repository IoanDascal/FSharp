(*
    Implement in F# next C++ function:
void f(long n, int i)
{ 
    if(n!=0)
    if(n%3>0)
    { 
        cout<<i; 
        f(n/3,i+1); 
    }
}
*)
let rec f n i =
    match n with
    | 0 -> ()
    | _ ->  match n%3 with
            | 0 -> () 
            | _ -> printf "%i" i
                   f (n/3) (i+1)
    
let res=f 121 1
