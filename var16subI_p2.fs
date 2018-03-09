open System
printf "Dati n="
let n=Console.ReadLine() |> int
let rec scrie (j:int) n =
    if j<=n then
        printf "*"
        scrie (j+1) n
    else ()       
   
let rec calcul i n=
    if i<n then
        if i%2=0 then 
            printf "#" 
        scrie (i+1) n 
        calcul (i+1) n
    else ()
    
let res=calcul 1 n