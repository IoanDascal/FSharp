(*
    Implement in F# next C++ function:
 int f(unsigned int n)
 {
     if (n==0) 
         return 0;
     else 
         if(n%2==0)
             return n%10+f(n/10);
     else 
         return f(n/10);
} 
*)

let rec f n=
    match n with
    | 0 -> 0
    | _ -> match n%2 with
           | 0 -> n%10+f (n/10)
           | _ -> f (n/10)

[10..20] |> List.iter (fun x -> printf "%i  " (f x))