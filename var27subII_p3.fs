(*
    Define a record to represent fractions.
Define some operations with fractions.
*)

open System
type Fraction=
    {
        X:float;
        Y:float
    }
let rec gcd a b=
    match a=b with
    | true -> a
    | false -> match a>b with
               | true -> gcd (a-b) b  
               | false -> gcd a (b-a)
let assignValues x y=
    let gcf=gcd (abs x) (abs y)
    let fraction={X=x/gcf; Y=y/gcf}
    fraction
printf "Enter nominator for fraction F , x="
let x=float(Console.ReadLine())
printf "Enter deniminator for fraction F , y="
let y=float(Console.ReadLine())
let F=assignValues x y
printf "Enter nominator for fraction G , x="
let z=float(Console.ReadLine())
printf "Enter deniminator for fraction G , y="
let w=float(Console.ReadLine())
let G=assignValues z w
let SUM (f:Fraction) (g:Fraction)=assignValues (f.X*g.Y+f.Y*g.X) (f.Y*g.Y)
let H=SUM F G
printfn "Sum F+G =%f/%f" H.X H.Y
let DIF (f:Fraction) (g:Fraction)=assignValues (f.X*g.Y-f.Y*g.X) (f.Y*g.Y)
let D=DIF F G
printfn "Difference F-G =%f/%f" D.X D.Y