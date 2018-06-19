(*
    Write a fraction in its simplified form.
*)

open System
type Fraction=
    {
        N1:int32;
        N2:Int32 
    }
printf "Enter numerator num="
let num=int32(Console.ReadLine())
printf "Enter denominator den="
let den=int32(Console.ReadLine())
let x={N1=num;N2=den}
printfn "Fraction x = %i/%i" x.N1 x.N2
let rec GCD x y=
    if y=0 then 
        x
    else
        GCD y (x%y)
let gcd=GCD x.N1 x.N2
let x1={N1=x.N1/gcd;N2=x.N2/gcd}
printfn "Fraction x in simplified form is : %i/%i " x1.N1 x1.N2
