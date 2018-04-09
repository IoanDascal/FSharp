(*
    Implement in F# next function:
void f (int x) 
{   
    if(x>0) 
        if(x%4==0) 
        { 
            cout<<’x’;
            f(x-1); 
        } 
        else 
        { 
            f(x/3); 
            cout<<’y’; 
        } 
} 
*)

let rec f x=
    match x>0 with
    | false -> ()
    | true -> match x%4=0 with
              | true -> printf "x"
                        f (x-1)
              | false -> f (x/3)
                         printf "y"

let res=f 26