open System
printf "Dati numarul de noduri din graf n="
let n=int(System.Console.ReadLine())
let matrice=Array2D.zeroCreate<int> (n+1) (n+1)
printf "Dati numarul de muchii m="
let m=int(System.Console.ReadLine())
for i in 1..m do
    printf "Dati x="
    let x=int(System.Console.ReadLine())
    printf "Dati y="
    let y=int(System.Console.ReadLine())
    matrice.[x,y] <- 1
    matrice.[y,x] <- 1

printfn "Matricea de adiacenta este :"
for i in 1..n do
    for j in 1..n do
        printf "%i " matrice.[i,j]
    printfn ""

let grade=[for i in 1..n do
               yield (Array.sum matrice.[i,*])] 
printfn "grade = %A" grade
let gradMin=List.min grade
printfn "Gradul minim d=%i" gradMin

printfn "Varfurile care au gradul minim sunt :"
List.iteri (fun i x -> if x=gradMin then printf "%i " (i+1) else ()) grade

