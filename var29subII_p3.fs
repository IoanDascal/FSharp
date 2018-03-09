let s="arac"
let res=String.mapi (fun i c -> if i=3 then 't' else c) s
printfn "%s" res