(*
    https://www.cs.usfca.edu/~galles/visualization/HeapSort.html
    https://www.programiz.com/dsa/heap-sort
    https://en.wikipedia.org/wiki/Heapsort

    Procedures to follow for Heapsort:
1.Since the tree satisfies Max-Heap property, then the largest item is stored at the root node.
2.Remove the root element and put at the end of the array (nth position) Put the last item of the tree (heap) at the vacant place.
3.Reduce the size of the heap by 1 and heapify the root element again so that we have highest element at root.
4.The process is repeated until all the items of the list are sorted.
*)

open System
type HeapStructure<'a>=
    {
        mutable heap: 'a [];
        mutable heapSize: int
    }

type CompareType=
    | Ascending
    | Descending

type HeapType=
    | MaxHeap
    | MinHeap

let setCompareType heapType=
    match heapType with
    | MaxHeap -> Ascending
    | MinHeap -> Descending

let compareValues compareType a b=
    match compareType with
    | Ascending -> a<b
    | Descending -> a>b

let swapArray (i:int) (j:int) (arr:'a [])=
    let temp=Array.get arr i
    Array.set arr i (Array.get arr j)
    Array.set arr j temp

let parent i=
    (i-1)/2

let leftChild i=
    2*i+1

let rightChild i=
    2*i+2

let isLeaf i size=
    i>=size/2 && i<=size

let insertKey heapType key heapStructure=
    let i=heapStructure.heapSize
    heapStructure.heap <- Array.append heapStructure.heap [|key|]
    heapStructure.heapSize <- Array.length heapStructure.heap
    let compType=setCompareType heapType
    let rec loop i=
        match i<>0 && (compareValues compType (Array.get heapStructure.heap (parent i)) (Array.get heapStructure.heap i)) with
        | false -> ()
        | true -> swapArray i (parent i) heapStructure.heap
                  loop (parent i)
    loop i

let printHeap heapType heapStructure=
    printfn "The %A is:" heapType
    printf "    heap :"
    heapStructure.heap |> Array.iter (fun x -> printf " %A" x )
    printfn ""
    printfn "    heapSize=%i" heapStructure.heapSize
    printfn ""

let rec heapify i heapStructure compType=
    match (isLeaf i heapStructure.heapSize) with
    | true -> ()
    | false -> let selected=ref i
               if (leftChild i)<heapStructure.heapSize &&  (compareValues compType (Array.get heapStructure.heap !selected) (Array.get heapStructure.heap (leftChild i))) then 
                   selected:=leftChild i
               if (rightChild i)<heapStructure.heapSize && (compareValues compType (Array.get heapStructure.heap !selected) (Array.get heapStructure.heap (rightChild i))) then 
                   selected:=rightChild i
               match !selected<>i with
               | false -> ()
               | true -> swapArray i !selected heapStructure.heap
                         heapify !selected heapStructure compType

let arr=[|4.1;8.0;1.3;23.9;-16.3;12.1;-8.4;0.7;32.1;-12.8;3.0;-15.0|]

let heapSort heapType arr=
    let compType=setCompareType heapType
    let heapStructure={heap=Array.empty; heapSize=0}
    arr |> Array.iter (fun x -> insertKey heapType x heapStructure)
    printHeap heapType heapStructure
    let rec loop size=
        match size>1 with 
        | false -> ()
        | true -> swapArray 0 size heapStructure.heap
                  heapStructure.heapSize <- heapStructure.heapSize-1
                  heapify 0 heapStructure compType
                  loop (size-1)
    loop (heapStructure.heapSize-1)
    if not (compareValues compType (Array.get heapStructure.heap 0) (Array.get heapStructure.heap 1)) then swapArray 0 1 heapStructure.heap
    heapStructure.heap

let res=heapSort MinHeap arr
printfn "Sorted Array using Min Heap: %A" res
printfn ""
let res1=heapSort MaxHeap arr
printfn "Sorted Array using Max Heap: %A" res1
