(*
    Implement in F# next C++ program sequence :
    char s[]=”arac”;
    t=s[1]; s[1]=s[3];
    s[3]=’t’;
    cout<<s;
*)
let s="arac"
let res=String.mapi (fun i c -> if i=1 then s.[3] 
                                    else if i=3 then 't' 
                                        else c) s
printfn "%s" res