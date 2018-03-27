(*
    Implement in F# next C++ code :
char s[13]="abcdefghoid"; 
i=0; 
cout<<strlen(s); 
while (i<strlen(s)) 
  if (strchr("aeiou",s[i])!=NULL) 
    strcpy(s+i,s+i+1); 
  else i++; 
cout<<" "<<s;
*)
let s="abcdefghoid"
let isVowel x e=not (Seq.exists ((=) e) x)
let consonants str=
    Seq.filter (isVowel "aeiou") str
let s1=consonants s
printfn "%A" (s1 |> Seq.map string |> String.concat "")