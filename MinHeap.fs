(*
    https://www.geeksforgeeks.org/max-heap-in-java/
    https://www.geeksforgeeks.org/binary-heap/
    https://medium.com/@randerson112358/lets-build-a-min-heap-4d863cac6521
*)

open System
type MinHeap=
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

let insertKey k minHeap=
    let i=minHeap.heapSize
    minHeap.heap <- Array.append minHeap.heap [|k|]
    minHeap.heapSize <- Array.length minHeap.heap
    let rec loop i =
        match i<>0 && (Array.get minHeap.heap (parent i)) > (Array.get minHeap.heap i) with
        | false -> ()
        | true -> swapA i (parent i) minHeap.heap
                  loop (parent i)
    loop i

let rec minHeapify i minHeap=
    match (isLeaf i minHeap.heapSize) with
    | true -> ()
    | false -> match (Array.get minHeap.heap i)>(Array.get minHeap.heap (leftChild i)) || (Array.get minHeap.heap i)>(Array.get minHeap.heap (rightChild i)) with
               | false -> ()
               | true -> match (Array.get minHeap.heap (leftChild i)) < (Array.get minHeap.heap (rightChild i)) with
                         | true -> swapA i (leftChild i) minHeap.heap
                                   minHeapify (leftChild i) minHeap
                         | false -> swapA i (rightChild i) minHeap.heap
                                    minHeapify (rightChild i) minHeap

let extractMin minHeap=
    let popped=Array.get minHeap.heap 0
    minHeap.heapSize <- minHeap.heapSize-1
    Array.set minHeap.heap 0 (Array.get minHeap.heap minHeap.heapSize)
    minHeap.heap <- Array.sub minHeap.heap 0 minHeap.heapSize
    minHeapify 0 minHeap
    popped

let printMinHeap minHeap=
    printfn "The min heap is:"
    printf "    heap :"
    minHeap.heap |> Array.iter (fun x -> printf " %i" x )
    printfn ""
    printfn "    heapSize=%i" minHeap.heapSize
    printfn ""

let minHeap={heap=Array.empty<int>;heapSize=0}

printMinHeap minHeap
insertKey 5 minHeap
printMinHeap minHeap
minHeap |> insertKey 7
printMinHeap minHeap
let arr=[|4;8;1;23;12;0|]
arr |> Array.iter (fun x -> insertKey x minHeap)
printMinHeap minHeap
let minimum=extractMin minHeap
printfn "The minimum value is:%i" minimum
printMinHeap minHeap
