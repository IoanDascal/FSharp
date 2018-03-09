open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let a=[|for i in 0..n-1 do yield (printf "a[%i]=" i
                                  float(System.Console.ReadLine()))|]
let swap (x:float,y:float)=(y,x)
let rec aranjare i j=
    match i<j with
    | true ->match a.[i]<0.0 with
             | true -> aranjare (i+1) j
             | false -> match a.[j]>=0.0 with
                        |true -> aranjare i (j-1)
                        | false -> let schimb=swap (a.[i], a.[j])
                                   a.[i] <- fst schimb
                                   a.[j] <- snd schimb
                                   aranjare (i+1) (j-1)
    | false -> ()

let res=aranjare 0 (n-1)
for i in 0..n-1 do
    printf "%f " a.[i]
printfn ""