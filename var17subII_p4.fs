(*
    Implement in F# next C++ snipet.
 strcpy(a,”bacalaureat”);
 cout<<strlen(a)<<endl;
 for(i=0;i<strlen(a);i++)
     if(strchr(”aeiou”,a[i])!=0)
         cout<<’*’;    
*)
let s="bacalaureat"
printfn "%i" s.Length
let isVowel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false

let res=String.iter (fun x -> if isVowel x then printf "*" else ()) s