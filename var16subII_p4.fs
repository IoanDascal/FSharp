(*
    Implement in F# next C++ snipet:
k=’a’-’A’;
strcpy(a,”clasa a-XII-a A”);
cout<<a<<endl;
for(i=0;i<strlen(a);i++)
    if(a[i]>=’a’&& a[i]<=’z’) 
        a[i]=a[i]-k;
cout<<a;
*)
let aStr="clasa a-XII - a A"
printfn "A=%i" (int 'A')
printfn "a=%i" (int 'a')
let k=(int 'a')-(int 'A')
printfn "%A" ((int 'b')-k)

let res1=String.map (fun x -> if (System.Char.IsLower x) then char((int x)-k) else x) aStr
printfn "res1=%s" res1