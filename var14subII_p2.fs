open System.Collections.Generic
let linkedList=new LinkedList<int>()
printf "Dati numarul de noduri din lista n="
let n=int(System.Console.ReadLine())
for i in 1..n do
    printf "Dati lista[%i]=" i
    let list=linkedList.AddFirst(int(System.Console.ReadLine()))
    list |> ignore

let sumaDiv5= Seq.fold (fun acc x -> match x%5 with
                                     | 0 -> acc+x
                                     | _ -> acc) 0 linkedList
printfn "Suma nr .div cu 5 =%i" sumaDiv5