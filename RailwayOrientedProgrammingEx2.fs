(*
    Implement the expression:
     
  F(x)=sqrt(x)/(4-sqrt(x))-pow(x,3)+x/(log10(x))
*)
type Result<'TSuccess,'TFailure>=
    | Success of 'TSuccess
    | Failure of 'TFailure
let bind processFunc lastResult=
    match lastResult with
    | Success s -> processFunc s   
    | Failure f -> Failure f
let switch processFunc lastResult=
    Success (processFunc lastResult)
let root (x:float)=
    match x<0.0 with
    | true -> Failure (sprintf "Can't calculate the square root because x<0 ")
    | false -> Success (sqrt x)
let div1 x=
    match x=4.0 with
    | true -> Failure (sprintf "The denominator will be 0 if x=4.0 ")
    | false -> Success (x/(4.0-x))
let substract (x:float) (y:float)=
    y-x*x*x
let add x y=
    match x=0.0 with
    | true -> Failure (sprintf "Invalid argument for log function")
    | false -> match x=1.0 with
               | true -> Failure (sprintf "Log from 1 is 0")
               | false -> Success (y+x/(log10 x))
let F x=
    x 
    |> root 
    |> bind div1
    |> bind (switch (substract x))
    |> bind (add x)
    |> printfn "%A"
let res1=F 4.0
let res2=F 16.0
let res3=F 10.0
let res4=F 1.0
let res5=F -10.0