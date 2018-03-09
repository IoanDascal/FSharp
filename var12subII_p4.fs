let s="informatica"
printf "%i  " s.Length
let vocale="aeiou"
let rec inlocuire (s:string) i=
    let s=s.Replace(vocale.[i],'*')
    match i with
    | 0 -> s
    | _ -> inlocuire s (i-1)

let res=inlocuire s (vocale.Length-1)
printfn "%s" res