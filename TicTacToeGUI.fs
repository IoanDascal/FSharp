
(*
    https://www.youtube.com/watch?v=UwgEggIg0K8
    https://docs.microsoft.com/en-us/dotnet/fsharp/language-reference/members/events
    https://blogs.msdn.microsoft.com/dsyme/2006/03/23/f-first-class-events-simplicity-and-compositionality-in-imperative-reactive-programming/
    https://stackoverflow.com/questions/15253829/drawing-in-a-windows-form-in-f
    http://fsharpchess.blogspot.com/2014/07/f-with-winforms.html
*)


type Letter = 
    | X 
    | O
type Value =
    | Unspecified 
    | Letter of Letter
type ZeroToSix = 
    | Zero
    | One 
    | Two 
    | Three 
    | Four 
    | Five
    | Six

type Row = Value*Value*Value*Value*Value*Value*Value
type Board = Row*Row*Row*Row*Row*Row*Row
type Position =
    {
        Column : ZeroToSix
        Row : ZeroToSix
    }
type Move =
    {
        At : Position
        Place : Letter
    }

let emptyBoard=
    ((Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified ,Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified), 
     (Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified, Unspecified))

let select (board: Board) (position: Position) =
    match (board, position) with
    | ((x,_,_,_,_,_,_),_,_,_,_,_,_), {Row=Zero; Column=Zero } -> x
    | ((_,x,_,_,_,_,_),_,_,_,_,_,_), {Row=Zero; Column=One } -> x
    | ((_,_,x,_,_,_,_),_,_,_,_,_,_), {Row=Zero; Column=Two } -> x
    | ((_,_,_,x,_,_,_),_,_,_,_,_,_), {Row=Zero; Column=Three } -> x
    | ((_,_,_,_,x,_,_),_,_,_,_,_,_), {Row=Zero; Column=Four } -> x
    | ((_,_,_,_,_,x,_),_,_,_,_,_,_), {Row=Zero; Column=Five } -> x
    | ((_,_,_,_,_,_,x),_,_,_,_,_,_), {Row=Zero; Column=Six } -> x
    | (_,(x,_,_,_,_,_,_),_,_,_,_,_), {Row=One; Column=Zero } -> x
    | (_,(_,x,_,_,_,_,_),_,_,_,_,_), {Row=One; Column=One } -> x
    | (_,(_,_,x,_,_,_,_),_,_,_,_,_), {Row=One; Column=Two } -> x
    | (_,(_,_,_,x,_,_,_),_,_,_,_,_), {Row=One; Column=Three } -> x
    | (_,(_,_,_,_,x,_,_),_,_,_,_,_), {Row=One; Column=Four } -> x
    | (_,(_,_,_,_,_,x,_),_,_,_,_,_), {Row=One; Column=Five } -> x
    | (_,(_,_,_,_,_,_,x),_,_,_,_,_), {Row=One; Column=Six } -> x
    | (_,_,(x,_,_,_,_,_,_),_,_,_,_), {Row=Two; Column=Zero } -> x
    | (_,_,(_,x,_,_,_,_,_),_,_,_,_), {Row=Two; Column=One } -> x
    | (_,_,(_,_,x,_,_,_,_),_,_,_,_), {Row=Two; Column=Two } -> x
    | (_,_,(_,_,_,x,_,_,_),_,_,_,_), {Row=Two; Column=Three } -> x
    | (_,_,(_,_,_,_,x,_,_),_,_,_,_), {Row=Two; Column=Four } -> x
    | (_,_,(_,_,_,_,_,x,_),_,_,_,_), {Row=Two; Column=Five } -> x
    | (_,_,(_,_,_,_,_,_,x),_,_,_,_), {Row=Two; Column=Six } -> x
    | (_,_,_,(x,_,_,_,_,_,_),_,_,_), {Row=Three; Column=Zero } -> x
    | (_,_,_,(_,x,_,_,_,_,_),_,_,_), {Row=Three; Column=One } -> x
    | (_,_,_,(_,_,x,_,_,_,_),_,_,_), {Row=Three; Column=Two } -> x
    | (_,_,_,(_,_,_,x,_,_,_),_,_,_), {Row=Three; Column=Three } -> x
    | (_,_,_,(_,_,_,_,x,_,_),_,_,_), {Row=Three; Column=Four } -> x
    | (_,_,_,(_,_,_,_,_,x,_),_,_,_), {Row=Three; Column=Five } -> x
    | (_,_,_,(_,_,_,_,_,_,x),_,_,_), {Row=Three; Column=Six } -> x
    | (_,_,_,_,(x,_,_,_,_,_,_),_,_), {Row=Four; Column=Zero } -> x
    | (_,_,_,_,(_,x,_,_,_,_,_),_,_), {Row=Four; Column=One } -> x
    | (_,_,_,_,(_,_,x,_,_,_,_),_,_), {Row=Four; Column=Two } -> x
    | (_,_,_,_,(_,_,_,x,_,_,_),_,_), {Row=Four; Column=Three } -> x
    | (_,_,_,_,(_,_,_,_,x,_,_),_,_), {Row=Four; Column=Four } -> x
    | (_,_,_,_,(_,_,_,_,_,x,_),_,_), {Row=Four; Column=Five } -> x
    | (_,_,_,_,(_,_,_,_,_,_,x),_,_), {Row=Four; Column=Six } -> x
    | (_,_,_,_,_,(x,_,_,_,_,_,_),_), {Row=Five; Column=Zero } -> x
    | (_,_,_,_,_,(_,x,_,_,_,_,_),_), {Row=Five; Column=One } -> x
    | (_,_,_,_,_,(_,_,x,_,_,_,_),_), {Row=Five; Column=Two } -> x
    | (_,_,_,_,_,(_,_,_,x,_,_,_),_), {Row=Five; Column=Three } -> x
    | (_,_,_,_,_,(_,_,_,_,x,_,_),_), {Row=Five; Column=Four } -> x
    | (_,_,_,_,_,(_,_,_,_,_,x,_),_), {Row=Five; Column=Five } -> x
    | (_,_,_,_,_,(_,_,_,_,_,_,x),_), {Row=Five; Column=Six } -> x
    | (_,_,_,_,_,_,(x,_,_,_,_,_,_)), {Row=Six; Column=Zero } -> x
    | (_,_,_,_,_,_,(_,x,_,_,_,_,_)), {Row=Six; Column=One } -> x
    | (_,_,_,_,_,_,(_,_,x,_,_,_,_)), {Row=Six; Column=Two } -> x
    | (_,_,_,_,_,_,(_,_,_,x,_,_,_)), {Row=Six; Column=Three } -> x
    | (_,_,_,_,_,_,(_,_,_,_,x,_,_)), {Row=Six; Column=Four } -> x
    | (_,_,_,_,_,_,(_,_,_,_,_,x,_)), {Row=Six; Column=Five } -> x
    | (_,_,_,_,_,_,(_,_,_,_,_,_,x)), {Row=Six; Column=Six } -> x

let set cellValue (board: Board) (position: Position) =
    match (board, position) with
    | (v0,v1,v2,v3,v4,v5,v6), {Row=Zero; Column= _} -> (v0, v1, v2, v3, v4, v5, v6)
    | (r0,r1,r2,r3,r4,r5,r6), {Row=_; Column=Six} -> (r0, r1, r2, r3, r4, r5, r6)
    | (v0,v1,v2,v3,v4,v5,v6), {Row=Six; Column=_} -> (v0, v1, v2, v3, v4, v5, v6)
    | (r0,r1,r2,r3,r4,r5,r6), {Row=_; Column=Zero} -> (r0, r1, r2, r3, r4, r5, r6)
    | (r0,(v0,_,v2,v3,v4,v5,v6),r2,r3,r4,r5,r6), {Row=One; Column=One } -> (r0, (v0, cellValue, v2, v3, v4, v5, v6), r2, r3, r4, r5, r6)
    | (r0,(v0,v1,_,v3,v4,v5,v6),r2,r3,r4,r5,r6), {Row=One; Column=Two } -> (r0, (v0, v1, cellValue, v3, v4, v5, v6), r2, r3, r4, r5, r6)
    | (r0,(v0,v1,v2,_,v4,v5,v6),r2,r3,r4,r5,r6), {Row=One; Column=Three } -> (r0, (v0, v1, v2, cellValue, v4, v5, v6), r2, r3, r4, r5, r6)
    | (r0,(v0,v1,v2,v3,_,v5,v6),r2,r3,r4,r5,r6), {Row=One; Column=Four } -> (r0, (v0, v1, v2, v3, cellValue, v5, v6), r2, r3, r4, r5, r6)
    | (r0,(v0,v1,v2,v3,v4,_,v6),r2,r3,r4,r5,r6), {Row=One; Column=Five } -> (r0, (v0, v1, v2, v3, v4, cellValue, v6), r2, r3, r4, r5, r6)
    | (r0,r1,(v0,_,v2,v3,v4,v5,v6),r3,r4,r5,r6), {Row=Two; Column=One } -> (r0, r1, (v0, cellValue, v2, v3, v4, v5, v6), r3, r4, r5, r6)
    | (r0,r1,(v0,v1,_,v3,v4,v5,v6),r3,r4,r5,r6), {Row=Two; Column=Two } -> (r0, r1, (v0, v1, cellValue, v3, v4, v5, v6), r3, r4, r5, r6)
    | (r0,r1,(v0,v1,v2,_,v4,v5,v6),r3,r4,r5,r6), {Row=Two; Column=Three } -> (r0, r1, (v0, v1, v2, cellValue, v4, v5, v6), r3, r4, r5, r6)
    | (r0,r1,(v0,v1,v2,v3,_,v5,v6),r3,r4,r5,r6), {Row=Two; Column=Four } -> (r0, r1, (v0, v1, v2, v3, cellValue, v5, v6), r3, r4, r5, r6)
    | (r0, r1,(v0,v1,v2,v3,v4,_,v6),r3,r4,r5,r6), {Row=Two; Column=Five } -> (r0, r1, (v0, v1, v2, v3, v4, cellValue, v6), r3, r4, r5, r6)
    | (r0,r1,r2,(v0,_,v2,v3,v4,v5,v6),r4,r5,r6), {Row=Three; Column=One } -> (r0, r1, r2, (v0, cellValue, v2, v3, v4, v5, v6), r4, r5, r6)
    | (r0,r1,r2,(v0,v1,_,v3,v4,v5,v6),r4,r5,r6), {Row=Three; Column=Two } -> (r0, r1, r2, (v0, v1, cellValue, v3, v4, v5, v6), r4, r5, r6)
    | (r0,r1,r2,(v0,v1,v2,_,v4,v5,v6),r4,r5,r6), {Row=Three; Column=Three } -> (r0, r1, r2, (v0, v1, v2, cellValue, v4, v5, v6), r4, r5, r6)
    | (r0,r1,r2,(v0,v1,v2,v3,_,v5,v6),r4,r5,r6), {Row=Three; Column=Four } -> (r0, r1, r2, (v0, v1, v2, v3, cellValue, v5, v6), r4, r5, r6)
    | (r0,r1,r2,(v0,v1,v2,v3,v4,_,v6),r4,r5,r6), {Row=Three; Column=Five } -> (r0, r1, r2, (v0, v1, v2, v3, v4, cellValue, v6), r4, r5, r6)
    | (r0,r1,r2,r3,(v0,_,v2,v3,v4,v5,v6),r5,r6), {Row=Four; Column=One } -> (r0, r1, r2, r3, (v0, cellValue, v2, v3, v4, v5, v6), r5, r6)
    | (r0,r1,r2,r3,(v0,v1,_,v3,v4,v5,v6),r5,r6), {Row=Four; Column=Two } -> (r0, r1, r2, r3, (v0, v1, cellValue, v3, v4, v5, v6), r5, r6)
    | (r0,r1,r2,r3,(v0,v1,v2,_,v4,v5,v6),r5,r6), {Row=Four; Column=Three } -> (r0, r1, r2, r3, (v0, v1 ,v2 , cellValue, v4, v5, v6), r5, r6)
    | (r0,r1,r2,r3,(v0,v1,v2,v3,_,v5,v6),r5,r6), {Row=Four; Column=Four } -> (r0, r1, r2, r3, (v0, v1, v2, v3, cellValue, v5, v6), r5, r6)
    | (r0,r1,r2,r3,(v0,v1,v2,v3,v4,_,v6),r5,r6), {Row=Four; Column=Five } -> (r0, r1, r2, r3, (v0, v1, v2, v3, v4, cellValue, v6), r5, r6)
    | (r0,r1,r2,r3,r4,(v0,_,v2,v3,v4,v5,v6),r6), {Row=Five; Column=One } -> (r0, r1, r2, r3, r4, (v0, cellValue, v2, v3, v4, v5, v6), r6)
    | (r0,r1,r2,r3,r4,(v0,v1,_,v3,v4,v5,v6),r6), {Row=Five; Column=Two } -> (r0, r1, r2, r3, r4, (v0, v1, cellValue, v3, v4, v5, v6), r6)
    | (r0,r1,r2,r3,r4,(v0,v1,v2,_,v4,v5,v6),r6), {Row=Five; Column=Three } -> (r0, r1, r2, r3, r4, (v0, v1, v2, cellValue, v4, v5, v6), r6)
    | (r0,r1,r2,r3,r4,(v0,v1,v2,v3,_,v5,v6),r6), {Row=Five; Column=Four } -> (r0, r1, r2, r3, r4, (v0, v1, v2, v3, cellValue, v5, v6), r6)
    | (r0,r1,r2,r3,r4,(v0,v1,v2,v3,v4,_,v6),r6), {Row=Five; Column=Five } -> (r0, r1, r2, r3, r4, (v0, v1, v2, v3, v4, cellValue, v6), r6)

let modify f (board: Board) (position: Position) =
    set (f (select board position)) board position

let placePieceIfCan piece=modify (function | Unspecified -> Letter piece | x -> x )

let makeMove (board : Board) (move : Move ) =
    if select board move.At = Unspecified
    then Some (placePieceIfCan move.Place board move.At)
    else None

let waysToWin =
    [
        {Row=One; Column=Zero},{Row=One; Column=One},{Row=One; Column=Two},{Row=One; Column=Three},{Row=One; Column=Four}
        {Row=One; Column=One},{Row=One; Column=Two},{Row=One; Column=Three},{Row=One; Column=Four},{Row=One; Column=Five}
        {Row=One; Column=Two},{Row=One; Column=Three},{Row=One; Column=Four},{Row=One; Column=Five},{Row=One; Column=Six}
        {Row=Two; Column=Zero},{Row=Two; Column=One},{Row=Two; Column=Two},{Row=Two; Column=Three},{Row=Two; Column=Four}
        {Row=Two; Column=One},{Row=Two; Column=Two},{Row=Two; Column=Three},{Row=Two; Column=Four},{Row=Two; Column=Five}
        {Row=Two; Column=Two},{Row=Two; Column=Three},{Row=Two; Column=Four},{Row=Two; Column=Five},{Row=Two; Column=Six}
        {Row=Three; Column=Zero},{Row=Three; Column=One},{Row=Three; Column=Two},{Row=Three; Column=Three},{Row=Three; Column=Four}
        {Row=Three; Column=One},{Row=Three; Column=Two},{Row=Three; Column=Three},{Row=Three; Column=Four},{Row=Three; Column=Five}
        {Row=Three; Column=Two},{Row=Three; Column=Three},{Row=Three; Column=Four},{Row=Three; Column=Five},{Row=Three; Column=Six}
        {Row=Four; Column=Zero},{Row=Four; Column=One},{Row=Four; Column=Two},{Row=Four; Column=Three},{Row=Four; Column=Four}
        {Row=Four; Column=One},{Row=Four; Column=Two},{Row=Four; Column=Three},{Row=Four; Column=Four},{Row=Four; Column=Five}
        {Row=Four; Column=Two},{Row=Four; Column=Three},{Row=Four; Column=Four},{Row=Four; Column=Five},{Row=Four; Column=Six}
        {Row=Five; Column=Zero},{Row=Five; Column=One},{Row=Five; Column=Two},{Row=Five; Column=Three},{Row=Five; Column=Four}
        {Row=Five; Column=One},{Row=Five; Column=Two},{Row=Five; Column=Three},{Row=Five; Column=Four},{Row=Five; Column=Five}
        {Row=Five; Column=Two},{Row=Five; Column=Three},{Row=Five; Column=Four},{Row=Five; Column=Five},{Row=Five; Column=Six}
        {Row=Zero; Column=One},{Row=One; Column=One},{Row=Two; Column=One},{Row=Three; Column=One},{Row=Four; Column=One}
        {Row=One; Column=One},{Row=Two; Column=One},{Row=Three; Column=One},{Row=Four; Column=One},{Row=Five; Column=One}
        {Row=Two; Column=One},{Row=Three; Column=One},{Row=Four; Column=One},{Row=Five; Column=One},{Row=Six; Column=One}
        {Row=Zero; Column=Two},{Row=One; Column=Two},{Row=Two; Column=Two},{Row=Three; Column=Two},{Row=Four; Column=Two}
        {Row=One; Column=Two},{Row=Two; Column=Two},{Row=Three; Column=Two},{Row=Four; Column=Two},{Row=Five; Column=Two}
        {Row=Two; Column=Two},{Row=Three; Column=Two},{Row=Four; Column=Two},{Row=Five; Column=Two},{Row=Six; Column=Two}
        {Row=Zero; Column=Three},{Row=One; Column=Three},{Row=Two; Column=Three},{Row=Three; Column=Three},{Row=Four; Column=Three}
        {Row=One; Column=Three},{Row=Two; Column=Three},{Row=Three; Column=Three},{Row=Four; Column=Three},{Row=Five; Column=Three}
        {Row=Two; Column=Three},{Row=Three; Column=Three},{Row=Four; Column=Three},{Row=Five; Column=Three},{Row=Six; Column=Three}
        {Row=Zero; Column=Four},{Row=One; Column=Four},{Row=Two; Column=Four},{Row=Three; Column=Four},{Row=Four; Column=Four}
        {Row=One; Column=Four},{Row=Two; Column=Four},{Row=Three; Column=Four},{Row=Four; Column=Four},{Row=Five; Column=Four}
        {Row=Two; Column=Four},{Row=Three; Column=Four},{Row=Four; Column=Four},{Row=Five; Column=Four},{Row=Six; Column=Four}
        {Row=Zero; Column=Five},{Row=One; Column=Five},{Row=Two; Column=Five},{Row=Three; Column=Five},{Row=Four; Column=Five}
        {Row=One; Column=Five},{Row=Two; Column=Five},{Row=Three; Column=Five},{Row=Four; Column=Five},{Row=Five; Column=Five}
        {Row=Two; Column=Five},{Row=Three; Column=Five},{Row=Four; Column=Five},{Row=Five; Column=Five},{Row=Six; Column=Five}
        {Row=Zero; Column=Zero},{Row=One; Column=One},{Row=Two; Column=Two},{Row=Three; Column=Three},{Row=Four; Column=Four}
        {Row=One; Column=One},{Row=Two; Column=Two},{Row=Three; Column=Three},{Row=Four; Column=Four},{Row=Five; Column=Five}
        {Row=Two; Column=Two},{Row=Three; Column=Three},{Row=Four; Column=Four},{Row=Five; Column=Five},{Row=Six; Column=Six}
        {Row=Two; Column=Zero},{Row=Three; Column=One},{Row=Four; Column=Two},{Row=Five; Column=Three},{Row=Six; Column=Four}
        {Row=One; Column=Zero},{Row=Two; Column=One},{Row=Three; Column=Two},{Row=Four; Column=Three},{Row=Five; Column=Four}
        {Row=Two; Column=One},{Row=Three; Column=Two},{Row=Four; Column=Three},{Row=Five; Column=Four},{Row=Six; Column=Five}
        {Row=Zero; Column=One},{Row=One; Column=Two},{Row=Two; Column=Three},{Row=Three; Column=Four},{Row=Four; Column=Five}
        {Row=One; Column=Two},{Row=Two; Column=Three},{Row=Three; Column=Four},{Row=Four; Column=Five},{Row=Five; Column=Six}
        {Row=Zero; Column=Two},{Row=One; Column=Three},{Row=Two; Column=Four},{Row=Three; Column=Five},{Row=Four; Column=Six}
        {Row=Zero; Column=Six},{Row=One; Column=Five},{Row=Two; Column=Four},{Row=Three; Column=Three},{Row=Four; Column=Two}
        {Row=One; Column=Five},{Row=Two; Column=Four},{Row=Three; Column=Three},{Row=Four; Column=Two},{Row=Five; Column=One}
        {Row=Two; Column=Four},{Row=Three; Column=Three},{Row=Four; Column=Two},{Row=Five; Column=One},{Row=Six; Column=Zero}
        {Row=Four; Column=Zero},{Row=Three; Column=One},{Row=Two; Column=Two},{Row=One; Column=Three},{Row=Zero; Column=Four}
        {Row=Zero; Column=Five},{Row=One; Column=Four},{Row=Two; Column=Three},{Row=Three; Column=Two},{Row=Four; Column=One}
        {Row=One; Column=Four},{Row=Two; Column=Three},{Row=Three; Column=Two},{Row=Four; Column=One},{Row=Five; Column=Zero}
        {Row=Six; Column=Two},{Row=Five; Column=Three},{Row=Four; Column=Four},{Row=Three; Column=Five},{Row=Two; Column=Six}
        {Row=One; Column=Six},{Row=Two; Column=Five},{Row=Three; Column=Four},{Row=Four; Column=Three},{Row=Five; Column=Two}
        {Row=Two; Column=Five},{Row=Three; Column=Four},{Row=Four; Column=Three},{Row=Five; Column=Two},{Row=Six; Column=One}
    ]

let cells =
    [
        for row in [Zero; One; Two; Three; Four; Five; Six] do
            for column in [Zero; One; Two; Three; Four; Five; Six] do
                yield {Row= row; Column= column}
    ]

let ``map 5`` f (a,b,c,d,e) = f a,f b,f c,f d,f e

let winner (board: Board) =
    let winPaths = List.map (``map 5`` (select board)) waysToWin
    if List.contains (Unspecified, Letter X, Letter X, Letter X, Unspecified) winPaths
    then Some X
    else if List.contains (Unspecified, Letter O, Letter O, Letter O, Unspecified) winPaths
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

let render ((a1,a2,a3,a4,a5,a6,a7),(b1,b2,b3,b4,b5,b6,b7),(c1,c2,c3,c4,c5,c6,c7),(d1,d2,d3,d4,d5,d6,d7),(e1,e2,e3,e4,e5,e6,e7),(f1,f2,f3,f4,f5,f6,f7),(g1,g2,g3,g4,g5,g6,g7)) =
    sprintf 
        """%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s
--------------------------------
%s | %s | %s | %s | %s | %s | %s"""
       (renderValue a1) (renderValue a2) (renderValue a3) (renderValue a4) (renderValue a5) (renderValue a6) (renderValue a7)
       (renderValue b1) (renderValue b2) (renderValue b3) (renderValue b4) (renderValue b5) (renderValue b6) (renderValue b7)
       (renderValue c1) (renderValue c2) (renderValue c3) (renderValue c4) (renderValue c5) (renderValue c6) (renderValue c7)
       (renderValue d1) (renderValue d2) (renderValue d3) (renderValue d4) (renderValue d5) (renderValue d6) (renderValue d7)
       (renderValue e1) (renderValue e2) (renderValue e3) (renderValue e4) (renderValue e5) (renderValue e6) (renderValue e7)
       (renderValue f1) (renderValue f2) (renderValue f3) (renderValue f4) (renderValue f5) (renderValue f6) (renderValue f7)
       (renderValue g1) (renderValue g2) (renderValue g3) (renderValue g4) (renderValue g5) (renderValue g6) (renderValue g7)

type GameState = {Board: Board; WhoseTurn: Letter}

let initialGameState = {Board=emptyBoard; WhoseTurn=X}

let parseZeroToSix = function
    | "0" -> Some Zero
    | "1" -> Some One
    | "2" -> Some Two
    | "3" -> Some Three
    | "4" -> Some Four
    | "5" -> Some Five
    | "6" -> Some Six
    | _ -> None

let parseMove ( raw: string) =
    match raw.Split [|' '|] with
    | [|r;c|] -> match parseZeroToSix r,parseZeroToSix c with
                 | Some row,Some column -> Some {Row=row; Column=column}
                 | _ -> None
    | _ -> None

type Status=
    | Start 
    | Stop

let mutable newBoard=emptyBoard
let mutable player=X
let mutable lastPlayer=player
let mutable state=Start
let mutable gameWinner=X
let mutable badMove=false

open System.Windows.Forms
open System.Drawing

let form = new Form()
form.Width <- 516
form.Height <- 560
form.BackColor <- Color.Yellow
do form.Text <- "Three in a row."
let mMain = form.Menu <- new MainMenu()

let mFile = form.Menu.MenuItems.Add("&Game")
let newGame=new MenuItem("New Game")
let miQuit = new MenuItem("&Quit")
let _ = mFile.MenuItems.Add(newGame)
let _ = mFile.MenuItems.Add(miQuit)
// callbacks
do miQuit.Click.Add(fun _ -> form.Close())
do form.Resize.Add(fun _ -> form.Invalidate());
do form.Closing.Add (fun _ -> form.Dispose())
do newGame.Click.Add(fun _ -> form.Refresh()
                              form.BackColor <- Color.Yellow
                              state <- Status.Start
                              player <- X
                              newBoard <- emptyBoard
                              form.Text <- System.String.Format("Player {0},{1}",player," --> turns"))

let mHelp=form.Menu.MenuItems.Add("&Game Rules")
do mHelp.Click.Add(fun _ -> MessageBox.Show("    Players alternate turns placing a stone of their color on an empty intersection. 
    The winner is the first player to form an unbroken chain of three stones horizontally, vertically, or diagonally, 
    and this chain must not be blocked at either end.. 
    To play a new game press: Game -> New Game 
    To quit the game press: Game -> Quit ") |> ignore)

let grf=form.CreateGraphics()
let drawGameGrid (grf:Graphics)=
    grf.DrawLine(Pens.Brown,PointF(100.0f,0.0f),PointF(100.0f,500.0f))
    grf.DrawLine(Pens.Brown,PointF(200.0f,0.0f),PointF(200.0f,500.0f))
    grf.DrawLine(Pens.Brown,PointF(300.0f,0.0f),PointF(300.0f,500.0f))
    grf.DrawLine(Pens.Brown,PointF(400.0f,0.0f),PointF(400.0f,500.0f))
    grf.DrawLine(Pens.Brown,PointF(0.0f,100.0f),PointF(500.0f,100.0f))
    grf.DrawLine(Pens.Brown,PointF(0.0f,200.0f),PointF(500.0f,200.0f))
    grf.DrawLine(Pens.Brown,PointF(0.0f,300.0f),PointF(500.0f,300.0f))
    grf.DrawLine(Pens.Brown,PointF(0.0f,400.0f),PointF(500.0f,400.0f))
form.Paint.Add(fun _ -> drawGameGrid grf)

let getCoordinatesFromOneToFive (number: ZeroToSix)=
    match number with
    | Zero -> -50.0f
    | One -> 50.0f
    | Two -> 150.0f
    | Three -> 250.0f
    | Four -> 350.0f
    | Five -> 450.0f
    | Six -> 550.0f 

let drawXMove x y =
    let xPen = new Pen(Color.Green)
    xPen.Width <- 10.0f
    grf.DrawLine(xPen,PointF(x-30.0f,y-30.0f),PointF(x+30.0f,y+30.0f))
    grf.DrawLine(xPen,PointF(x+30.0f,y-30.0f),PointF(x-30.0f,y+30.0f))

let drawOMove x y =
    let oPen = new Pen(Color.Blue)
    oPen.Width <- 10.0f
    grf.DrawEllipse(oPen,RectangleF(x-37.0f,y-37.0f,73.0f,73.0f))

let drawNewMove move letter= 
    let x,y=getCoordinatesFromOneToFive move.At.Column, getCoordinatesFromOneToFive move.At.Row
    printfn "x=%f  y=%f" x y
    match letter with
    | X -> drawXMove x y
    | O -> drawOMove x y

let findMouseCoordinates x y =
    if x>0 && x < 100 && y >0 && y <100 then  "1 1"
    else if x>100 && x < 200 && y >0 && y <100 then  "1 2"
    else if x>200 && x < 300 && y >0 && y <100 then  "1 3"
    else if x>300 && x < 400 && y >0 && y <100 then  "1 4"
    else if x>400 && x < 500 && y >0 && y <100 then  "1 5"
    else if x>0 && x < 100 && y >100 && y <200 then  "2 1"
    else if x>100 && x < 200 && y >100 && y <200 then  "2 2"
    else if x>200 && x < 300 && y >100 && y <200 then  "2 3"
    else if x>300 && x < 400 && y >100 && y <200 then  "2 4"
    else if x>400 && x < 500 && y >100 && y <200 then  "2 5"
    else if x>0 && x < 100 && y >200 && y <300 then  "3 1"
    else if x>100 && x < 200 && y >200 && y <300 then  "3 2"
    else if x>200 && x < 300 && y >200 && y <300 then  "3 3"
    else if x>300 && x < 400 && y >200 && y <300 then  "3 4"
    else if x>400 && x < 500 && y >200 && y <300 then  "3 5"
    else if x>0 && x < 100 && y >300 && y <400 then  "4 1"
    else if x>100 && x < 200 && y >300 && y <400 then  "4 2"
    else if x>200 && x < 300 && y >300 && y <400 then  "4 3"
    else if x>300 && x < 400 && y >300 && y <400 then  "4 4"
    else if x>400 && x < 500 && y >300 && y <400 then  "4 5"
    else if x>0 && x < 100 && y >400 && y <500 then  "5 1"
    else if x>100 && x < 200 && y >400 && y <500 then  "5 2"
    else if x>200 && x < 300 && y >400 && y <500 then  "5 3"
    else if x>300 && x < 400 && y >400 && y <500 then  "5 4"
    else if x>400 && x < 500 && y >400 && y <500 then  "5 5"
    else ""

form.MouseClick.Add(fun click -> let mouseCoord=findMouseCoordinates click.X click.Y
                                 let readMoveIO letter =
                                     let newPosition= parseMove mouseCoord
                                     {At=newPosition.Value;Place=letter}
                                 let nextMoveIO board letter =
                                     let newMove=readMoveIO letter
                                     match makeMove board newMove  with
                                     | Some newBoard -> printfn "%A -- %A" newMove.At.Row newMove.At.Column
                                                        drawNewMove newMove letter
                                                        printfn "%s" (render newBoard)
                                                        if not badMove then player <- otherPlayer player
                                                                            lastPlayer <- player
                                                        badMove <- false
                                                        newBoard
                                     | _ -> player <- lastPlayer
                                            badMove <- true
                                            printfn "Bad move! Position is occupied."
                                            board
                                 let playIO {Board=board;WhoseTurn=currentPlayer} =
                                     printfn "curr pl=%A" currentPlayer
                                     match outcome board with
                                     | Winner letter -> form.Text <- System.String.Format("Player {0},{1}",letter,"  wins")
                                                        gameWinner <- letter
                                                        state <- Status.Stop
                                                        newBoard <- emptyBoard
                                                        printfn "%s" (render emptyBoard)
                                     | Draw -> form.Text <- System.String.Format("{0}","It's a draw!")
                                               printfn "It's a draw!"
                                               state <- Status.Stop
                                     | NoneYet -> printfn "" 
                                
                                 if state=Status.Start then
                                     newBoard <- nextMoveIO newBoard player
                                     playIO {Board=newBoard;WhoseTurn=player}
                                     if badMove 
                                     then form.Text <- System.String.Format("{0},{1},{2}","Bad move! Position is occupied.   ",player," --> turns")
                                     else form.Text <- System.String.Format("{0},{1}",player," --> turns")
                                     printfn "%i  %i" click.X click.Y
                                 else
                                     form.Text <- System.String.Format("{0},{1}",gameWinner,"  wins")
                                 )
form.ShowDialog() |> ignore
