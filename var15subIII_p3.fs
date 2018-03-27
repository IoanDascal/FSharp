open System
printf "Dati n="
let n=Console.ReadLine() |> int
let rec nrDiv nrDv div x=
    match div<=x with
    | false -> nrDv
    | true -> match x%div with
              | 0 -> nrDiv (nrDv+1) (div+1) x
              | _ -> nrDiv nrDv (div+1) x

let nrDivizori=List.map (fun x -> nrDiv 1 2 x) [2..n]
printfn "Lista divizori : %A" nrDivizori
let maxim=List.max nrDivizori
printfn "maxim=%i" maxim
let index=List.findIndex (fun x -> x=maxim) nrDivizori
printfn "cautat=%i" (index+2)
