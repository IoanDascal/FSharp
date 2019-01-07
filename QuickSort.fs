(*
    https://www.geeksforgeeks.org/quick-sort/
    https://www.coursera.org/lecture/algorithms-part1/quicksort-vjvnC
*)

let rand=System.Random()
let data=List.init 1000000 (fun _ -> rand.Next()%100)

let QuickSort (lst: int list)=
    let rec quickSort lst=
        match lst with
        | [] -> lst
        | [x] -> lst
        | hd::tail -> let lower,greater=List.partition (fun elem -> elem<hd) tail
                      List.concat [(quickSort lower);[hd];quickSort greater]
    quickSort lst

#time
let res=QuickSort data
#time
 
#time
let res1=List.sort data
#time

let dataAr=Array.ofList data
printfn "%A" dataAr
let QuickSortArray (arr:int array)=
    let swapA (x:int) (y:int)=
        let temp=arr.[x]
        arr.[x] <- arr.[y]
        arr.[y] <- temp
    let partitionArray low high=
        let pivot=arr.[high]
        let rec loop i j=
            match j<high with
            | false -> (i+1)
            | true -> match arr.[j]<=pivot with
                      | true -> swapA (i+1) j
                                loop (i+1) (j+1)
                      | false -> loop i (j+1)
        let i=loop (low-1) low
        swapA i high
        i
    let rec quickSort arr low high=
        match low<high with
        | false -> ()
        | true -> let pi=partitionArray low high
                  quickSort arr low (pi-1)
                  quickSort arr (pi+1) high
    quickSort arr 0 (arr.Length-1)
    arr

#time
let sort=QuickSortArray dataAr
#time
#time
let sort1=Array.sort dataAr
#time