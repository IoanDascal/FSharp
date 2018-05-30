(*
    Some operations on binary search trees.
    https://www.geeksforgeeks.org/binary-search-tree-set-1-search-and-insertion/
    https://www.geeksforgeeks.org/level-order-tree-traversal/
    https://www.geeksforgeeks.org/print-bst-keys-in-the-given-range/
*)

type Tree<'a>=
    | Empty
    | Tree of 'a*Tree<'a>*Tree<'a>

let values=[|5;7;8;1;2;4;6;9;3;-12;11;14|]
let rec insert newValue=function
    | Empty -> Tree (newValue,Empty,Empty)
    | Tree (value,leftTree,rightTree) -> if newValue<value then let leftTree=insert newValue leftTree 
                                                                Tree (value,leftTree,rightTree)
                                         else if newValue>value then let rightTree=insert newValue rightTree 
                                                                     Tree (value,leftTree,rightTree)
                                         else Empty
let convertArrayToBinarySearchTree (values:int array)=    
    let tree=values |> Array.fold (fun newTree value -> insert value newTree) Empty
    tree
let tree=convertArrayToBinarySearchTree values
let rec inorder tree=
    [|
        match tree with
        | Tree (x,leftTree,rightTree) -> yield! inorder leftTree
                                         yield x
                                         yield! inorder rightTree
        | Empty -> ()
    |]
printfn "In-order traversal :"
let inorderTraversal=inorder tree
printfn "%A"  inorderTraversal
let rec preorder tree=
    [|
        match tree with
        | Tree (x,left,right) -> yield x
                                 yield! preorder left
                                 yield! preorder right
        | Empty -> ()
    |]
printfn "Pre-order traversal :"  
let preorderTraversal=preorder tree
printfn "%A" preorderTraversal
let rec postorder tree=
    [|
        match tree with
        | Tree (x,left,right) -> yield! postorder left
                                 yield! postorder right
                                 yield x
        | Empty -> ()
    |]
printfn "Post-order traversal :"
let postorderTraversal=postorder tree
printfn "%A" postorderTraversal

let rec searchValue (tree:Tree<'a>) (valueToFind:'a)=
    match tree with
    | Tree (value,leftTree,rightTree) -> if valueToFind=value then Some value  
                                         else if valueToFind<value then searchValue leftTree valueToFind
                                         else searchValue rightTree valueToFind                                 
    | Empty -> None   
let search7=searchValue tree 7
if search7.IsSome then printfn "Value %i is in tree." search7.Value
    else printfn "Value not found"
let search17=searchValue tree 17
if search17.IsSome then printfn "Value %i is in tree." search17.Value
    else printfn "Value not found"
let tree1=insert 13 tree
let inorderTraversal1=inorder tree1
printfn "%A" inorderTraversal1
(*
     Compute the "height" of a tree -- the number of
nodes along the longest path from the root node
down to the farthest leaf node.
*)
let heightOfTree tree=
    let rec height h tree=
        match tree with
        | Empty -> h
        | Tree (_,leftTree,rightTree) -> let leftHeight=height (h+1) leftTree 
                                         let rightHeight=height (h+1) rightTree
                                         if leftHeight>rightHeight then leftHeight
                                         else rightHeight
    height 0 tree
let treeHeight=heightOfTree tree1
printfn "The height of the tree is %i" treeHeight