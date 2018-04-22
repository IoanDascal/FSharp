(*
    Implement in F# next function:
 void beta(int n) 
 {
     if (n!=1) 
     {
         cout<<n<<” ”; 
         if (n%3==0) 
             beta(n/3); 
         else 
             beta(2*n-1);
     } 
     else 
         cout<<1; 
 } 
*)

let rec beta n=
    match n<>1 with
    | false -> printf "1"
    | true -> printf "%i" n
              match n%3=0 with
              | true -> beta (n/3)
              | false -> beta (2*n-1)

let res=beta 15