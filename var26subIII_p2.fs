(*
    Implement in F# next C++ function:
 void print (int n)
 {
     cout<<n;
     for (int i=n/2;i>=1;i--)
         if(n%i==0)
             print(i);
 } 
*)

let rec print n=
    printf "%i"  n  
    let rec forLoop i=
        match i>=1 with  
        | false -> ()
        | true -> if n%i=0 then print i
                  forLoop  (i-1)
    forLoop (n/2)

let res=print 8