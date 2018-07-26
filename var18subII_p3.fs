(*
    Costruct a complete binary tree from an array of integers; calculate the height
of the tree and the maximum number of leafs from the tree.
    
    http://www.fssnip.net/at/title/NinetyNine-F-Problems-Problems-61-69-Binary-trees
*)

type Tree<'a>=
    | Empty
    | Tree of 'a*Tree<'a>*Tree<'a>

let values=[|5;7;8;1;2;4;6;9;3;-12;11;14|]
let completeBinaryTree (values:int array)=
    let n=values.Length
    let rec insert i content=
        if i<=n then
            insert (2*i) (fun leftTree -> insert (2*i+1) (fun rightTree -> content <| Tree (values.[i-1],leftTree,rightTree)))
        else  
            content Empty
    insert 1 id
let tree=completeBinaryTree values  
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

let heightOfTree tree=
    let rec height h tree=
        match tree with
        | Empty -> h
        | Tree (_,leftTree,rightTree) -> let leftHeight=height (h+1) leftTree 
                                         let rightHeight=height (h+1) rightTree
                                         if leftHeight>rightHeight then leftHeight
                                         else rightHeight
    height 0 tree
let treeHeight=heightOfTree tree
printfn "The height of the tree is %i" treeHeight
printfn "The maximum number of leafs is =%i" (pown 2 (treeHeight-1))