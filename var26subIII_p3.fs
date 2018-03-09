printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dari k="
let k=int(System.Console.ReadLine())
let lista=[for i in k.. -1 ..1 do yield(n*i)]
printfn "%A" lista
printfn ""
