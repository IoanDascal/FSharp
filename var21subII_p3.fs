open System
type Data=
    {
        zi:int;
        luna:int;
        an:int
    }
type Elev= 
    {
        nume:string;
        media:float;
        dataNasterii:Data
    }
let initializare nm med z l a=
    {
        Elev.nume=nm;
        Elev.media=med;
        Elev.dataNasterii={zi=z;luna=l;an=a}
    }
let elev=initializare "dorel" 7.30 12 5 2000
printfn "%A" elev
let setNume item numeNou={item with nume=numeNou}
let gal=setNume elev "Galez"
printfn "%A" gal