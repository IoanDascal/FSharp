let rec p x=
    printf "%i" x
    match x<>0 with
    | false -> ()
    | true -> p (x/10)
              printf "%i" (x%10)
let res=p 123
printfn ""