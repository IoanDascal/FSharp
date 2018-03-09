printf "Dati n="
let n=int(System.Console.ReadLine())
let sol=Array.zeroCreate<int> 10

let valid p=
    p<=n && sol.[1]<>0
let solutie p=
    (Array.sum sol.[1..p])=4
let afisare p=
    for i in 1..p do  
        printf "%i" sol.[i]
    printfn ""

let rec backtracking p=
    for i in 0..n-1 do  
        sol.[p] <- i   
        if valid p then 
            if solutie p then  
                afisare p
                else    
                    backtracking (p+1)

let res=backtracking 1