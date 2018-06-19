(*
    Write a function arrangement : float array -> int -> float array
to rearrange the elements of an array so that the negative elements
must be on first positions in the array and the positive numbers must
be after negative elements.
*)
open System
printf "Enter n="
let n=int(Console.ReadLine())
let a=[|for i in 0..n-1 do yield (printf "a[%i]=" i
                                  float(Console.ReadLine()))|]
let swap (x:float,y:float)=(y,x)
let arrangement (a:array<float>)  n=
    let rec loop i j=
        match i<j with
        | true ->match a.[i]<0.0 with
                 | true -> loop (i+1) j
                 | false -> match a.[j]>=0.0 with
                            |true -> loop i (j-1)
                            | false -> let schimb=swap (a.[i], a.[j])
                                       a.[i] <- fst schimb
                                       a.[j] <- snd schimb
                                       loop (i+1) (j-1)
        | false -> a
    loop 0 (n-1)

let res=arrangement a n
for i in 0..n-1 do
    printf "%f " a.[i]
printfn ""