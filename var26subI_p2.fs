printf "Dati n="
let n=int(System.Console.ReadLine())
let res=
    let rec executa n c=
        match n with
        | 1 -> printf "%i" ((c+1)%10)
        | _ -> printf "%i" ((c+1)%10)
               executa (n-1) ((c+1)%10)
    executa n 0
printfn ""