(*
    https://fsharpforfunandprofit.com/posts/recipe-part2/
*)

type Result<'TSuccess,'TFailure>=
    | Success of 'TSuccess
    | Failure of 'TFailure
type Request={name:string;email:string}
let validateInput input=
    if input.name="" then Failure "Name must not be blank"
    else if input.email="" then Failure "Email must not be blank"
    else Success input

//   Composition using bind
let bind switchFunction twoTrackInput = 
    match twoTrackInput with
    | Success s -> switchFunction s 
    | Failure f -> Failure f
let validate1 input=
    if input.name="" then Failure "Name must not be blank"
    else Success input
let validate2 input=
    if input.name.Length>50 then Failure "Name must not be longer than 50b chars"
    else Success input
let validate3 input=
    if input.email="" then Failure "Email must not b blank"
    else Success input
let combinedValidation=
    let validate2'=bind validate2
    let validate3'=bind validate3
    validate1 >> validate2' >> validate3'
// test 1
let input1 = {name=""; email=""}
combinedValidation input1 
|> printfn "Result1=%A"

// ==> Result1=Failure "Name must not be blank"

// test 2
let input2 = {name="Alice"; email=""}
combinedValidation input2
|> printfn "Result2=%A"

// ==> Result2=Failure "Email must not be blank"

// test 3
let input3 = {name="Alice"; email="good"}
combinedValidation input3
|> printfn "Result3=%A"

// ==> Result3=Success {name = "Alice"; email = "good";}

let ( >>= ) twoTrackInput switchFunction=
    bind switchFunction twoTrackInput
let combinedValidation1 x=
    x
    |> validate1
    >>= validate2
    >>= validate3

let input4={name="Alien";email="Moon"}
combinedValidation1 input4 |> printfn "Result4=%A"

//     Composition using switch

let ( >=> ) switch1 switch2 x=
    match switch1 x with
    | Success s -> switch2 s
    | Failure f -> Failure f  
let combinedValidation2 =
    validate1
    >=> validate2
    >=> validate3
let input5={name="John";email="newSwitch"}
combinedValidation2 input5 |> printfn "Result5=%A"

//    Converting simple functions

let convertToSwitch f x=
    f x |> Success
let canonicalizeEmail input=
    {input with email=input.email.Trim().ToLower()}
let usecase =
    validate1
    >=> validate2
    >=> validate3
    >=> convertToSwitch canonicalizeEmail
let goodInput = {name="Alice";email="UPPERCASE"}
usecase goodInput |> printfn "Canonicalize good Result =%A"
let badInput = {name=""; email="UPPERCASE "}
usecase badInput
|> printfn "Canonicalize Bad Result = %A"
