(*
    Implement in F# next C++ function:
 void f(int n)
 {
      if (n!=0)
     {
          if (n%2==0)
              cout<<n<<’ ’;
          f(n-1);
          cout<<n<<’ ’; 
     }
     else 
         cout<<endl;
 }
*)
let rec f n=
    match n=0 with
    | true -> printfn ""
    |false -> if n%2=0 then
                  printf "%i " n
              f (n-1)
              printf "%i " n

let res=f 3