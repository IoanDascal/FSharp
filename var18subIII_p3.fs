open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let vector=[for i in 0..n-1 do yield (printf "v[%i]=" i
                                      float(System.Console.ReadLine()))]
let media=List.average vector
let maiMariCaMedia=List.countBy (fun x -> x>=media) vector
printfn "%A" maiMariCaMedia
let res=match fst maiMariCaMedia.[0] with
        | true -> snd maiMariCaMedia.[0]
        | false -> snd maiMariCaMedia.[1]

printfn "Numarul de valori mai mari sau egale cu media este=%i" res