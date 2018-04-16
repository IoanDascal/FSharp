(*
    Implement in F# next C++ function:
 int f(int x,int y) 
 {
      if(x==0)
          return 0;
      else
          if(x%10==y)
              return f(x/10,y)+1;
          else 
              return f(x/10,y);
} 
*)

let rec f x y=
    if x=0 then 0
        else match x%10=y with
             | true -> (f (x/10) y)+1
             | false -> f (x/10) y

let res=f 0 0
printfn "%i" res
let res1=f 525 5
printfn "%i" res1
let res3=f 1676636 6
printfn "%i" res3