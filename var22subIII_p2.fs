let rec f c=
    if c>'A' then printf "-";f (char(int(c)-1))
    printf "%c" c
    if c>'A' then printf "=";f (char(int(c)-1))
let res=f 'C'
printfn ""