(*
    https://www.geeksforgeeks.org/max-heap-in-java/
    https://www.geeksforgeeks.org/binary-heap/
*)

open System
type MaxHeap=
    {
        mutable heap:int [];
        mutable heapSize:int
    }

let swapA (x:int) (y:int) (arr:int [])=
    let temp=Array.get arr x
    Array.set arr x (Array.get arr y)
    Array.set arr y temp

let parent i=
    (i-1)/2

let leftChild i=
    2*i+1

let rightChild i=
    2*i+2

let isLeaf i size=
    i>=size/2 && i<=size

let insertKey k maxHeap=
    let i=maxHeap.heapSize
    maxHeap.heap <- Array.append maxHeap.heap [|k|]
    maxHeap.heapSize <- Array.length maxHeap.heap
    let rec loop i =
        match i<>0 && (Array.get maxHeap.heap (parent i)) < (Array.get maxHeap.heap i) with
        | false -> ()
        | true -> swapA i (parent i) maxHeap.heap
                  loop (parent i)
    loop i

let rec maxHeapify i maxHeap=
    match (isLeaf i maxHeap.heapSize) with
    | true -> ()
    | false -> match (Array.get maxHeap.heap i)<(Array.get maxHeap.heap (leftChild i)) || (Array.get maxHeap.heap i)<(Array.get maxHeap.heap (rightChild i)) with
               | false -> ()
               | true -> match (Array.get maxHeap.heap (leftChild i)) > (Array.get maxHeap.heap (rightChild i)) with
                         | true -> swapA i (leftChild i) maxHeap.heap
                                   maxHeapify (leftChild i) maxHeap
                         | false -> swapA i (rightChild i) maxHeap.heap
                                    maxHeapify (rightChild i) maxHeap

let extractMax maxHeap=
    let popped=Array.get maxHeap.heap 0
    maxHeap.heapSize <- maxHeap.heapSize-1
    Array.set maxHeap.heap 0 (Array.get maxHeap.heap maxHeap.heapSize)
    maxHeap.heap <- Array.sub maxHeap.heap 0 maxHeap.heapSize
    maxHeapify 0 maxHeap
    popped

let printMaxHeap maxHeap=
    printfn "The max heap is:"
    printf "    heap :"
    maxHeap.heap |> Array.iter (fun x -> printf " %i" x )
    printfn ""
    printfn "    heapSize=%i" maxHeap.heapSize
    printfn ""

let maxHeap={heap=Array.empty<int>;heapSize=0}

printMaxHeap maxHeap
insertKey 5 maxHeap
printMaxHeap maxHeap
maxHeap |> insertKey 7
printMaxHeap maxHeap
let arr=[|4;8;1;23;12;0|]
arr |> Array.iter (fun x -> insertKey x maxHeap)
printMaxHeap maxHeap
let maximum=extractMax maxHeap
printfn "The maximum value is:%i" maximum
printMaxHeap maxHeap