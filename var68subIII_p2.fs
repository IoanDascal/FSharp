(*
    Implement in F# next function:
 void gama(int n) 
 {
     int i; 
     if(n>=3) 
     {
         for(i=3;i<=n;i++)  
             cout<<n<<” ”; 
         gama(n-3); 
     } 
 }
*)

let rec gama n=
    match n>=3 with
    | false -> ()
    | true -> let rec forLoop i=
                  match i<=n with
                  | true -> printf "%i " n 
                            forLoop (i+1)
                  | false -> ()
              forLoop 3
              gama (n-3)

let res=gama 6