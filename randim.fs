let random=System.Random()
//An infinite sequence of numbers
let randomNumbers=seq {while true do yield random.Next(100000)}
//The first 100 random numbers, sorted
let first100RandNumbers=
    randomNumbers
        |> Seq.truncate 100
        |> Seq.sort
        |> Seq.toList

//The first 3000 even random numbers and sort them
let first3000EvenNumbers=
    randomNumbers
    |> Seq.filter (fun i -> i%2=0)
    |> Seq.truncate 3000
    |> Seq.sort
    |> Seq.map (fun i -> i,i*i) 
    |> Seq.toList