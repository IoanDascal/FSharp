let tati=[8;8;0;3;4;3;4;7;1;2;3;3;7;8;3;5;6;8]

let descendentiDir3=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=3 then (i+1) else 0)  tati)
let descendentiDir4=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=4 then (i+1) else 0)  tati)
let descendentiDir6=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=6 then (i+1) else 0)  tati)
let descendentiDir11=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=11 then (i+1) else 0)  tati)
let descendentiDir12=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=12 then (i+1) else 0)  tati)
let descendentiDir15=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=15 then (i+1) else 0)  tati)
let descendentiDir5=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=5 then (i+1) else 0)  tati)
let descendentiDir7=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=7 then (i+1) else 0)  tati)
let descendentiDir17=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=17 then (i+1) else 0)  tati)
let descendentiDir16=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=16 then (i+1) else 0)  tati)
let descendentiDir8=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=8 then (i+1) else 0)  tati)
let descendentiDir13=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=13 then (i+1) else 0)  tati)
let descendentiDir1=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=1 then (i+1) else 0)  tati)
let descendentiDir2=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=2 then (i+1) else 0)  tati)
let descendentiDir14=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=14 then (i+1) else 0)  tati)
let descendentiDir18=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=18 then (i+1) else 0)  tati)
let descendentiDir9=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=9 then (i+1) else 0)  tati)
let descendentiDir10=List.filter (fun x -> x<>0) (List.mapi (fun i x -> if x=10 then (i+1) else 0)  tati)
let cautaFrunze (tati:int list)=
    let rec loop nod lista=
        match nod<=tati.Length with
        | false -> lista
        | true -> match (List.tryFind (fun x -> x=nod) tati) with
                  | None -> loop (nod+1) (nod::lista)
                  | Some(nod) -> loop (nod+1) lista    
    loop 1 []

let res=cautaFrunze tati
printfn "%A" res

