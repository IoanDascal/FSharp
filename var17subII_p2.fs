type candidat=
    {
        Cod : int
        Media : float
    }

printf "Dati codul ="
let cod=int(System.Console.ReadLine())
printf "Dati media ="
let media=float(System.Console.ReadLine())
let candidat1={Cod=cod;Media=media}
printfn "candidatul cu codul %i are media %f" candidat1.Cod candidat1.Media

