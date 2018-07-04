(*
    Given a string write a function to copy the character from 
index 3 to index 1.
*)
let s="raton"
let ch=s.[3]
let s1=String.mapi (fun i x -> if i=1 then ch else x)
printfn "%s" (s1 s)
