printf "Dati x="
let x=double(System.Console.ReadLine())
let y=floor x
let z=round((x-y)*10000000000.0)/10000000000.0
let rec calcul (z:double)=
    printf "%0.15f " z
    match z<>(round z) with
    | false -> z
    | true -> calcul (z*10.0)

let res=calcul z
if y=res then printfn "1"
    else printfn "2"
