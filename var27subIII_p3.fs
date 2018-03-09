let nreal x y=
    let zecimal y=
        if y>=100 then float(y)/1000.0
        else if y>=10 && y<100 then float(y)/100.0
             else float(y)/10.0
    let res=float(x)+(zecimal y)
    res
let nrNou=nreal 12 543
printfn "%0.3f" nrNou
let nrNou1=nreal 12 54
printfn "%0.2f" nrNou1
let nrNou2=nreal 12 5
printfn "%0.1f" nrNou2