open System.IO
let rec sumCifre suma n=
    match n with
    | 0 -> suma
    | _ -> sumCifre (suma+n%10) (n/10)
let res=
    let mutable i=0
    let mutable nrSumePare=0
    use sr=new StreamReader("nrvar144.txt")
    while not sr.EndOfStream do
        let x=int(sr.ReadLine())
        i<-i+1
        let sumCif=sumCifre 0 x
        if (sumCif%2)=0 then nrSumePare <- nrSumePare+1
            else () 
        printf "%i " x
        if i%5=0 then printfn ""
    nrSumePare

printfn "\n %i" res