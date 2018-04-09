(*
 read x   ( natural number, n>0) 
 z <- 0 
 p <- 1 
┌ repeat
│    c <- x%10 
│┌ if c%2≠0 then
││    z <- z+c*p 
││    p <- p*10 
│└■
│  x <- [x/10] 
└ until x = 0 
  write z 
*)

printf "x="
let x=int32(System.Console.ReadLine())
let rec repeatLoop x z p=
    match x=0 with
    | true -> z
    | false -> let c=x%10
               let z,p=if c%2<>0 then (z+c*p),(p*10) else z,p
               repeatLoop (x/10) z p

let z=repeatLoop x 0 1
printfn "z=%i" z