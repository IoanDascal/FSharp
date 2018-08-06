(*
    Write a function sumOfM : float list -> int ->int -> float that 
takes as arguments: x - a list of real numbers, n - the number of 
elements from list x, and m - the number of lowest numbers in list x.  
The function must return the sum of the m lowest numbers from list x.
*)

printf "Enter the number of elements from the list n=" 
let n=int(System.Console.ReadLine())
let x=[for i in 1..n do
           yield(printf "x[%i]=" i
                 float(System.Console.ReadLine()))]
printf "Enter the number of elements that must be summed m="
let m=int(System.Console.ReadLine())
let sumOfM (x:float list) n m=
    if m<n then
        let rec loop x m i sum=
            match i<=m with
            | false -> sum
            | true -> let minim=List.min x
                      loop (List.filter (fun x -> x<>minim) x) m (i+1) (sum+minim)
        loop x m 1 0.0
    else    
        List.sum x    

let res = sumOfM x n m  
printfn "The sum of the %i lowest numbers is= %f" m res   