(*
    Replace all vowels in a string with '*'
*)
let s="informatics is interesting"
printfn "%i  " s.Length
let vowels="aeiou"
let rec replace (s:string) i=
    let s=s.Replace(vowels.[i],'*')
    match i with
    | 0 -> s
    | _ -> replace s (i-1)

let res=replace s (vowels.Length-1)
printfn "%s" res