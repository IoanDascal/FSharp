let ePrim x=
    let rec loop i=
        match i<=x/2 with
        | false -> true
        | true -> match x%i with
                  | 0 -> false
                  | _ -> loop (i+1)
    loop 2

printf "Dati x="
let x=int(System.Console.ReadLine())
let rec calcul x=
    if (ePrim x) then x
        else
            calcul (x+1)
let res=calcul (x+1)
printfn "Cel mai mic numar prim mai mare decat x =%i" res