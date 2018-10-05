(*
     https://www.youtube.com/watch?v=ARJB8eDyxrg
*)


type Result<'TSuccess,'TFailure>=
    | Success of 'TSuccess
    | Failure of 'TFailure
type Parser<'a> = Parser of (char list -> Result<'a*char list,string>)
let stringToCharList str=
    List.ofSeq str
let runParser parser inputChars=
    let (Parser parserFunc ) = parser
    parserFunc inputChars
let expectChar expectedChar=
    let innerParser inputChars=
        match inputChars with
        | c::remainingChars -> if c=expectedChar then Success (c,remainingChars)
                               else Failure (sprintf "Expected %c, got %c" expectedChar c) 
        | [] -> Failure (sprintf "Expected %c, reached end of input" expectedChar)
    Parser innerParser

let orParse parser1 parser2 =
    let innerParser inputChars=
        match runParser parser1 inputChars with
        | Success result -> Success result 
        | Failure _-> runParser parser2 inputChars
    Parser innerParser
let ( <|> )=orParse
let choice parserList=
    List.reduce ( <|> ) parserList
let anyCharOf validChars=
    validChars
    |> List.map expectChar
    |> choice

(*
stringToCharList "take" 
|> anyCharOf ['a'..'m']
|> printfn "%A"
*)

let andParse parser1 parser2= 
    let innerParser inputChars=
        match runParser parser1 inputChars with
        | Failure msg -> Failure msg  
        | Success (c1,remaining1) -> match runParser parser2 remaining1 with
                                     | Failure msg -> Failure msg  
                                     | Success (c2,remaining2) -> Success ((c1,c2),remaining2)
    Parser innerParser
let ( .>>. ) = andParse
let mapParser mapFunc parser=
    let innerParser inputChars=
        match runParser parser inputChars with
        | Failure msg -> Failure msg  
        | Success (result,remaining) -> Success (mapFunc result,remaining)
    Parser innerParser
let applyParser funcAsParser paramAsParser=
    (funcAsParser .>>. paramAsParser)
    |> mapParser (fun (f,x) -> f x)
let ( <*> ) = applyParser
let returnAsParser result=
    let innerParser inputChars=
        Success (result,inputChars)
    Parser innerParser
let liftToParser2 funcToLift paramAsParser1 paramAsParser2=
    returnAsParser funcToLift <*> paramAsParser1 <*> paramAsParser2

let rec sequenceParsers parserList=
    let cons head rest = head :: rest
    let consAsParser=liftToParser2 cons
    match parserList with
    | [] -> returnAsParser []
    | parser::remainingParsers -> consAsParser parser (sequenceParsers remainingParsers)
let charListAsString chars=
    System.String (List.toArray chars)
let expectString expectedString=
    expectedString
    |> stringToCharList
    |> List.map expectChar
    |> sequenceParsers
    |> mapParser charListAsString

stringToCharList "legat"
|> runParser (expectString "lega")
|> printfn "%A"