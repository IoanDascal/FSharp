(*
    Implement in F# next C++ function:
 void print(int x)
 {
      if (x>3)
      { 
          cout<<x-1;
          print(x/3);
          cout<<x+1;
      }
 }
*)
let rec print x=
    if x>3 then
        printf "%i" (x-1)
        print (x/3)
        printf "%i" (x+1)

let res=print 17
printfn ""