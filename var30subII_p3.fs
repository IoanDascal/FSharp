printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())

let matAdiacenta=Array2D.zeroCreate<int> (n+1) (n+1)
printf "Dati numarul de muchii m="
let m=int(System.Console.ReadLine())
printf "Dati nodul radacina r="
let r=int(System.Console.ReadLine())
for i in 1..m do
    printf "Dati x="
    let x=int(System.Console.ReadLine())
    printf "Dati y="
    let y=int(System.Console.ReadLine())
    matAdiacenta.[x,y] <- 1
    matAdiacenta.[y,x] <- 1

let grade=[for i in 1..n do
               yield(Array.sum matAdiacenta.[i,1..n])]
let frunze=List.countBy (fun x -> x=1) grade
let nrFrunze=if (fst frunze.[0]) then (snd frunze.[0])
                 else (snd frunze.[1])
if grade.[r-1]=1 then printfn "Numarul de frunze este : %i" (nrFrunze-1)
    else printfn "Numarul de frunze este : %i" nrFrunze
