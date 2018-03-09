let rec F x=
    if x<=1 then x else x+F (x-2)
let res=F 18
printfn "%i" res