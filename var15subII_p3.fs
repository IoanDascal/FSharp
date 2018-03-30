(*
    Implement in F# next C++ snipet :
 i=0; 
 char s[11]="abaemeiut";
 cout<<strlen(s); 
 while (i<strlen(s))
     if (strchr("aeiou",s[i])!=NULL))
     { 
         strcpy(s+i,s+i+1);
         i=i+1; 
     }
     else
         i=i+2;
 cout<<" "<<s; 
*)
let s="abaemeiut"
printfn "%i" s.Length
let n=s.Length
let isVowel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false

let rec whileLoop i (s:string)=
    match i=n-1 with
    | true -> s
    | false -> match (isVowel s.[i]) with
               | true -> let s=s.Replace(s.[i],' ')
                         whileLoop (i+2) s
               | false -> whileLoop (i+2) s

let str=whileLoop 0 s
let str1=str.Split([|' '|]) |> String.concat ""
printfn "%A" str1



