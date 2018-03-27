open System
printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
let tati=[for i in 1..n do
              yield(printf "tata[%i]=" i
                    int(System.Console.ReadLine()))]
printfn "%A" tati
let tataNod1=tati.[0]
let nrFrati nod=List.fold (fun acc x -> match x=nod with
                                        | true -> (acc+1) 
                                        | false -> acc ) 0 tati

let frati=(nrFrati tataNod1)-1
printfn "%i" frati
