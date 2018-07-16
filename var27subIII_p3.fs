(*
    Write a function nreal : int -> int -> float , which 
takes two integers x and y from closed interval [1..1000], and 
returns a real number so that the whole number part is equal to x
and the fractional part is equal to y.
*)
let nreal x y=
    let fractional y=
        if y>=100 then float(y)/1000.0
        else if y>=10 && y<100 then float(y)/100.0
             else float(y)/10.0
    let res=float(x)+(fractional y)
    res
let newNumber=nreal 12 543
printfn "%0.3f" newNumber
let newNumber1=nreal 12 54
printfn "%0.2f" newNumber1
let newNumber2=nreal 12 5
printfn "%0.1f" newNumber2