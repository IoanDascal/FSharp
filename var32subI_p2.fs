(*
 read a,b ( natural numbers)
┌ if a>b then
│    c <- b
│    b <- a
│    a <- c
└■
┌ while a<=b do
│    write a
│    a <- a*2
└■
 write a 
*)
printf " a="
let a=int(System.Console.ReadLine())
printf " b="
let b=int(System.Console.ReadLine())
let ab=if a>b then (b,a)
            else   
                (a,b)
let rec whileLoop x y=
    match x<=y with
    | true -> printf "%i  " x
              whileLoop (2*x) y   
    |false -> ()

let res=whileLoop (fst ab) (snd ab)
printfn ""