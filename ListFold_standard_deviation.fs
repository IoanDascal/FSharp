///     List.fold 
///     A "fold" operation applies a function to each element in a list,
/// aggregates the result of the function in an accumulator variable,
/// and returns the accumulator as the result of the fold operation.

let stdevSkew (input : float list)=
    let sampleSize=float input.Length
    let mean=(input |> List.fold (+) 0.0 )/sampleSize
    let differenceOfSquares=
        input |> List.fold (fun sum item -> sum+ pown (item-mean) 2) 0.0
    let variance=differenceOfSquares/sampleSize
    let stddev=sqrt variance
    let differenceOfCubes=
        (input |> List.fold (fun sum item -> sum + pown (item-mean) 3) 0.0)/sampleSize
    let skew=(sqrt (sampleSize*(sampleSize-1.0)) )/(sampleSize-2.0)*differenceOfCubes/(pown stddev 3)
    let differenceOfQuad=
        (input |> List.fold (fun sum item -> sum + pown (item-mean) 4) 0.0)/sampleSize
    let kurt=differenceOfQuad/(pown variance 2)
    printfn "mean=%f" mean
    printfn "Standard deviation=%f" stddev
    printfn "Skewness=%f" skew
    printfn "Kurtosis=%f" kurt
    
let x=stdevSkew [5.0; 6.0;6.5;6.6;6.7;6.8;6.85;7.0;7.15;7.2;7.3;7.4;7.5; 8.0; 9.0]