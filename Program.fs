// Learn more about F# at http://fsharp.org

open System
open System.IO
let input=File.OpenText("data.txt")
let readLine (isr:StreamReader)=
    let inputString=isr.ReadLine()
    let inputString=inputString.Replace(Environment.NewLine,":")
    let inputArray=inputString.Split([|':';','|])
    inputArray

let opinionToScale opinion=
    match opinion with
    | "Extremly good" | "EG" | "eg" -> Some 9
    | "Verry good" | "VG" | "vg" -> Some 7
    | "Good" | "G" | "g" -> Some 5
    | "Medium bad" | "MB" | "mb" -> Some 3
    | "Bad" | "B" | "b" -> Some 2
    | "Very bad" | "VB" | "vb" -> Some 1
    | _ -> None

let printResult message res=
    printfn ""
    printfn "%s" message
    printfn "%A" res 
    printfn ""

let nrOfAlternatives=(readLine input).[1] |> int
let nrOfCriteria=(readLine input).[1] |> int
let nrOfDecisionMakers=(readLine input).[1] |> int
let coefLeftFunction=(readLine input).[1]
let a1b1=coefLeftFunction.Split(' ')
let a1=a1b1.[0] |> float
let b1=a1b1.[1] |> float
let coefRightFunction=(readLine input).[1]
let a2b2=coefRightFunction.Split(' ')
let a2=a2b2.[0] |> float
let b2=a2b2.[1] |> float
let convertedToFloatNrOfDecisionMakers=float nrOfDecisionMakers
let convertedToFloatnrOfAlternatives=float nrOfAlternatives

let generateDecisionMatrix () =
    let decisionMatrix=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> let sum= Array.sumBy (fun x -> let opin=opinionToScale x
                                                                                                             opin.Value) (readLine input) 
                                                                              (sum |> float)/convertedToFloatNrOfDecisionMakers)
    decisionMatrix

type TFN=   // Triangular Fuzzy Number
    {
        l : float
        m : float
        u : float
    }

let convertImportanceIntensityToTFN (importanceIntensity : float)=
    {l = -b1/a1*importanceIntensity;m = importanceIntensity;u = -b2/a2*importanceIntensity}

let generateFuzzyDecisionMatrix (decisionMatrix : float [,])=
    let fuzzyDecisionMatrix=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> convertImportanceIntensityToTFN decisionMatrix.[i,j])
    fuzzyDecisionMatrix |> printResult "The Fuzzy Decision Matrix is :"
    fuzzyDecisionMatrix

type AFIWC=    // AFIWC - aggregated fuzzy importance weight for a particular criterion
    {
        lj : float
        mj : float
        uj : float
    }

let generateAgregatedFuzzyImportanceWeightArray (fuzzyDecisionMatrix : TFN [,])=
    let calculateColumnProducts i = Array.reduce (fun (acc : TFN) (x : TFN) -> {l=acc.l*x.l;m=acc.m*x.m;u=acc.u*x.u}) fuzzyDecisionMatrix.[*,i]
    let agregatedFuzzyImportanceWeightArray=Array.init nrOfCriteria (fun i -> let tfn=calculateColumnProducts i
                                                                              {lj = tfn.l**(1.0/convertedToFloatnrOfAlternatives);
                                                                               mj = tfn.m**(1.0/convertedToFloatnrOfAlternatives);
                                                                               uj = tfn.u**(1.0/convertedToFloatnrOfAlternatives)}
                                                                    )
    agregatedFuzzyImportanceWeightArray

let generateNormalizedAgregatedFuzzyImportanceWeightArray (agregatedFuzzyImportanceWeightArray : AFIWC [])=
    let sumAFIWC=Array.reduce (fun (acc : AFIWC) (x : AFIWC) -> {lj=acc.lj+x.lj;mj=acc.mj+x.mj;uj=acc.uj+x.uj}) agregatedFuzzyImportanceWeightArray
    let normalizedAgregatedFuzzyImportanceWeightArray=Array.map (fun x -> {lj=x.lj/sumAFIWC.uj;mj=x.mj/sumAFIWC.mj;uj=x.uj/sumAFIWC.lj})  agregatedFuzzyImportanceWeightArray
    normalizedAgregatedFuzzyImportanceWeightArray |> printResult "The normalized aggregated fuzzy importance weight for each criterion is:"
    normalizedAgregatedFuzzyImportanceWeightArray

let generateNormalizedDecisionMatrix (decisionMatrix : float [,])=
    let calculateColumnSums i = Array.sumBy (fun x -> x*x) decisionMatrix.[*,i]
    let normalizedDecisionMatrix=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> decisionMatrix.[i,j]/((calculateColumnSums j)**0.5))
    normalizedDecisionMatrix

let generateWeightedNormalizedDecisionMatrix (normalizedDecisionMatrix : float [,]) (agregatedFuzzyImportanceWeightArray : AFIWC [])=
    let normalizedAgregatedFuzzyImportanceWeightArray= generateNormalizedAgregatedFuzzyImportanceWeightArray agregatedFuzzyImportanceWeightArray
    let weightedNormalizedDecisionMatrixV1=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> normalizedDecisionMatrix.[i,j]*normalizedAgregatedFuzzyImportanceWeightArray.[j].lj)
    let weightedNormalizedDecisionMatrixV2=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> normalizedDecisionMatrix.[i,j]*normalizedAgregatedFuzzyImportanceWeightArray.[j].mj)
    let weightedNormalizedDecisionMatrixV3=Array2D.init nrOfAlternatives nrOfCriteria (fun i j -> normalizedDecisionMatrix.[i,j]*normalizedAgregatedFuzzyImportanceWeightArray.[j].uj)
    (weightedNormalizedDecisionMatrixV1,weightedNormalizedDecisionMatrixV2,weightedNormalizedDecisionMatrixV3)

let generateConcordanceMatrix (V1 : float [,]) (V2 : float [,]) (V3 : float [,]) (agregatedFuzzyImportanceWeightArray : AFIWC [])=
    let concordanceMatrixC1=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some (Array.sum (Array.mapi (fun k x -> if V1.[i,k] >= V1.[j,k] then x.lj else 0.0 ) agregatedFuzzyImportanceWeightArray)) else None)
    let concordanceMatrixC2=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some (Array.sum (Array.mapi (fun k x -> if V2.[i,k] >= V2.[j,k] then x.mj else 0.0 ) agregatedFuzzyImportanceWeightArray)) else None)
    let concordanceMatrixC3=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some (Array.sum (Array.mapi (fun k x -> if V3.[i,k] >= V3.[j,k] then x.uj else 0.0 ) agregatedFuzzyImportanceWeightArray)) else None)
    let concordanceMatrix=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some ((concordanceMatrixC1.[i,j].Value*concordanceMatrixC2.[i,j].Value*concordanceMatrixC3.[i,j].Value)**(1.0/3.0)) else None)
    concordanceMatrixC1 |> printResult "The concordance matrix C1 for V1 is:"
    concordanceMatrixC2 |> printResult "The concordance matrix C2 for V2 is:"
    concordanceMatrixC3 |> printResult "The concordance matrix C3 for V3 is:"
    concordanceMatrix

let generateDiscordanceMatrix (V1 : float [,]) (V2 : float [,]) (V3 : float [,])=
    let maxDiffLines_i_j_V1 = Array.zeroCreate<float> nrOfAlternatives
    let maxDiffLines_i_j_V2 = Array.zeroCreate<float> nrOfAlternatives
    let maxDiffLines_i_j_V3 = Array.zeroCreate<float> nrOfAlternatives
    let nrDiff=ref 0
    for i in 0..nrOfAlternatives-2 do
        for j in 0..nrOfAlternatives-1 do
            if i<j then maxDiffLines_i_j_V1.[!nrDiff] <- Array.max (Array.map2 (fun x y -> abs(x-y)) V1.[i,*] V1.[j,*])
                        maxDiffLines_i_j_V2.[!nrDiff] <- Array.max (Array.map2 (fun x y -> abs(x-y)) V2.[i,*] V2.[j,*])
                        maxDiffLines_i_j_V3.[!nrDiff] <- Array.max (Array.map2 (fun x y -> abs(x-y)) V3.[i,*] V3.[j,*])
                        nrDiff := !nrDiff+1
                   else ()
    let discordanceMatrixD1=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some ((Array.max (Array.mapi2 (fun k x y -> if V1.[i,k] < V1.[j,k] then abs(x-y) else 0.0) V1.[i,*] V1.[j,*]))/maxDiffLines_i_j_V1.[(i+j-1)%nrOfAlternatives]) else None)
    let discordanceMatrixD2=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some ((Array.max (Array.mapi2 (fun k x y -> if V2.[i,k] < V2.[j,k] then abs(x-y) else 0.0) V2.[i,*] V2.[j,*]))/maxDiffLines_i_j_V2.[(i+j-1)%nrOfAlternatives]) else None)
    let discordanceMatrixD3=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some ((Array.max (Array.mapi2 (fun k x y -> if V3.[i,k] < V3.[j,k] then abs(x-y) else 0.0) V3.[i,*] V3.[j,*]))/maxDiffLines_i_j_V3.[(i+j-1)%nrOfAlternatives]) else None)
    let discordanceMatrix=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some ((discordanceMatrixD1.[i,j].Value*discordanceMatrixD2.[i,j].Value*discordanceMatrixD3.[i,j].Value)**(1.0/3.0)) else None)
    discordanceMatrixD1 |> printResult "The discordance matrix D1 for V1 is:"
    discordanceMatrixD2 |> printResult "The discordance matrix D2 for V2 is:"
    discordanceMatrixD3 |> printResult "The discordance matrix D3 for V3 is:"
    discordanceMatrix

let generateConcordanceDominanceMatrix (concordanceMatrix : float option [,])=
    let thresholdValueConcordanceIndex =1.0/(convertedToFloatnrOfAlternatives*(convertedToFloatnrOfAlternatives-1.0))*(Array.sum (Array.init nrOfAlternatives (fun i ->  Array.sumBy (fun (y:float option) -> if y.IsSome then y.Value else 0.0) concordanceMatrix.[i,*])))
    let concordanceDominanceMatrix=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then (if concordanceMatrix.[i,j].Value >= thresholdValueConcordanceIndex then Some 1 else Some 0) else None)
    concordanceDominanceMatrix

let generateDiscordanceDominanceMatrix (discordanceMatrix : float option [,])=
    let thresholdValueDiscordanceIndex =1.0/(convertedToFloatnrOfAlternatives*(convertedToFloatnrOfAlternatives-1.0))*(Array.sum (Array.init nrOfAlternatives (fun i ->  Array.sumBy (fun (y:float option) -> if y.IsSome then y.Value else 0.0) discordanceMatrix.[i,*])))
    let discordanceDominanceMatrix=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then (if discordanceMatrix.[i,j].Value <= thresholdValueDiscordanceIndex then Some 1 else Some 0) else None)
    discordanceDominanceMatrix

let generateComprehensiveDominanceMatrix (concordanceDominanceMatrix: int option [,]) (discordanceDominanceMatrix: int option [,])=
    let comprehensiveDominanceMatrix=Array2D.init nrOfAlternatives nrOfAlternatives (fun i j -> if i<>j then Some(concordanceDominanceMatrix.[i,j].Value*discordanceDominanceMatrix.[i,j].Value) else None)
    comprehensiveDominanceMatrix

let generateTransitiveClosure (comprehensiveDominanceMatrix : int option [,])=
    let transitiveClosure=comprehensiveDominanceMatrix |> Array2D.map (fun x -> if x.IsSome then (x.Value<>0) else false)
    for k in 0..nrOfAlternatives-1 do
        for i in 0..nrOfAlternatives-1 do
            for j in 0..nrOfAlternatives-1 do
                transitiveClosure.[i,j] <- transitiveClosure.[i,j] || transitiveClosure.[i,k] && transitiveClosure.[k,j]
    transitiveClosure

let generatePowerOfReachingList (transitiveClosure : bool [,])=
    let graphHasCycles=(List.sum [for i in 0..nrOfAlternatives-1 do yield(if transitiveClosure.[i,i] then 1 else 0)])>0
    let powerOfReaching=[for i in 0..nrOfAlternatives-1 do yield(i+1, List.sum [for j in 0..nrOfAlternatives-1 do yield(if transitiveClosure.[i,j] then 1 else 0)])] |> List.sortBy snd |> List.rev
    if graphHasCycles then ("cycles" , powerOfReaching) 
        else 
            let isHamiltonianPath=List.sumBy snd powerOfReaching
            if isHamiltonianPath<>nrOfAlternatives*(nrOfAlternatives-1)/2 
                then ("no", powerOfReaching)  
                else
                    ("yes",powerOfReaching )

let getAgregatedFuzzyImportanceWeightArray (decisionMatrix : float [,])=
    decisionMatrix
    |> generateFuzzyDecisionMatrix 
    |> generateAgregatedFuzzyImportanceWeightArray

let resDM= () |> generateDecisionMatrix
printResult "The Decision Matrix is :" resDM
let resAFIWA =getAgregatedFuzzyImportanceWeightArray resDM
printResult "The aggregated fuzzy importance weight for each criterion is:" resAFIWA
let resNDM=generateNormalizedDecisionMatrix resDM
printResult "The Normalized Decision Matrix is :" resNDM
let V1,V2,V3=generateWeightedNormalizedDecisionMatrix resNDM resAFIWA
printResult "The Weighted Normalized Decision Matrix V1 is :" V1
printResult "The Weighted Normalized Decision Matrix V2 is :" V2
printResult "The Weighted Normalized Decision Matrix V3 is :" V3
let resCM= generateConcordanceMatrix V1 V2 V3 resAFIWA
printResult "The defuzzified concordance matrix is:" resCM
let resDiscM=generateDiscordanceMatrix  V1 V2 V3
printResult "The defuzzified discordance matrix is:" resDiscM
let resCDM=generateConcordanceDominanceMatrix resCM
printResult "The Concordance Dominance Matrix is:" resCDM
let resDDM=generateDiscordanceDominanceMatrix resDiscM
printResult "The Discordance Dominance Matrix is:" resDDM
let CompDM=generateComprehensiveDominanceMatrix resCDM resDDM
printResult "The Comprehensive Dominance Matrix is:" CompDM
let resTC=generateTransitiveClosure CompDM
printResult "The transitive clojure matrix is: " resTC
let resPORL=generatePowerOfReachingList resTC

if fst resPORL="cycles" then printfn "The Graph has Cycles.\n The Power Of Reaching List is : %A  " (snd resPORL)
    else if fst resPORL="no" then printfn "The Graph doesn't have a Hamiltonian Path.\n The Power Of Reaching List is : %A  " (snd resPORL)
        else printfn "The Graph does have a Hamiltonian Path.\n The Power Of Reaching List is : %A  " (snd resPORL)