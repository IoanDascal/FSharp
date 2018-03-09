open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let x=[for i in 1..n do
           yield (printf "x[%i]=" i
                  int(System.Console.ReadLine()))]
printfn "%A" x
let pRes=
    let p (x:int list)=
        let suma=List.sum x
        let maxi=List.max x
        let mini=List.min x
        ((maxi,mini),suma)
    p x
printfn "%A" pRes 
let media=floor(float((snd pRes)-(fst (fst pRes))-(snd (fst pRes)))/float(x.Length-2)*1000.0)
printfn "%.3f" (media/1000.0)

