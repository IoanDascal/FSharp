
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
        {Row=One; Column=One},{Row=One; Column=Two},{Row=One; Column=Three}
        {Row=One; Column=Two},{Row=One; Column=Three},{Row=One; Column=Four}
        {Row=One; Column=Three},{Row=One; Column=Four},{Row=One; Column=Five}
        {Row=Two; Column=One},{Row=Two; Column=Two},{Row=Two; Column=Three}
        {Row=Two; Column=Two},{Row=Two; Column=Three},{Row=Two; Column=Four}
        {Row=Two; Column=Three},{Row=Two; Column=Four},{Row=Two; Column=Five}
        {Row=Three; Column=One},{Row=Three; Column=Two},{Row=Three; Column=Three}
        {Row=Three; Column=Two},{Row=Three; Column=Three},{Row=Three; Column=Four}
        {Row=Three; Column=Three},{Row=Three; Column=Four},{Row=Three; Column=Five}
        {Row=Four; Column=One},{Row=Four; Column=Two},{Row=Four; Column=Three}
        {Row=Four; Column=Two},{Row=Four; Column=Three},{Row=Four; Column=Four}
        {Row=Four; Column=Three},{Row=Four; Column=Four},{Row=Four; Column=Five}
        {Row=Five; Column=One},{Row=Five; Column=Two},{Row=Five; Column=Three}
        {Row=Five; Column=Two},{Row=Five; Column=Three},{Row=Five; Column=Four}
        {Row=Five; Column=Three},{Row=Five; Column=Four},{Row=Five; Column=Five}
        {Row=One; Column=One},{Row=Two; Column=One},{Row=Three; Column=One}
        {Row=Two; Column=One},{Row=Three; Column=One},{Row=Four; Column=One}
        {Row=Three; Column=One},{Row=Four; Column=One},{Row=Five; Column=One}
        {Row=One; Column=Two},{Row=Two; Column=Two},{Row=Three; Column=Two}
        {Row=Two; Column=Two},{Row=Three; Column=Two},{Row=Four; Column=Two}
        {Row=Three; Column=Two},{Row=Four; Column=Two},{Row=Five; Column=Two}
        {Row=One; Column=Three},{Row=Two; Column=Three},{Row=Three; Column=Three}
        {Row=Two; Column=Three},{Row=Three; Column=Three},{Row=Four; Column=Three}
        {Row=Three; Column=Three},{Row=Four; Column=Three},{Row=Five; Column=Three}
        {Row=One; Column=Four},{Row=Two; Column=Four},{Row=Three; Column=Four}
        {Row=Two; Column=Four},{Row=Three; Column=Four},{Row=Four; Column=Four}
        {Row=Three; Column=Four},{Row=Four; Column=Four},{Row=Five; Column=Four}
        {Row=One; Column=Five},{Row=Two; Column=Five},{Row=Three; Column=Five}
        {Row=Two; Column=Five},{Row=Three; Column=Five},{Row=Four; Column=Five}
        {Row=Three; Column=Five},{Row=Four; Column=Five},{Row=Five; Column=Five}
        {Row=One; Column=One},{Row=Two; Column=Two},{Row=Three; Column=Three}
        {Row=Two; Column=Two},{Row=Three; Column=Three},{Row=Four; Column=Four}
        {Row=Three; Column=Three},{Row=Four; Column=Four},{Row=Five; Column=Five}
        {Row=One; Column=Five},{Row=Two; Column=Four},{Row=Three; Column=Three}
        {Row=Two; Column=Four},{Row=Three; Column=Three},{Row=Four; Column=Two}
        {Row=Three; Column=Three},{Row=Four; Column=Two},{Row=Five; Column=One}
        {Row=Three; Column=One},{Row=Four; Column=Two},{Row=Five; Column=Three}
        {Row=Two; Column=One},{Row=Three; Column=Two},{Row=Four; Column=Three}
        {Row=Three; Column=Two},{Row=Four; Column=Three},{Row=Five; Column=Four}
        {Row=One; Column=Two},{Row=Two; Column=Three},{Row=Three; Column=Four}
        {Row=Two; Column=Three},{Row=Three; Column=Four},{Row=Four; Column=Five}
        {Row=One; Column=Three},{Row=Two; Column=Four},{Row=Three; Column=Five}
        {Row=Three; Column=One},{Row=Two; Column=Two},{Row=One; Column=Three}
        {Row=Five; Column=Three},{Row=Four; Column=Four},{Row=Three; Column=Five}
        {Row=One; Column=Four},{Row=Two; Column=Three},{Row=Three; Column=Two}
        {Row=Two; Column=Three},{Row=Three; Column=Two},{Row=Four; Column=One}
        {Row=Two; Column=Five},{Row=Three; Column=Four},{Row=Four; Column=Three}
        {Row=Three; Column=Four},{Row=Four; Column=Three},{Row=Five; Column=Two}
    ]

let cells =
    [
        for row in [One; Two; Three; Four; Five] do
            for column in [One; Two; Three; Four; Five] do
                yield {Row= row; Column= column}
    ]

let ``map 3`` f (a,b,c) = f a,f b,f c

let winner (board: Board) =
    let winPaths = List.map (``map 3`` (select board)) waysToWin
    if List.contains (Letter X, Letter X, Letter X) winPaths
    then Some X
    else if List.contains (Letter O, Letter O, Letter O) winPaths
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

type GameState = {Board: Board; WhoseTurn: Letter}

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

type Status=
    | Start 
    | Stop

let mutable newBoard=emptyBoard
let mutable player=X
let mutable state=Start
let mutable gameWinner=X

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

let mHelp=form.Menu.MenuItems.Add("&Help")
do mHelp.Click.Add(fun _ -> MessageBox.Show("    Players alternate turns placing a stone of their color on an empty intersection. 
    The winner is the first player to form an unbroken chain of three stones horizontally, vertically, or diagonally. 
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

let getCoordinatesFromOneToFive (number: OneToFive)=
    match number with
    | One -> 50.0f
    | Two -> 150.0f
    | Three -> 250.0f
    | Four -> 350.0f
    | Five -> 450.0f 

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

//form.Text <- System.String.Format("{0},{1}",player," -- turns")
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
                                                        player <- otherPlayer player
                                                        newBoard
                                     | _ -> form.Text <- System.String.Format("{0}","Bad move! Position is occupied.")
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
                                               state <- Status.Stop
                                     | NoneYet -> printfn "" 
                                
                                 if state=Status.Start then
                                     newBoard <- nextMoveIO newBoard player
                                     playIO {Board=newBoard;WhoseTurn=player}
                                     form.Text <- System.String.Format("{0},{1}",player," --> turns")
                                     printfn "%i  %i" click.X click.Y
                                 else
                                     form.Text <- System.String.Format("{0},{1}",gameWinner,"  wins")
                                 )
form.ShowDialog() |> ignore
