(*
        A record is similar to a tuple, except it contains named fields.
    A record is defined using the syntax :
        type recordName=
            {[fieldName : dataType ] + }  
    where + means the element must accur one or more times.
        Unlike a tuple, a record is explicitly defined as its own type using 
    the type keyword, and record fields are defined as a semicolon-separated list.

        https://en.wikibooks.org/wiki/F_Sharp_Programming/Tuples_and_Records
*)

/// Here is a simple record
type Website=
    {
        Title : string;
        Url : string
    }

/// A website record is created by specifying the records fields as follows :
let homepage={Title="Google";Url="http://www.google.com"}

/// It's easy to access a record's properties using dot notation:
let titlu=homepage.Title
let url=homepage.Url

(*
        Cloning Records.
    Records are immutable types, which means that instances of records cannot be modified.
    However, records can be cloned conveniently using the clone syntax:
*)

type Coords = 
    {
        X: float ;
        Y: float; 
    }
let setX item newX = { item with X = newX }
let start={X=1.0;Y=2.0}
let finish=setX start 3.0
/// Notice that the setX creates a copy of the record, it doesn't actually mutate the 
/// original record instance
let setY item newY= {item with Y=newY }
let finish1= setY finish 5.0

///     Pattern Matching Records
let getQuadrant = function
    | item when item.X=0.0 && item.Y=0.0 -> "Origin"
    | item when item.X>=0.0 && item.Y>=0.0 -> "I"
    | item when item.X<=0.0 && item.Y>0.0 -> "II"
    | item when item.X<=0.0 && item.Y<=0.0 -> "III"
    | item when item.X>=0.0 && item.Y<=0.0 -> "IV"
    | _ -> "Out of the plane"

let testCoords (x, y)=
    let item= {X=x;Y=y}
    printfn "(%f, %f) is  in quadrant %s" x y (getQuadrant item)
    

