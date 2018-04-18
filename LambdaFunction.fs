///F# provides a special sintax for creating in-line functions.
///These functions are called lambda functions
let add = (fun x y -> x + y )
let sum=add 2 2
printfn "%i" sum