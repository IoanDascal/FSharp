(*
    Implement in F# next function:
 int f( int &a, int &b) 
 { 
     while (a !=b) 
         if (a>b) 
             a=a-b; 
         else 
             b=b-a; 
     return a;
 }
*)

let f a b=
    let rec whileLoop a b=
        match a<>b with
        | false -> a,b
        | true -> if a>b then whileLoop (a-b) b
                  else whileLoop a (b-a)
    let a,b=whileLoop a b
    a,b  

let a,b=f 12 18
printfn "%i" a
printfn "%i" b