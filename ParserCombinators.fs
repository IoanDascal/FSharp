(*
    http://santialbo.com/blog/2013/03/24/introduction-to-parser-combinators/
*)

type ParserResult<'a>=
    | Success of 'a*list<char>
    | Failure of list<char>
type Parser<'a>=list<char> -> ParserResult<'a>
/// If the stream starts with c, returns Success, otherwise returns Failure
let CharParser (ch:char) :Parser<char>=
    let p stream=
        match stream with
        | x::xs when x=ch -> Success (x,xs)
        | _::xs -> Failure (xs)
        | [] -> Failure []
    p
let explode (s:string)=
    [for c in s -> c]
let listChar1="abxvxcsghsaab" |> explode
let res=listChar1 |> (CharParser 'a')
printfn "%A" res
let listChar2="bxvxcsghsaab" |> explode
let res1=listChar2 |> (CharParser 'a')
printfn "%A" res1
let listChar3="" |> explode
let res2=listChar3 |> (CharParser 'a')
printfn "%A" res2
printfn ""
let rec parseListChar listChar=
    match listChar with
    | [] -> printfn "End"
    | list -> let res=list |> (CharParser 'a')
              printfn "%A" res
              match res with
              | Success (_,b) -> parseListChar b 
              | Failure l -> parseListChar l  
parseListChar listChar1
printfn ""              

///https://en.wikipedia.org/wiki/Higher-order_function
/// If p1 fails uses p2, otherwise returns p1's result
let Either (p1:Parser<'a>) (p2:Parser<'a>):Parser<'a>=
    let p stream=
        match (p1 stream) with
        | Failure _ -> p2 stream
        | res -> res
    p
///Parses any digit character
let DigitParser:Parser<char>=
    ['0'..'9']
    |> List.map CharParser
    |> List.reduce Either
let digit="as54bcbxv" |> explode |> DigitParser
printfn "%A" digit
let digit1="8as54bcbxv" |> explode |> DigitParser
printfn "%A" digit1
/// Applies the function f to the result of p if it succeeds
let Apply (p:Parser<'a>) (f:'a -> 'b) : Parser<'b>=
    let q stream=
        match p stream with
        | Success(x,rest) -> Success(f x,rest)
        | Failure(_::rest)  -> Failure(rest)
        | Failure [] -> Failure []
    q

///Applies p as many times as possible
let rec Many (p:Parser<'a>):Parser<List<'a>>=
    let q stream=
        match p stream with
        | Failure(_) -> Success([],stream)
        | Success(x,rest) -> (Apply (Many p) (fun xs -> x::xs)) rest
    q  
///Parses positive integer numbers
let DigitParserInt=Apply DigitParser (fun c -> (int c)-(int '0'))
let IntegerParser:Parser<int>=
    Apply (Many DigitParserInt) (List.reduce (fun x y -> x*10+y))
let res4="1234saas" |> explode |> IntegerParser
printfn "%A" res4