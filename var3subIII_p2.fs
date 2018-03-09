let rec f x=
    if x>0 then
        match x%4 with
        | 0 -> printf "x"
               f (x-1)
        | _ -> f (x/3)
               printf "y"


let res=f 26