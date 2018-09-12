///The |> operator allows you to reorder your code by specifying 
///the last argument of a function before you call it.
///The Forward Pipe Operator reorganizes the the function chain 
///so that tour code reads the way you think about the problem 
///instead of forcing you to think inside out.
let firstHndred=[50..151]
let FPO=
    firstHndred
    |>List.filter (fun x->x%3=1)
    |>List.map (fun x->2*x+3)
    |>List.sum