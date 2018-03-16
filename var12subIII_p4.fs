(*
    Each number in a list of n integers is a five-digit number.
    Extract from list only numbers with all five digits equals.
    Print them in increasing order.
*)
open System
printf " n="
let n=int(Console.ReadLine())
let numbers=[for i in 0..n-1 do
                yield ( printf "numbers[%i]=" i
                        int(Console.ReadLine()))]
let uniqueDigit x=
    let c=x%10
    let rec digit nr cif=
        match nr with
        | 0 -> true
        | _ -> match cif=c with
               | true -> digit (nr/10) (nr%10)
               | false -> false
    digit x (x%10)
let res=List.choose (fun x -> match (uniqueDigit x) with
                              | true -> Some(x)
                              | false -> None ) numbers
printfn "%A" (List.sort res)
