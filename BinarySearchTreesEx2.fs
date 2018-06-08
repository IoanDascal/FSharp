(*
    Some operations on binary search trees.
    https://www.geeksforgeeks.org/lowest-common-ancestor-in-a-binary-search-tree/
    https://www.geeksforgeeks.org/binary-search-tree-set-2-delete/
*)

open System
type Tree<'a>=
    | Empty  
    | Tree of 'a*Tree<'a>*Tree<'a>
let rec insert newValue=function
    | Empty -> Tree(newValue,Empty,Empty)
    | Tree (value,leftTree,rightTree) -> if newValue<value then let leftTree=insert newValue leftTree 
                                                                Tree (value,leftTree,rightTree)
                                         else if newValue>value then let rightTree=insert newValue rightTree 
                                                                     Tree (value,leftTree,rightTree)
                                         else Empty
let rec lowestCommonAncestor value1 value2 tree=
    match tree with
    | Empty -> Empty
    | Tree (value,leftTree,rightTree) -> match value>value1 && value>value2 with
                                         | true -> lowestCommonAncestor value1 value2 leftTree
                                         | false -> match value<value1 && value<value2 with
                                                    | true -> lowestCommonAncestor value1 value2 rightTree 
                                                    | false -> tree
printf "Enter the number of values to be inserted in BST n="
let n=int32(Console.ReadLine())
let rec constructTree n tree=
    match n with
    | 0 -> tree
    | _ -> printf "Enter new value to be inserted in BST : "
           let newValue=int32(Console.ReadLine())
           let tree=insert newValue tree
           constructTree (n-1) tree
let tree=constructTree n Empty
printf "Enter value1="
let value1=int32(Console.ReadLine())
printf "Enter value2="
let value2=int32(Console.ReadLine())
let lca=lowestCommonAncestor value1 value2 tree
let res=match lca with
        | Empty -> sprintf "Can't find LCA."
        | Tree (value,_,_) -> sprintf "LCA of %i and %i is %i" value1 value2 value
printfn "%s" res
///     Delete 
(*
       Given a non-empty binary search tree, return the node with minimum
   key value found in that tree. Note that the entire tree does not
   need to be searched. 
*)
let rec minimumValueNode (tree: Tree<'a>)=
    match tree with
    | Empty -> Empty
    | Tree (_,Empty,_) -> tree
    | Tree (_,leftTree,_) -> minimumValueNode leftTree
let rec deleteNode (tree:Tree<'a>) key=
    match tree with
    | Empty -> tree
    | Tree (value,leftTree,rightTree) when key<value -> let leftTree=deleteNode leftTree key 
                                                        Tree (value,leftTree,rightTree)
    | Tree (value,leftTree,rightTree) when key>value -> let rightTree=deleteNode rightTree key 
                                                        Tree (value,leftTree,rightTree)
    | Tree (_,Empty,Empty) -> Empty
    | Tree (_,leftTree,Empty) -> leftTree
    | Tree (_,Empty,rightTree) -> rightTree
    | Tree (_,leftTree,rightTree) -> let tree=minimumValueNode rightTree
                                     match tree with
                                     | Empty -> Empty
                                     | Tree (value,_,_) ->let rightTree=deleteNode rightTree value
                                                          Tree (value,leftTree,rightTree)

let res3=deleteNode tree 2
let res4=deleteNode tree 3
let res5=deleteNode tree 5
