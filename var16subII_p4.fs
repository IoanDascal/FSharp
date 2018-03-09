let aStr="clasa a-XII - a A"
printfn "A=%i" (int 'A')
printfn "a=%i" (int 'a')
let k=(int 'a')-(int 'A')
printfn "%A" ((int 'b')-k)

let res=String.map System.Char.ToUpper aStr
printfn "res=%s" res
let res1=String.map (fun x -> if (System.Char.IsLower x) then char((int x)-k) else x) aStr
printfn "res1=%s" res1