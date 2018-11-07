(*
    Implement in F# next C++ snippet:
    char s[20],result[20];
    int j=0;
    cin>>s;
    x=strlen(s);
    for (i=0;i<x/2;i++)
    {    
        result[j]=s[i];
        result[j+1]=s[x-i-1];
        j+=2;
    }
    if(x%2==1)
        result[j]=s[x/2];

    Example: EAENMX  -->  EXAMEN
*)

open System
printf "Enter a string :"
let initialString=Console.ReadLine()
let modifyString (initialString:string) =
    let x=initialString.Length
    let charArray=Array.create<char> x ' '
    let mutable j=0
    for i in 0..x/2-1 do
        charArray.[j] <- initialString.[i] 
        charArray.[j+1] <- initialString.[x-i-1]
        j <- j+2
    if x%2=1 then charArray.[j] <- initialString.[x/2]
    let result=new string(charArray)
    result
printfn "%s" (modifyString initialString)
