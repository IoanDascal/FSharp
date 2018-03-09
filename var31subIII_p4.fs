open System.IO
let input=File.OpenText("../nrVar314.txt")
let citireLinie (isr:StreamReader)=
    let sir=isr.ReadLine()
    let sir=sir.Replace(System.Environment.NewLine," ") 
    let sir=sir.Split([|' '|])
    sir
let n=int((citireLinie input).[0])
let perechi=[|for i in 1..n do  
                 yield(Array.map int (citireLinie input))|]
let maxim=
    let rec loop i maxi=
        match i<n with    
        | false -> maxi
        | true -> let maxi=if maxi>perechi.[i].[0] then maxi    
                               else   
                                   perechi.[i].[0]
                  loop (i+1) maxi    
    loop 0 perechi.[0].[0]
let minim=
    let rec loop i mini=
        match i<n with    
        | false -> mini
        | true -> let mini=if mini<perechi.[i].[1] then mini    
                               else   
                                   perechi.[i].[1]
                  loop (i+1) mini    
    loop 0 perechi.[0].[1]
if maxim>minim then printfn "0"
    else   
        printfn "%i  %i" maxim minim
