(*
    - Write a function cif:int -> int that returns the frequency of digit b 
in an integer a. 
    - Using function cif write another function that returns the biggest
palindrome number that can be obtained from digits of integer number a with 
eight digits.
*)
open System
printf "Enter a="
let a=int32(Console.ReadLine())
let rec cif a b frequencyB=
    match a with
    | 0 -> frequencyB
    | _ -> cif (a/10) b (if a%10=b then frequencyB+1 else frequencyB)

let implode (ls:string array)=
    let sb=System.Text.StringBuilder(ls.Length)
    ls |> Array.iter (sb.Append>>ignore)
    sb.ToString()

let frequencies=[for i in 0..9 do yield (cif a i 0)]
printfn "%A" frequencies
let test= List.forall (fun x -> x%2=0) frequencies
if not test then printfn "0"
else
    let res=[|for i in frequencies.Length-1 .. -1 .. 0 do
                  if frequencies.[i] <>0 then
                      for j in 0..frequencies.[i]/2-1 do yield i.ToString()|]
    let revRes=Array.rev res
    let ress=implode res
    let revRess=implode revRes
    let nrCif=revRess.Length
    let nr1=int32(revRess)
    let nr2=int32(ress)
    let rez=nr2*(int32(10.0**float(nrCif)))+nr1
    printfn "%i" rez