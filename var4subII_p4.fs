(*
    Given a string that contains only small and big letters
write a function that remove all small letters.
*)

printf "Enter a string : "
let s=System.Console.ReadLine()
let onlyBigLetters s =
     String.collect (fun c -> if (System.Char.IsUpper c) then sprintf "%c" c else sprintf "" ) s
printfn "%s" (onlyBigLetters s)