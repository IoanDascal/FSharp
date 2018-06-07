(*
        List.reduce iterates through each element of a list,building up
    an accumulator value, which is the summary of the processing done on 
    the list. Once every list item has been processed, the final accumulator 
    value is returned. The accumulator's initial value is the first
    element of the list. The signature of this function is:
    ( 'a -> 'a -> 'a ) -> 'a list -> 'a
*)

let insertCommas (acc : string) item=acc+","+item
let res=List.reduce insertCommas ["Jack";"Jill";"Jim";"Joe";"Jane"]
printfn "%A" res
let res1=List.reduceBack insertCommas ["Jack";"Jill";"Jim";"Joe";"Jane"]
printfn "%A" res1
