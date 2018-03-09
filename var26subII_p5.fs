printf "Dati numarul de linii si coloane n="
let n=int(System.Console.ReadLine())
let matrice=[for i in 0..n-1 do
                 yield([for j in 0..n-1 do
                            yield (printf "mat[%i,%i]=" i j
                                   int(System.Console.ReadLine()))])]
printfn "%A" matrice
let rec produsColoana p linie coloana=
    if linie=n then p
        else produsColoana (p*matrice.[linie].[coloana]) (linie+1) coloana 
let produse=[for i in 0..n-1 do
                 yield( produsColoana 1 0 i)]
printfn "%A" produse
let maximColoana coloana=List.max [for i in 0..n-1 do
                                       yield(matrice.[i].[coloana])]
let maxime=[for i in 0..n-1 do
                yield(maximColoana i)]
printfn "%A" maxime
//       Varianta 1
let isEqualElement lst1 lst2=List.exists2 (fun el1 el2 -> (el1/el2)=el2) lst1 lst2
if not (isEqualElement produse maxime) then printfn "Nu exista"
    else
        let res=List.iter2 (fun x y -> if x/y=y then printf "%i " y) produse maxime
        printfn "" 
        res

//     Varianta 2
let rec intersectie lst1 lst2 acc=
    match (lst1,lst2) with
    | [],[] -> acc
    | [],_ -> acc
    | _,[] -> acc
    | x::xs,y::ys -> match x/y=y with
                     | true -> intersectie xs ys (y::acc)
                     | false -> intersectie xs ys acc

let final=intersectie produse maxime []
printfn "%A" final