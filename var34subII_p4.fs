(*
    Implement in F# next C++ snippet:
    char c[21]="tamara",*p;
    for(i=0;i<strlen(c);i=i+1)
    {
         p=strchr(c,'a');
        cout<<p-c;
    }
*)

let c="timorc"
for i in 1..c.Length do
    let p=c |> Seq.tryFindIndex (fun x -> x='a')
    if p.IsSome then printf "%d" p.Value
printfn ""