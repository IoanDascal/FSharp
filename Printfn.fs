///Printfn
let add x y=x+y
let sub x y=x-y
let mult x y=x*y
let printThreeNumbers num1 num2 num3=
    printfn "num1=%f" num1
    printfn "num2=%s" num2
    printfn "num3=%i" num3

printThreeNumbers (mult 4.0 5.2) (add "ab" "cd") (sub 30 23)