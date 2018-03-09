let s= "abcduecda"
printfn "%i" s.Length
let rec elimina i j (sir:string)=
    match i=j with
    | true -> sir
    | false -> match sir.[i]=sir.[j] with
               | true -> let sir=sir.Replace(sir.[i],' ')
                         let sir=sir.Replace(sir.[j],' ')
                         elimina (i+1) (j-1) sir 
               | false -> elimina (i+1) (j-1) sir

let res=elimina 0 (s.Length-1) s 
printfn "%s" res
let res1=res.Split([|' '|]) |>String.concat ""
printfn "%A" res1 