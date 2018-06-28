(*
     Implement in f# next C++ function:
 int sum (int a,int b)
 {
      if (a==0 && b==0) 
          return 0;
      else if (a==0) 
          return 1+sum(a,b-1);
      else 
          return 1+sum(a-1,b);
} 
*)
let rec sum a b=
    if a=0 && b=0 then 0 
        else if a=0 then 1+sum a (b-1)
            else 1+sum (a-1) b 
let res=sum 5 4
printfn "%i" res
