open System
 type Punct=
     {
         X:float
         Y:float
     }

let a={X=3.23;Y=6.0}
let b={X=3.23;Y=(-4.56)}
let res=if a.X=b.X then printfn "Dreapta data de a si b este paralela cu axa Oy"
                   else if a.Y=b.Y then printfn "Dreapta data de a si b este paralela cu axa Ox"
                        else printfn "Dreapta data de a si b nu este paralela cu axa Oy sau Ox"