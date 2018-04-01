(*
 a <- 0 
 k <- 0 
┌ repeat
│    read x  ( natural number) 
│┌ while x > 99 do
││    x <- [x/10] 
│└■
│┌ if x > 9 then
││    a <- a*100 + x 
││    k <- k+1 
│└■
└ until k = 4
 write a 
*)

let rec repeatLoop a k=
    printf "x="
    let x=int32(System.Console.ReadLine())
    let rec whileLoop x=
        match x>99 with
        | false -> x
        | true -> whileLoop (x/10)
    let x1=whileLoop x
    printfn "x1=%i" x1
    let ak=if x1>9 then ((a*100+x1),(k+1)) else (a,k)
    match (snd ak)=4 with
    | true -> fst ak
    | false -> repeatLoop (fst ak) (snd ak)

let res=repeatLoop 0 0
printfn "%i" res
