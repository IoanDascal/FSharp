let rec f n i =
    match n with
    | 0 -> None
    | _ ->  match n%3 with
            | 0 -> None |> ignore
            | _ -> Some( printf "%i" i) |>ignore
            f (n/3) (i+1)
    
let res:obj option=f 121 1
