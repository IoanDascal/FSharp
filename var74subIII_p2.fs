(*
    Implement in F#:
 int Sum(int x)
 {
      if(x == 1 ) return 0;
      if(x%2==0) return Sum(x-1)+(x1)*x;
      return Sum(x-1)-(x-1)*x;
 }
*)

let rec Sum x=
    match x with  
    | 1 -> 0
    | x when x%2=0 -> (x-1)*x+Sum (x-1) 
    | _ -> Sum (x-1)-(x-1)*x

let res1=Sum 3
printfn "res1=%i" res1

let res2=Sum 8
printfn "res2=%i" res2