//  https://en.wikibooks.org/wiki/F_Sharp_Programming/Option_Types
//  https://fsharpforfunandprofit.com/posts/the-option-type/

let isTen=function
    | Some(10) -> true
    | Some(_) -> false
    | None -> false

printfn "isTen (Some(10))=%b" (isTen (Some(10)))
printfn "isTen (Some(11))=%b" (isTen (Some(11)))
printfn "isTen =%b" (isTen None)
let OptionsList=[Some 5;None;Some 8]
let squared (oList:int option list)=
    oList |> List.map (Option.map (fun x -> x*x) )
let squaredSum (oList:int option list)=
    oList |> squared |>List.fold (fun acc x -> match x with
                                               | Some x -> acc+x
                                               | None -> acc ) 0
let result=squared OptionsList
printfn "%A" result
let result1=squaredSum OptionsList
printfn "%i" result1
