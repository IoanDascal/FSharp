printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati m="
let m=System.Console.ReadLine() |> int
let rec loop (n,m)=
    match n<=m with
    | false -> (n,m)
    | true -> loop (n+1,m-1)
printfn "%A" (loop (n,m))
let rec loop1 (a,b)=
    match b<a with
    | false -> (a,b)
    | true -> loop1 (a-1,b+1)

let res=loop1 (loop (n,m))
printfn "%i" (fst res)