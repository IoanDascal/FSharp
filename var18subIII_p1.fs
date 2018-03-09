let rec f n i=
    if i<(n%10) then 
        printf "%i" (n%10)
        f (n/10) (i+1)
    else  
        ()
let res=f 12345 0
printfn ""