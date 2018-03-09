let text="copiii*sunt*la***zoo"
String.iteri (fun i x -> if i>0 && text.[i-1]=x && System.Char.IsLetter x then printf "%c%c" x x;printfn "") text