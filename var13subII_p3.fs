let s="abcdefghoid"
let isWovel x e=not (Seq.exists ((=) e) x)
let consoane sir=
    Seq.filter (isWovel "aeiou") sir
let s1=consoane s
printfn "%A" (s1 |> Seq.map string |> String.concat "")