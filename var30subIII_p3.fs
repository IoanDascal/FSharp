printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati i="
let i=int(System.Console.ReadLine())
printf "Dati j="
let j=int(System.Console.ReadLine())
let numere=[for i in 1..n do
                yield(printf "v[%i]=" i 
                      int(System.Console.ReadLine()))]
let sumPartial=List.sum numere - List.sum numere.[i-1..j-1]
printfn "%i" sumPartial