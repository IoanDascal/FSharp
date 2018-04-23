(*
    Implement in F# next C++ function:
 void print (int x,int y)
 {
     cout<<x<<y;
     if(x<y)
     {
         print(x+1,y-1);
         cout<<(x+y)/2;
     }
 }
*)

let rec print x y=
    printf "%i%i" x y
    if x<y then print (x+1) (y-1)
                printf "%i" ((x+y)/2)

let res=print 2 6