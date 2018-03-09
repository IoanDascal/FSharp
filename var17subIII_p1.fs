let rec f n=
    match n>9 with
    | false -> ()
    | true -> printf "%i" (n/100)
              f (n/10)

let res=f 12345
printfn ""