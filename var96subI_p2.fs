(*
read n ( natural number n>0) 
┌ for i <- 1,n do
│┌ for j <- 1,n do
││┌ for k <- 1,n do
│││┌ if i<j<k then
││││┌ if i+j+k=n then
│││││    write i,' ',j,' ',k 
│││││    go to new line
││││└■
│││└■
││└■
│└■
└■
*)

printf "n="
let n=int32(System.Console.ReadLine())
let rec iLoop i=
    match i<=n with
    | false -> ()
    | true -> let rec jLoop j=
                  match j<= n with
                  | false -> iLoop (i+1)
                  | true -> let rec kLoop k=
                                match k<=n with
                                | false -> jLoop (j+1)
                                | true -> match (i<j && j<k) with
                                          | false -> kLoop (k+1)
                                          | true -> match i+j+k=n with
                                                    | true -> printfn "%i  %i  %i" i j k
                                                              kLoop (k+1)
                                                    | false -> kLoop (k+1)
                            kLoop 1
              jLoop 1

let res=iLoop 1
