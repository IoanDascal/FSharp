let s1="informatica"
let ch='a'
let wovvelOut inputString ch=
    let elimina ch=
        String.collect (fun c -> if c=ch then sprintf ""
                                 else sprintf "%c" c) inputString
    let sir=elimina ch
    if sir.Length<> s1.Length then printfn "%s" sir
let wovels="aeiou"
let res=String.iter (fun x -> wovvelOut s1 x) wovels