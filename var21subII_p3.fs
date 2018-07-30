(*
   Define a record to store data for a type Student with fields: name, 
average grade and birthday date. Write a funtion to initialize fields from
the Student record, and another function to modify the value of a field.
*)
type Data=
    {
        Day:int;
        Month:int;
        Year:int
    }
type Student= 
    {
        Name:string;
        Average:float;
        Birthday:Data
    }
let initialize nm avg d m y=
    {
        Student.Name=nm;
        Student.Average=avg;
        Student.Birthday={day=d;month=m;year=y}
    }

let student=initialize "John" 7.30 12 5 2000
printfn "%A" student
let setName item newName={item with Name=newName}
let geo=setName student "George"
printfn "%A" geo