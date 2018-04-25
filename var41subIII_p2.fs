(*
    Implement in F# next C++ function:
 void G(int k)
 {
     int i;
     for(i=1;i<=9;i++)
     {
         p[k]=i;
         if(k<3)
             G(k+1);
         else
             cout<<p[0]<<p[1]<<p[2]<<endl;
     }
 }
*)

let p=Array.zeroCreate 5
let rec G k=
    for i in 1..9 do
        p.[k] <- i
        if k<3 then G (k+1) else printfn "%i%i%i" p.[0] p.[1] p.[2]

let res=G 0