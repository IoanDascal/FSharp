let rec f1 x=
    if x<=9 then printf "%i" (x+1)
                 f1 (x+2)
                 printf "%i" (x+3)

let res=f1 5
printfn ""