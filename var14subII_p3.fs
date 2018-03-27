(*
    Implement in F# next C++ snipet:
char s[11]="abcduecda";
cout<<strlen(s);
i=0; j=strlen(s)-1;
while (i<j)
    if (s[i]==s[j])
    { 
        strcpy(s+j,s+j+1);
        strcpy(s+i,s+i+1); 
        j=j-2;
    }
    else
    { 
        i=i+1; 
        j=j-1; 
    }
cout<<" "<<s;    
*)
let s= "abcduecda"
printfn "%i" s.Length
let rec eliminate i j (str:string)=
    match i=j with
    | true -> str
    | false -> match str.[i]=str.[j] with
               | true -> let str=str.Replace(str.[i],' ')
                         let str=str.Replace(str.[j],' ')
                         eliminate (i+1) (j-1) str 
               | false -> eliminate (i+1) (j-1) str

let res=eliminate 0 (s.Length-1) s 
printfn "%s" res
let res1=res.Split([|' '|]) |>String.concat ""
printfn "%A" res1 