(*
 read x  ( real number >0)
 y <- [x]
 x <- x-y
┌ while x≠[x] do
│    x <- x*10
└■
┌ if x=y then
│    write 1
│ else
│    write 2
└■
*)
printf " x="
let x=double(System.Console.ReadLine())
let y=floor x
let z=round((x-y)*10000000000.0)/10000000000.0
let rec whileLoop (z:double)=
    match z<>(round z) with
    | false -> z
    | true -> whileLoop (z*10.0)

let res=whileLoop z
if y=res then printfn "1"
    else printfn "2"
