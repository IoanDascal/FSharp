open System
printf "Dati n="
let n=int(System.Console.ReadLine())
let vector=[for i in 1..n do yield(printf "vec[%i]=" i
                                   int(System.Console.ReadLine()))] 
printfn "Vector: %A" vector
let f a=
    let pare=List.filter (fun x -> x%2=0) a
    printfn "Pare: %A" pare
    if pare.Length=0 then -1
        else 
            let pareR=pare |>List.rev
            let rec nr pareR num=
                match pareR with
                | [] -> num
                | x::xs -> nr xs (num*10+x)
            nr pareR 0
let res=f vector
printfn "Numarul format =%i" res
