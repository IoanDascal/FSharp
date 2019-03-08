(*
    https://stackoverflow.com/questions/4470366/using-all-cases-of-union-type-f?noredirect=1&lq=1
    https://stackoverflow.com/questions/35537160/parameterizing-extracting-discriminated-union-cases
    https://stackoverflow.com/questions/21559497/create-discriminated-union-case-from-string?rq=1
*)

open System
open Microsoft.FSharp.Reflection
(*
type Health =
    | Healed
    | Damaged
    | Died
    | Revived

let health = Event<Health>()
let pub    = health.Publish
printfn "%A" pub
let only msg pub = pub |> Observable.choose (function
    | x when x = msg -> Some ()
    | _              -> None
)
let healed  = pub |> only Healed
let damaged = pub |> only Damaged
let died    = pub |> only Died
let revived = pub |> only Revived

printfn "%A" healed
*)

type Beverage =
    | Coffee
    | Tea
    | Beer
    static member ToStrings() =
        FSharp.Reflection.FSharpType.GetUnionCases( typeof<Beverage>) |> Array.map (fun info -> info.ToString())
    override self.ToString() =
        sprintf "%A" self

let res=Beverage.ToStrings()
printfn "%A" res

let bev=[Coffee;Tea;Beer]
for b in bev do printfn "%A" b
type Shape =
    | Square
    | Circle
    | Triangle
    | Other
    static member ToStrings() =
        FSharp.Reflection.FSharpType.GetUnionCases( typeof<Shape>) //|> Array.map (fun info -> info.ToString())
    override self.ToString() =
        sprintf "%A" self

let res1=Shape.ToStrings()
printfn "%A" res1


type Color =
    | Black
    | Red
    | Blue
    | Green
    | White
    static member ToStrings() =
        FSharp.Reflection.FSharpType.GetUnionCases( typeof<Color>) |> Array.map (fun info -> info.ToString())
    override self.ToString() =
        sprintf "%A" self
        
let res2=Color.ToStrings()
for r in res2 do
    printfn "%s" r


type ColoredShape = { Shape: Shape; Color: Color }
let shapeCases = Shape.ToStrings()
let colorCases = Color.ToStrings()

let numberOfRows = 5
let numberOfColumns = 3
let boardOfRelevantPossibilities = Array2D.init<ColoredShape> numberOfRows numberOfColumns (fun x y -> {Shape = Other; Color = Black})
printfn "%A" boardOfRelevantPossibilities
let rand = Random()

for shapeCase in shapeCases do
    // No string comparison anymore
    if shapeCase <> "Shape.Other" then
        for colorCase in colorCases do
            let mutable addedToBoard = false

            while not addedToBoard do
                let boardRowIndex = rand.Next(0, numberOfRows)
                let boardColumnIndex = rand.Next(0, numberOfColumns)

                if boardOfRelevantPossibilities.[boardRowIndex,boardColumnIndex].Shape.Equals Shape.Other then
                    addedToBoard <- true
                    // utilizing colorCase and shapeCase to create records to fill array
                    boardOfRelevantPossibilities.[boardRowIndex,boardColumnIndex] <- {Shape = shapeCase; Color = colorCase } 


printfn "%A" boardOfRelevantPossibilities
Console.ReadKey() |> ignore