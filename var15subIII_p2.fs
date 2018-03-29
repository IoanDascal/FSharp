(*
    Implement in F# next C++ snipet:
 long g(long x)
 {
      if (x>9)
           return (x/10 + x%10);
      else
         return x;
 } 
 long f(int c)
 { 
     if (c<1)
         return 1;
     else
        return g(c+f(c-1));
 }
*)
let g x=
    if x>9  then 
        (x/10+x%10) 
    else 
        x

let rec f c=
    if c<1 then
        1
    else
        g (c+f (c-1))

let res = g 11
printfn "%i" res
let res1 = f 6
printfn "%i" res1
