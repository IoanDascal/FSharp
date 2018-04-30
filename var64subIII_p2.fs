(*
    Implement in F# next function:
 void f(int i,int j) 
 {
     if(j<=9) 
         f(i,j+1);      
     cout<<i<<’*’<<j<<’=’<<i*j<<endl;
 } 
*)

let rec f i j=
    if j<=9 then f i (j+1)
    printfn "%i*%i=%i" i j (i*j)

let res=f 5 0