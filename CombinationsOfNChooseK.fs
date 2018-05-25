(*
    Computes the combinations without repetitions with
k elements from a set of n elements.
*)
let nChooseK arr k = 
    let rec choose low  =
        function
        |0 -> [[]]
        |i -> [for j=low to (Array.length arr)-1 do
                   for ks in choose (j+1) (i-1) do
                       yield arr.[j] :: ks ]
    choose 0  k                          
                         
let res=nChooseK [|1 .. 5|] 4
for ls in res do
    printfn "%A" ls