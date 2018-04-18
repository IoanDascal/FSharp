(*
    Implement in F# next C++ function:
 void f (int x,int y)
 { 
     if (x<y)
     {
         x=x+1;
         f(x,y);
         y=y-1;
         f(x,y);
     }
     else
        cout<<x<<y;
} 
*)

let rec f x y=
    if x<y then
        let x=x+1
        f x y
        let y=y-1
        f x y
    else
        printf "%i%i " x y

let res=f 1 3