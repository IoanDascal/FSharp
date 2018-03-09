open System.IO
(*
printf "Dati n="
let n=int(System.Console.ReadLine())
printf "Dati c="
let c=int(System.Console.ReadLine())
*)
let rec eliminaCifra n c nr p=
    match n with
    | 0 -> nr
    | _ -> match (n%10)=c with
           | true -> eliminaCifra (n/10) c nr p
           | false -> eliminaCifra (n/10) c (nr+(n%10)*p) (p*10)

let citireFisier=
    use input=File.OpenText("nrVar134.txt")
    let sir=input.ReadToEnd()
    let sir=sir.Replace(System.Environment.NewLine," ")
    let sir=sir.Split([|' '|])
    sir

let rec eliminaCifre (numar:int) (lst:int list)=
    match lst with
    | [] -> numar
    | head::tail -> eliminaCifre (eliminaCifra numar head 0 1) tail
let numere=Array.map (fun x -> int(x)) (citireFisier)

let res=Array.choose (fun x -> let x1=eliminaCifre x [1;3;5;7;9]
                               match x>=x1 && x1>0 with
                               | true -> Some(x1)
                               | false -> None) numere
printfn "%A" res
let resString=res |> Array.map (fun x -> string(x)) |> String.concat " "
printfn "ress=%s" resString
File.WriteAllText("nrVar134Rez.txt", resString)