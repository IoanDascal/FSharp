let rec f x y=
    match x=y with
    | true -> 1
    | false -> match x<y with
               | true -> 1+(f (x+1) y)
               | false -> 1+(f (y+1) x)
let res=f 13 4
printfn "%i" res