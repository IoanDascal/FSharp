(*
    https://fsharpforfunandprofit.com/posts/understanding-parser-combinators/
*)

open System
//     Implementation 1. 
let Parser_A str=
    if String.IsNullOrEmpty str then
        (false,"")
    else if str.[0]='A' then
        let remaining=str.[1..]
        (true,remaining)
    else
        (false,str)

printfn "%A" (Parser_A "ABCV" )
printfn "%A" (Parser_A "UBCV" )

//     Implementation 2.
let pchar (charToMatch,str)=
    if String.IsNullOrEmpty str then
        let msg="No more input"
        (msg,str)
    else
        let first=str.[0]
        if first=charToMatch then
            let remaining=str.[1..]
            let msg=sprintf "Found %c " charToMatch
            (msg,remaining)
        else
            let msg=sprintf "Expecting %c got %c." charToMatch first
            (msg,str)

printfn "%A" (pchar ('a',"abcv"))

//     Implementation 3.

type Result<'a>=
    | Success of 'a
    | Failure of string

let parseChar (charToMatch,str)=
    if String.IsNullOrEmpty str then
        Failure "No more input"
    else 
        let first=str.[0]
        if first=charToMatch then
            let remaining=str.[1..]
            Success (charToMatch,remaining)
        else   
            Failure (sprintf "Expecting %c got %c" charToMatch first)

printfn "%A" (parseChar ('a',"bcvedf"))

//     Implementation 4 a.
let parseCharCurried charToMatch str=
    if String.IsNullOrEmpty str then
        Failure "No more input"
    else 
        let first=str.[0]
        if first=charToMatch then
            let remaining=str.[1..]
            Success (charToMatch,remaining)
        else   
            Failure (sprintf "Expecting %c got %c" charToMatch first)

printfn "%A" (parseCharCurried 'a' "acvedf")

//    Implementation 4 b.

let parseCharCurriedInner charToMatch=
    let innerFn str=
        if String.IsNullOrEmpty str then
            Failure "No more input"
        else 
            let first=str.[0]
            if first=charToMatch then
                let remaining=str.[1..]
                Success (charToMatch,remaining)
            else   
                Failure (sprintf "Expecting %c got %c" charToMatch first)
    innerFn

printfn "%A" (parseCharCurriedInner 'a' "")
let parseA=parseCharCurriedInner 'A'
printfn "%A" (parseA "Absvc")

//    Implementation 5

type Parser<'a>=Parser of (string -> Result<'a*string>)
let parseCharCurriedInnerWrapped charToMatch=
    let innerFn str=
        if String.IsNullOrEmpty str then
            Failure "No more input"
        else 
            let first=str.[0]
            if first=charToMatch then
                let remaining=str.[1..]
                Success (charToMatch,remaining)
            else   
                Failure (sprintf "Expecting %c got %c" charToMatch first)
    Parser innerFn

let run parser input=
    let (Parser innerFn)=parser
    innerFn input
let parseAW=parseCharCurriedInnerWrapped 'A'
printfn "%A" (run parseAW "Bbsvc")

//    "and then"  combinator.
let parseBW=parseCharCurriedInnerWrapped 'B'
let andThen parser1 parser2 =
    let innerFn input =
        // run parser1 with the input
        let result1 = run parser1 input
        
        // test the result for Failure/Success
        match result1 with
        | Failure err -> 
            // return error from parser1
            Failure err  

        | Success (value1,remaining1) -> 
            // run parser2 with the remaining input
            let result2 =  run parser2 remaining1
            
            // test the result for Failure/Success
            match result2 with 
            | Failure err ->
                // return error from parser2 
                Failure err 
            
            | Success (value2,remaining2) -> 
                // combine both values as a pair
                let newValue = (value1,value2)
                // return remaining input after parser2
                Success (newValue,remaining2)

    // return the inner function
    Parser innerFn
let ( .>>. ) = andThen
let parseAthenB=parseAW .>>. parseBW
printfn "   and then    combinator"
printfn "%A" (run parseAthenB "Abcvx")
printfn "%A" (run parseAthenB "zBcvx")
printfn "%A" (run parseAthenB "ABcvx")

//     "or else"  combinator

let orElse parser1 parser2 =
    let innerFn input =
        // run parser1 with the input
        let result1 = run parser1 input

        // test the result for Failure/Success
        match result1 with
        | Success result -> 
            // if success, return the original result
            result1

        | Failure err -> 
            // if failed, run parser2 with the input
            let result2 = run parser2 input

            // return parser2's result
            result2 

    // return the inner function
    Parser innerFn

let ( <|> ) = orElse
let parseAOrElseB=parseAW <|> parseBW
printfn "       or else  combinator"
printfn "%A" (run parseAOrElseB "Cal")
printfn "%A" (run parseAOrElseB "ACal")
printfn "%A" (run parseAOrElseB "Bal")

//           Combining andThen and orElse

let parseAW1 = parseCharCurriedInnerWrapped 'A'   
let parseB = parseCharCurriedInnerWrapped 'B'
let parseC = parseCharCurriedInnerWrapped 'C'
let bOrElseC = parseB <|> parseC
let aAndThenBorC = parseAW1 .>>. bOrElseC
printfn "    Combination of parsers"
printfn "%A" (run aAndThenBorC "ABZ" )
printfn "%A" (run aAndThenBorC "ACZ" )
printfn "%A" (run aAndThenBorC "QBZ" )
printfn "%A" (run aAndThenBorC "AQZ" )

//    choice  and  anyOf

let choice listOfParsers=
    List.reduce ( <|> ) listOfParsers
/// Choose any of a list of characters
let anyOf listOfChars = 
    listOfChars
    |> List.map parseCharCurriedInnerWrapped // convert into parsers
    |> choice
let parseLowercase = 
    anyOf ['a'..'z']

let parseDigit = 
    anyOf ['0'..'9']

printfn "       choice and anyOf"
printfn "%A" (run parseLowercase "aBC" )
printfn "%A" (run parseLowercase "ABC" )
printfn "%A" (run parseDigit "1ABC" )
printfn "%A" (run parseDigit "9ABC" )
printfn "%A" (run parseDigit "|ABC")