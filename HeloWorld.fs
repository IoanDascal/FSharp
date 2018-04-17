(*
        Many examples from  https://en.wikibooks.org/wiki/F_Sharp_Programming
*)


open System
let main (args : string[])=
    if args.Length <> 2 then
        failwith "Error: Expected arguments <greeting> and <thing>"
    let greeting, thing=args.[0], args.[1]
    let timeOfDay=DateTime.Now.ToString("hh:mm tt")
    printfn "%s, %s at %s" greeting thing timeOfDay
    0

(*Run this example with : CTRL+A  --->  ALT+ENTER  ---> then type in the interractive
   window  : main [|"aaaaa"; "bbbbb"|];;   --->  ENTER  *)