// List.partition returns a touple of lists
let isMultipleOf5 x= x%5=0
let multOf5,nonMultOf5=List.partition isMultipleOf5 [1..37]
printfn "%A" multOf5
printfn "%A" nonMultOf5