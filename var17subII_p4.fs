let s="bacalaureat"
printfn "%i" s.Length
let isWovel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false

let res=String.iter (fun x -> if isWovel x then printf "*" else ()) s