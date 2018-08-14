(*
     https://www.youtube.com/watch?v=ARJB8eDyxrg
*)


type Result<'a>=
    | Success of 'a*list<char>
    | Failure of string
type Parser<'a> = 
    | Parser of (char list -> Result<'a*char list,string>)
let stringToCharList str=
    List.ofSeq str
let runParser parser inputChars=
    let (Parser parserFunc ) = parser
    parserFunc inputChars
let expectChar expectedChar=
    let innerParser inputChars=
        match inputChars with
        | c::remainingChars -> if c=expectedChar then Success (string c,remainingChars)
                               else Failure (sprintf "Expected %c, got %c" expectedChar c) 
        | [] -> Failure (sprintf "Expected %c, reached end of input" expectedChar)
    innerParser

let orParse parser1 parser2 inputChars=
    match parser1 inputChars with
    | Success (c,remainingChars) -> Success (c,remainingChars)  
    | Failure _-> parser2 inputChars
let ( <|> )=orParse
let choice parserList=
    List.reduce ( <|> ) parserList
let anyCharOf validChars=
    validChars
    |> List.map expectChar
    |> choice


stringToCharList "take" 
|> anyCharOf ['a'..'m']
|> printfn "%A"

let andParse parser1 parser2 inputChars=
    match parser1 inputChars with
    | Failure msg -> Failure msg  
    | Success (c1,remaining1) -> match parser2 remaining1 with
                                 | Failure msg -> Failure msg  
                                 | Success (c2,remaining2) -> Success (c1+c2,remaining2)
let ( .>>. ) = andParse

stringToCharList "legat"
|> (expectChar 'l' .>>. expectChar 'e' .>>. expectChar 'g')
|> printfn "%A"