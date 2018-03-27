let s="abaemeiut"
printfn "%i" s.Length
let n=s.Length
let isWovel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false

let rec elimin i (s:string)=
    match i=n-1 with
    | true -> s
    | false -> match (isWovel s.[i]) with
               | true -> let s=s.Replace(s.[i],' ')
                         elimin (i+2) s
               | false -> elimin (i+2) s

let sir=elimin 0 s
let sir1=sir.Split([|' '|]) |> String.concat ""
printfn "%A" sir1


