(*
    Replace all vowels from a string with '*'
*)
let s="information"
let isVowel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false
let res=String.map (fun x -> if isVowel x then '*' else x) s
printfn "%s" res