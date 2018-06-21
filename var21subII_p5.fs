(*
    Given a string that contains only lower case letters and character '*',
write a function to print all sequences with two identical and consecutive letters.
Example: For text="copiii*sunt*la***zoo" it should print:
  ii
  ii
  oo      
*)
printf "Enter a text : "
let text=System.Console.ReadLine()
String.iteri (fun i x -> if i>0 && text.[i-1]=x && System.Char.IsLetter x then printf "%c%c" x x;printfn "") text