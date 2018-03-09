printf "Dati n="
let n=int(System.Console.ReadLine())
let lista=[]
let res=List.rev [for i in 1..n do     
                      printf "Dati un cuvant:" 
                      let cuvant=System.Console.ReadLine()
                      if cuvant.[0]=cuvant.[cuvant.Length-1] then yield(cuvant)]

printfn "%A" res