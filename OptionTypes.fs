(*    
    https://en.wikibooks.org/wiki/F_Sharp_Programming/Option_Types
     An option Type can hold two possible values : Some(x) or None. 
    Option types are frequently used to represent optional values in calculations,
    or to indicate whether a particular computation has succeeded or failed.
*)

let divisionByZero x y=
    match y with
    | 0.0 -> None
    | _ -> Some(x/y)

let res=divisionByZero 10.0 0.0
if res.IsSome then
    printfn "The result of the division is=%f" res.Value
    else  
        printfn "Can't divide by zero"
let res1=divisionByZero 10.0 3.0
let printResult result=
    match result with
    | Some _ -> printfn "The result of the division is=%f" res1.Value
    | None -> printfn "Can't divide by zero"

printResult res1 
