
let rec f a b=
    match a<=b with
    | true -> f (a+1) (b-2)
              printf "%c" '*'
    | false -> printf "%i" b

let rez=f 3 17