(*
    Se  considera o  coada in care initial  au  fost  introduse,  in  aceasta
  ordine,  elementele  cu  valorile 1 si  2. Se noteaza cu AD(x) operatia 
  prin care se adauga elementul cu valoarea x in  coada si  cu  EL operatia  
  prin  care  se  elimina un  element  din  coada.  Cate elemente va contine     
  coada in urma executarii secventei de operatii: AD(4);EL;EL;AD(5);EL;AD(3) ?
 *)
open System.Collections.Generic
let coada=new Queue<int>()
coada.Enqueue(1)
coada.Enqueue(2)
coada.Enqueue(4)
coada.Dequeue() |> ignore
coada.Dequeue() |> ignore
coada.Enqueue(5)
coada.Dequeue() |> ignore
coada.Enqueue(3)
printfn "%A" coada