open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let numere=[for i in 0..n-1 do
                yield ( printf "num[%i]=" i
                        int(System.Console.ReadLine()))]
let cifraUnica x=
    let c=x%10
    let rec cifra nr cif fan=
        match nr with
        | 0 -> fan
        | _ -> match cif=c with
               | true -> cifra (nr/10) (nr%10) fan
               | false -> cifra (nr/10) (nr%10) false
    cifra x (x%10) true 
let res=List.choose (fun x -> match (cifraUnica x) with
                              | true -> Some(x)
                              | false -> None ) numere
printfn "%A" (List.sort res)
