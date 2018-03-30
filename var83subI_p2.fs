(*
 read x  (natural number, x>1) 
 aux <- x 
 ok1 <- 1  
┌ while x ≥ 10 do
│┌ if x%10>[x/10]%10 then 
││    ok1 <- 0 
│└■
│  x <- [x/10] 
└■
┌ if ok1=1 then 
│    write aux 
│ else 
│    write ”no” 
└■
*)

printf "x="
let x=uint32(System.Console.ReadLine())
let aux = x
let rec whileLoop x ok1=
    match x>=10u with
    | false -> ok1
    | true -> let ok=if x%10u>(x/10u)%10u then 0u else ok1
              whileLoop (x/10u) (ok)

let res=whileLoop x 1u
if res=1u then
    printfn "%u" aux
else
    printfn "NO"

