printf "Dati numarul de linii si coloane n="
let n = int(System.Console.ReadLine())
let matrice=[|for i in 0..n-1 do 
                 yield([|for j in 0..n-1 do
                            yield(printf "mat[%i,%i]=" i j
                                  int(System.Console.ReadLine()))|])|]
for lista in matrice do
    printfn "%A" lista
let rec produsPivoti (coloana:int) (pivot:int)=
    match coloana<n with
    | false -> pivot
    | true -> let raport=matrice.[0].[coloana]/matrice.[0].[0]
              let rec verific i=
                  if (i=n ||  matrice.[i].[coloana]/matrice.[i].[0]<>raport) then i
                      else verific (i+1)
              printfn "%i" (verific 1)
              if (verific 1)=n then produsPivoti (coloana+1) (pivot*raport)
                  else produsPivoti (coloana+1) pivot

let res=produsPivoti 1 1
printfn "%i" res

