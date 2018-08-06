(*
    File nrVar314.txt contains on the first line a value for an integer n,
and on each of the next n lines a pair of two integers x,y. Each pair x,y
represent the endpoints of a closed interval [x.y]. Calculate the intersection
of all n intervals. If the intersection doesn't exist print 0.
*)

open System.IO
let input=File.OpenText("../nrVar314.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(System.Environment.NewLine," ") 
    let inputArray=inputString.Split([|' '|])
    inputArray
let n=int((readLine input).[0])
let pairs=[|for i in 1..n do  
                 yield(Array.map int (readLine input))|]
let maximum=
    let rec loop i maxi=
        match i<n with    
        | false -> maxi
        | true -> let maxi=if maxi>pairs.[i].[0] then maxi    
                               else   
                                   pairs.[i].[0]
                  loop (i+1) maxi    
    loop 0 pairs.[0].[0]
let minimum=
    let rec loop i mini=
        match i<n with    
        | false -> mini
        | true -> let mini=if mini<pairs.[i].[1] then mini    
                               else   
                                   pairs.[i].[1]
                  loop (i+1) mini    
    loop 0 pairs.[0].[1]
if maximum>minimum then printfn "0"
    else   
        printfn "%i  %i" maximum minimum
