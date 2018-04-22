(*
    Implement in F# next C++ function:
 void F(int i, int &x) 
 { 
    if (i <= 10) 
    {    
        if(i % 2)  
            x = x + 2; 
        else       
            x = x – 1; 
        F(i + 1, x); 
    }   
 } 
*)

let rec F i (x:int)=
    match i<=10 with
    | false -> x
    | true -> let x=if i%2=1 then
                        x+2
                    else
                        x-1
              F (i+1) x

let x=F 1 0
printfn "%i" x
              