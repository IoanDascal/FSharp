(*
     Implement in f# next C++ function:
 int suma (int a,int b)
 {
      if (a==0 && b==0) 
          return 0;
      else if (a==0) 
          return 1+suma(a,b-1);
      else 
          return 1+suma(a-1,b);
} 
*)
let rec suma a b=
    if a=0 && b=0 then 0 
        else if a=0 then 1+suma a (b-1)
            else 1+suma (a-1) b 
let res=suma 5 4
printfn "%i" res
