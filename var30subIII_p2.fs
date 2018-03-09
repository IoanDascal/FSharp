let rec f x y=
    let rec loop i=
        match i<=y with
        | false -> ()
        | _ -> printf "%i" i
               f (i+1) y
               loop (i+1)
    loop x

let res=f 1 3
printfn ""