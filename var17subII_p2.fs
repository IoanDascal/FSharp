(* 
    How to design a record type.
*)
type Candidate=
    {
        Code : int
        Average : float
    }

printf " Code ="
let code=int(System.Console.ReadLine())
printf "Average ="
let average=float(System.Console.ReadLine())
let candidate1={Code=code;Average=average}
printfn "The candidate with code %i is having the average %.2f" candidate1.Code candidate1.Average

