let rec f n=
    match n=0 with
    | true -> printfn ""
    |false -> match n%2 with
              | 0 -> printf "%i " n
              | _ -> printf ""
              f (n-1)
              printf "%i " n

let res=f 3