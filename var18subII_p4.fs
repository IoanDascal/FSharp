let s="informatica"
let isWovel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false
let res=String.map (fun x -> if isWovel x then '*' else x) s
printfn "%s" res