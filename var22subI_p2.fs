open System
printf "Dati n="
let n=abs (int(System.Console.ReadLine()))
(*
let modul n=
    match n<0 with
    | true -> -n 
    | false -> n
let m=modul n
*)
let rec calcul i div m=
    match i<=m/2 with
    | false -> div
    | true -> match m%i with 
              | 0 -> calcul (i+1) i m
              | _ -> calcul (i+1) div m 
let d=calcul 2 1 n
printfn "%i" d 