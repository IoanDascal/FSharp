let g x=
    if x>9 then (x/10+x%10) else x

let rec f c=
    if c<1 then 1
        else
            g (c+f (c-1))

let res = f 11
printfn "%i" res
let res1 = f 11
printfn "%i" res1
