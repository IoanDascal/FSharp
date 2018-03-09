printf "Dati n="
let n=int(System.Console.ReadLine())
let vector=[|for i in 1..n do
                 yield(printf "v[%i]=" i
                       float(System.Console.ReadLine()))|] 
let suma=Array.sum vector
let medii=[|for i in 0..n-1 do yield((suma-vector.[i])/float(n-1))|]

let res=Array.map2 ( fun x y -> if x=y then x else 0.0) vector medii
let egale=Array.countBy (fun x -> if x<>0.0 then x else 0.0) res
if (fst egale.[0])<>0.0 then printfn "Sunt egale : %i medii"  (snd egale.[0])
    else printfn "Sunt egale : %i medii" (snd egale.[1])
