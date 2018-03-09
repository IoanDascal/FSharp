open System
printf "Dati un numar intreg z="
let z=int32(System.Console.ReadLine())
printf "Dati un numar x="
let x=int32(System.Console.ReadLine())
let rec compara x=
    match x with
    | 0 -> None
    | _ -> printf "Dati un numar y="
           let y=int32(System.Console.ReadLine())
           match z<y-x with
           | true -> printfn "%i" (x%10)
           | false -> printfn "%i" (y%10)
           let x=y
           compara x

let res:obj option=compara x