module TicTacToe
(*
    https://www.youtube.com/watch?v=UwgEggIg0K8
*)

type Letter = 
    | X 
    | O
type Value =
    | Unspecified 
    | Letter of Letter
type OneToFive = 
    | One 
    | Two 
    | Three 
    | Four 
    | Five

type Row = Value*Value*Value*Value*Value
type Board = Row*Row*Row*Row*Row
type Position =
    {
        Column : OneToFive
        Row : OneToFive
    }
type Move =
    {
        At : Position
        Place : Letter
    }

let emptyBoard=
    ((Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
    (Unspecified ,Unspecified, Unspecified, Unspecified, Unspecified), 
    (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
    (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
    (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified))

let select (board: Board) (position: Position) =
    match (board, position) with
    | ((x,_,_,_,_),_,_,_,_), {Row=One; Column=One } -> x
    | ((_,x,_,_,_),_,_,_,_), {Row=One; Column=Two } -> x
    | ((_,_,x,_,_),_,_,_,_), {Row=One; Column=Three } -> x
    | ((_,_,_,x,_),_,_,_,_), {Row=One; Column=Four } -> x
    | ((_,_,_,_,x),_,_,_,_), {Row=One; Column=Five } -> x
    | (_,(x,_,_,_,_),_,_,_), {Row=Two; Column=One } -> x
    | (_,(_,x,_,_,_),_,_,_), {Row=Two; Column=Two } -> x
    | (_,(_,_,x,_,_),_,_,_), {Row=Two; Column=Three } -> x
    | (_,(_,_,_,x,_),_,_,_), {Row=Two; Column=Four } -> x
    | (_,(_,_,_,_,x),_,_,_), {Row=Two; Column=Five } -> x
    | (_,_,(x,_,_,_,_),_,_), {Row=Three; Column=One } -> x
    | (_,_,(_,x,_,_,_),_,_), {Row=Three; Column=Two } -> x
    | (_,_,(_,_,x,_,_),_,_), {Row=Three; Column=Three } -> x
    | (_,_,(_,_,_,x,_),_,_), {Row=Three; Column=Four } -> x
    | (_,_,(_,_,_,_,x),_,_), {Row=Three; Column=Five } -> x
    | (_,_,_,(x,_,_,_,_),_), {Row=Four; Column=One } -> x
    | (_,_,_,(_,x,_,_,_),_), {Row=Four; Column=Two } -> x
    | (_,_,_,(_,_,x,_,_),_), {Row=Four; Column=Three } -> x
    | (_,_,_,(_,_,_,x,_),_), {Row=Four; Column=Four } -> x
    | (_,_,_,(_,_,_,_,x),_), {Row=Four; Column=Five } -> x
    | (_,_,_,_,(x,_,_,_,_)), {Row=Five; Column=One } -> x
    | (_,_,_,_,(_,x,_,_,_)), {Row=Five; Column=Two } -> x
    | (_,_,_,_,(_,_,x,_,_)), {Row=Five; Column=Three } -> x
    | (_,_,_,_,(_,_,_,x,_)), {Row=Five; Column=Four } -> x
    | (_,_,_,_,(_,_,_,_,x)), {Row=Five; Column=Five } -> x

let set cellValue (board: Board) (position: Position) =
    match (board, position) with
    | ((_,v2,v3,v4,v5),r2,r3,r4,r5), {Row=One; Column=One } -> ((cellValue, v2, v3, v4, v5), r2, r3, r4, r5)
    | ((v1,_,v3,v4,v5),r2,r3,r4,r5), {Row=One; Column=Two } -> ((v1, cellValue, v3, v4, v5), r2, r3, r4, r5)
    | ((v1,v2,_,v4,v5),r2,r3,r4,r5), {Row=One; Column=Three } -> ((v1, v2, cellValue, v4, v5), r2, r3, r4, r5)
    | ((v1,v2,v3,_,v5),r2,r3,r4,r5), {Row=One; Column=Four } -> ((v1, v2, v3, cellValue, v5), r2, r3, r4, r5)
    | ((v1,v2,v3,v4,_),r2,r3,r4,r5), {Row=One; Column=Five } -> ((v1, v2, v3, v4, cellValue), r2, r3, r4, r5)
    | (r1,(_,v2,v3,v4,v5),r3,r4,r5), {Row=Two; Column=One } -> (r1, (cellValue, v2, v3, v4, v5), r3, r4, r5)
    | (r1,(v1,_,v3,v4,v5),r3,r4,r5), {Row=Two; Column=Two } -> (r1, (v1, cellValue, v3, v4, v5), r3, r4, r5)
    | (r1,(v1,v2,_,v4,v5),r3,r4,r5), {Row=Two; Column=Three } -> (r1, (v1, v2, cellValue, v4, v5), r3, r4, r5)
    | (r1,(v1,v2,v3,_,v5),r3,r4,r5), {Row=Two; Column=Four } -> (r1, (v1, v2, v3, cellValue, v5), r3, r4, r5)
    | (r1,(v1,v2,v3,v4,_),r3,r4,r5), {Row=Two; Column=Five } -> (r1, (v1, v2, v3, v4, cellValue), r3, r4, r5)
    | (r1,r2,(_,v2,v3,v4,v5),r4,r5), {Row=Three; Column=One } -> (r1, r2, (cellValue, v2, v3, v4, v5), r4, r5)
    | (r1,r2,(v1,_,v3,v4,v5),r4,r5), {Row=Three; Column=Two } -> (r1, r2, (v1, cellValue, v3, v4, v5), r4, r5)
    | (r1,r2,(v1,v2,_,v4,v5),r4,r5), {Row=Three; Column=Three } -> (r1, r2, (v1, v2, cellValue, v4, v5), r4, r5)
    | (r1,r2,(v1,v2,v3,_,v5),r4,r5), {Row=Three; Column=Four } -> (r1, r2, (v1, v2, v3, cellValue, v5), r4, r5)
    | (r1,r2,(v1,v2,v3,v4,_),r4,r5), {Row=Three; Column=Five } -> r1,r2,(v1,v2,v3,v4,cellValue),r4,r5
    | (r1,r2,r3,(_,v2,v3,v4,v5),r5), {Row=Four; Column=One } -> r1,r2,r3,(cellValue,v2,v3,v4,v5),r5
    | (r1,r2,r3,(v1,_,v3,v4,v5),r5), {Row=Four; Column=Two } -> r1,r2,r3,(v1,cellValue,v3,v4,v5),r5
    | (r1,r2,r3,(v1,v2,_,v4,v5),r5), {Row=Four; Column=Three } -> r1,r2,r3,(v1,v2,cellValue,v4,v5),r5
    | (r1,r2,r3,(v1,v2,v3,_,v5),r5), {Row=Four; Column=Four } -> r1,r2,r3,(v1,v2,v3,cellValue,v5),r5
    | (r1,r2,r3,(v1,v2,v3,v4,_),r5), {Row=Four; Column=Five } -> r1,r2,r3,(v1,v2,v3,v4,cellValue),r5
    | (r1,r2,r3,r4,(_,v2,v3,v4,v5)), {Row=Five; Column=One } -> r1,r2,r3,r4,(cellValue,v2,v3,v4,v5)
    | (r1,r2,r3,r4,(v1,_,v3,v4,v5)), {Row=Five; Column=Two } -> r1,r2,r3,r4,(v1,cellValue,v3,v4,v5)
    | (r1,r2,r3,r4,(v1,v2,_,v4,v5)), {Row=Five; Column=Three } -> r1,r2,r3,r4,(v1,v2,cellValue,v4,v5)
    | (r1,r2,r3,r4,(v1,v2,v3,_,v5)), {Row=Five; Column=Four } -> r1,r2,r3,r4,(v1,v2,v3,cellValue,v5)
    | (r1,r2,r3,r4,(v1,v2,v3,v4,_)), {Row=Five; Column=Five } -> r1,r2,r3,r4,(v1,v2,v3,v4,cellValue)

let modify f (board: Board) (position: Position) =
    set (f (select board position)) board position

let placePieceIfCan piece=modify (function | Unspecified -> Letter piece | x -> x )

let makeMove (board : Board) (move : Move ) =
    if select board move.At = Unspecified
    then Some <| placePieceIfCan move.Place board move.At
    else None

let waysToWin =
    [
        {Row=One; Column=One},{Row=One; Column=Two},{Row=One; Column=Three},{Row=One; Column=Four},{Row=One; Column=Five}
        {Row=Two; Column=One},{Row=Two; Column=Two},{Row=Two; Column=Three},{Row=Two; Column=Four},{Row=Two; Column=Five}
        {Row=Three; Column=One},{Row=Three; Column=Two},{Row=Three; Column=Three},{Row=Three; Column=Four},{Row=Three; Column=Five}
        {Row=Four; Column=One},{Row=Four; Column=Two},{Row=Four; Column=Three},{Row=Four; Column=Four},{Row=Four; Column=Five}
        {Row=Five; Column=One},{Row=Five; Column=Two},{Row=Five; Column=Three},{Row=Five; Column=Four},{Row=Five; Column=Five}
        {Row=One; Column=One},{Row=Two; Column=One},{Row=Three; Column=One},{Row=Four; Column=One},{Row=Five; Column=One}
        {Row=One; Column=Two},{Row=Two; Column=Two},{Row=Three; Column=Two},{Row=Four; Column=Two},{Row=Five; Column=Two}
        {Row=One; Column=Three},{Row=Two; Column=Three},{Row=Three; Column=Three},{Row=Four; Column=Three},{Row=Five; Column=Three}
        {Row=One; Column=Four},{Row=Two; Column=Four},{Row=Three; Column=Four},{Row=Four; Column=Four},{Row=Five; Column=Four}
        {Row=One; Column=Five},{Row=Two; Column=Five},{Row=Three; Column=Five},{Row=Four; Column=Five},{Row=Five; Column=Five}
        {Row=One; Column=One},{Row=Two; Column=Two},{Row=Three; Column=Three},{Row=Four; Column=Four},{Row=Five; Column=Five}
        {Row=One; Column=Five},{Row=Two; Column=Four},{Row=Three; Column=Three},{Row=Four; Column=Two},{Row=Five; Column=One}
    ]

let cells =
    [
        for row in [One; Two; Three; Four; Five] do
            for column in [One; Two; Three; Four; Five] do
                yield {Row= row; Column= column}
    ]

let ``map 5`` f (a,b,c,d,e) = f a,f b,f c,f d,f e

let winner (board: Board) =
    let winPaths = List.map (``map 5`` (select board)) waysToWin
    if List.contains (Letter X, Letter X, Letter X, Letter X, Letter X) winPaths
    then Some X
    else if List.contains (Letter O, Letter O, Letter O, Letter O, Letter O) winPaths
    then Some O 
    else None

let slotsRemaining (board: Board) =
    List.exists (( = ) Unspecified << select board) cells

type Outcome =
    | NoneYet
    | Winner of Letter
    | Draw

let outcome (board: Board) =
    match winner board, slotsRemaining board with
    | Some winningLetter, _ -> Winner winningLetter
    | None, false -> Draw
    | _ -> NoneYet

let renderValue = function
    | Unspecified -> " "
    | Letter X -> "X"
    | Letter O -> "O"

let otherPlayer = function
    | X -> O 
    | O -> X 

let render ((a,b,c,d,e),(f,g,h,i,j),(k,l,m,n,o),(p,q,r,s,t),(u,v,x,y,z)) =
    sprintf 
        """%s | %s | %s | %s | %s
--------------------
%s | %s | %s | %s | %s
--------------------
%s | %s | %s | %s | %s
--------------------
%s | %s | %s | %s | %s
--------------------
%s | %s | %s | %s | %s"""
       (renderValue a) (renderValue b) (renderValue c) (renderValue d) (renderValue e)
       (renderValue f) (renderValue g) (renderValue h) (renderValue i) (renderValue j)
       (renderValue k) (renderValue l) (renderValue m) (renderValue n) (renderValue o)
       (renderValue p) (renderValue q) (renderValue r) (renderValue s) (renderValue t)
       (renderValue u) (renderValue v) (renderValue x) (renderValue y) (renderValue z)

type gameState = {Board: Board; WhoseTurn: Letter}

let initialGameState = {Board=emptyBoard; WhoseTurn=X}

let parseOneToFive = function
    | "1" -> Some One
    | "2" -> Some Two
    | "3" -> Some Three
    | "4" -> Some Four
    | "5" -> Some Five
    | _ -> None

let parseMove ( raw: string) =
    match raw.Split [|' '|] with
    | [|r;c|] -> match parseOneToFive r,parseOneToFive c with
                 | Some row,Some column -> Some {Row=row; Column=column}
                 | _ -> None
    | _ -> None

let rec readMoveIO letter =
    match parseMove <| System.Console.ReadLine() with
    | Some position -> {At=position;Place=letter}
    | None -> printfn "Bad Move! Please input row and column numbers"
              readMoveIO letter

let rec nextMoveIO board letter =
    match makeMove board <| readMoveIO letter with
    | Some newBoard -> newBoard
    | _ -> printfn "Bad move! Position is occupied"
           nextMoveIO board letter

let rec playIO {Board=board;WhoseTurn=currentPlayer} =
    printfn "%A turn" currentPlayer
    printfn "%s" (render board)
    printfn ""
    let newBoard=nextMoveIO board currentPlayer
    printfn ""
    match outcome newBoard with
    | Winner letter -> printfn "%A wins!" letter
                       printfn "%s" (render newBoard)
    | Draw -> printfn "It's a draw!"
    | NoneYet -> playIO {Board=newBoard;WhoseTurn=otherPlayer currentPlayer}

playIO initialGameState
