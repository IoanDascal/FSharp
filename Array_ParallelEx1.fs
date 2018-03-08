open System.IO
open System.Security.Cryptography
let Hashes path=
    Directory.EnumerateFiles(path) 
    |> Array.ofSeq
   // |> Array.map (fun name -> 
   |> Array.Parallel.map (fun name -> 
                   use md5=MD5.Create()
                   use stream = File.OpenRead(name)
                   let hash=md5.ComputeHash(stream)
                   path,hash)

let res=Hashes "C:/Users/Nelu/Desktop/fsvsc/Teacher_Aggregation"
printfn "%A" res