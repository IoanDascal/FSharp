(*
    Given two points write a function that prints if a line that passes
through points a and b is parallel to abscissa or to ordinate.
*)
 type Punct=
     {
         X:float
         Y:float
     }

let a={X=3.23;Y=6.0}
let b={X=3.23;Y=(-4.56)}
let res=if a.X=b.X then printfn "The line that passes through points a and b is parallel to Oy"
                   else if a.Y=b.Y then printfn "The line that passes through points a and b is parallel to Ox"
                        else printfn "The line that passes through points a and b isn't parallel to Oy or Ox"