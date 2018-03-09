open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let lista=[]
let rec citeste lista=
    printf "Dati un numar <10000 = "
    let nr=int(System.Console.ReadLine())
    match nr<10000 with
    | true -> citeste (List.append lista [nr])
    | false -> lista

let res=citeste lista
printfn "%A" res
let permutare nn res= 
    let first,second=List.splitAt nn res 
    let final =List.append (List.append first.Tail [first.Head]) second
    final

printfn "permutare=%A" (permutare n res)

let rec inversare n (lst :int List)=
    match n with 
    | 0 -> lst
    | _ -> inversare (n-1) (permutare n lst)

let invers=inversare n res
printfn "%A" invers