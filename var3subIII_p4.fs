open System
printf "Dati a="
let a=int32(System.Console.ReadLine())
//printf "Dati b="
//let b=int32(System.Console.ReadLine())
let rec cif a b nrAparitiiB=
    match a with
    | 0 -> nrAparitiiB
    | _ -> cif (a/10) b (if a%10=b then nrAparitiiB+1 else nrAparitiiB)

let implode (ls:string array)=
    let sb=System.Text.StringBuilder(ls.Length)
    ls |> Array.iter (sb.Append>>ignore)
    sb.ToString()

let frecventa=[for i in 0..9 do yield (cif a i 0)]
printfn "%A" frecventa
let test= List.forall (fun x -> x%2=0) frecventa
if not test then printfn "0"
else
    let res=[|for i in frecventa.Length-1 .. -1 .. 0 do
                  if frecventa.[i] <>0 then
                      for j in 0..frecventa.[i]/2-1 do yield i.ToString()|]
    let revRes=Array.rev res
    let ress=implode res
    let revRess=implode revRes
    let nrCif=revRess.Length
    let nr1=int32(revRess)
    let nr2=int32(ress)
    let rez=nr2*(int32(10.0**float(nrCif)))+nr1
    printfn "%i" rez