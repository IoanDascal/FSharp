printf "Dati numarul de noduri n="
let n=int(System.Console.ReadLine())
printf "Dati numarul de muchii m="
let m=int(System.Console.ReadLine())
let matriceAdiacenta=Array2D.zeroCreate<int> (n+1) (n+1)
for i in 1..m do 
    printf "Dati x="
    let x=int(System.Console.ReadLine())
    printf "Dati y="
    let y=int(System.Console.ReadLine())
    matriceAdiacenta.[x,y] <- 1
    matriceAdiacenta.[y,x] <- 1
for i in 1..n do
    for j in 1..n do
        printf "%i  " matriceAdiacenta.[i,j]
    printfn ""

printf "Dati numarul de varfuri din lant nr="
let nr=int(System.Console.ReadLine())
let lant=[for i in 1..nr do 
               yield(printf "lant[%i]=" i
                     int(System.Console.ReadLine()))]
let rez=
    let rec loop i=
        match i<(nr-1) with
        | false -> i
        | true -> match matriceAdiacenta.[lant.[i],lant.[i+1]]=1 with     
                  | false -> i
                  | true -> loop (i+1)
    loop 0
printfn "rez=%i" rez
if rez<nr-1 then printfn "Lista nu este un lant in graf"
    else
        let distincte=List.distinct lant
        if distincte.Length<n then printfn "Lantul nu contine toate nodurile grafului."
            else
                printfn "Lantul contine toate nodurile grafului."

