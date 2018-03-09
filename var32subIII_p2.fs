let rec afis x=
    if x>3 then
        printf "%i" (x-1)
        afis (x/3)
        printf "%i" (x+1)

let res=afis 17
printfn ""