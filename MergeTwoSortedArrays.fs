(*
    https://www.geeksforgeeks.org/merge-two-sorted-arrays/
*)

// For arrays
let x=[|3;6;9;13;25;36|]
let y=[|1;7;11;27|]
let merge (x:int array) (y:int array) =
    let mutable i=0
    let mutable j=0
    let m=x.Length
    let n=y.Length
    let ar=[|while i < m && j < n do
                match x.[i]<=y.[j] with
                | true -> yield x.[i]
                          i <- i+1
                | false -> yield y.[j]
                           j <- j+1|]
    if i>=n then
        let ar=Array.concat [ar;x.[i..]]
        ar
    else
        let ar=Array.concat [ar;y.[j..]]
        ar
let res=merge x y

// For lists
let l1=[3;6;9;13;25;36]
let l2=[1;7;11;27]
let mergeLists l1 l2=
    let rec merge l1 l2 acc=
        match l1,l2 with
        | [],l -> acc@l
        | l,[] -> acc@l 
        | h1::tail1,h2::tail2 -> match h1<=h2 with
                                 | true -> merge tail1 (h2::tail2) (acc@[h1])
                                 | false -> merge (h1::tail1) tail2 (acc@[h2])
    merge l1 l2 []
let res=mergeLists l1 l2