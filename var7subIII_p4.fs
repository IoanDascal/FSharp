open System
printf "Dati s="
let s=int(System.Console.ReadLine())
let rec sub termen n=       // Varianta recursiva
    match termen>n with
    | true -> match n<5 with
              | true -> termen-1
              | false -> termen/2
    | false -> match termen >=5 with 
               | true -> sub (2*termen) n
               | false -> sub (termen+1) n 

let res=sub 0 s
printfn "rez=%i" res
let rec serie n=
    match n with
    | 0 -> printfn ""
    | _ -> let res=sub 0 n
           printf "%i " res
           serie (n-res)

let afis=serie s