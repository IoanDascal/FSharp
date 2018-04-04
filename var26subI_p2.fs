(*
 read n ( natural number)
 c <- 0
┌ for i <- 1,n do
│    c <- (c+1)%10
│    write c
*)
printf " n="
let n=uint32(System.Console.ReadLine())
let res=
    let rec forLoop n c=
        match n with
        | 0u -> ()
        | _ -> printf "%i" ((c+1)%10)
               forLoop (n-1u) ((c+1)%10)
    forLoop n 0
printfn ""