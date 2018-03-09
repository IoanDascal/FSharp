printf "Dati numarul de elemente din vector n=" 
let n=int(System.Console.ReadLine())
let x=[for i in 1..n do
           yield(printf "x[%i]=" i
                 float(System.Console.ReadLine()))]
printf "Dati numarul de elemente ce trebuie adunate m="
let m=int(System.Console.ReadLine())
let sumaM (x:float list) n m=
    if m<n then
        let rec loop x m i suma=
            match i<=m with
            | false -> suma
            | true -> let minim=List.min x
                      loop (List.filter (fun x -> x<>minim) x) m (i+1) (suma+minim)
        loop x m 1 0.0
    else    
        List.sum x    

let res = sumaM x n m  
printfn "%f" res   