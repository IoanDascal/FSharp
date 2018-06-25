(*
    Define a record to store data for a student.
*)

open System
type Student=
    {
        name: string
        grade1:float
        grade2: float
    }
printf "Enter the name of a student:"
let name=Console.ReadLine()
printf "Enter yhe math grade:"
let mathGrade=float(Console.ReadLine())
printf "Enter the physics grade:"
let physicsGrade=float(Console.ReadLine())
let student1={name=name;grade1=mathGrade;grade2=physicsGrade}
printfn ""
printfn "%A" student1
printfn ""
let student2=student1
printfn "%A" student2
let student3={student2 with name="gigi"}
printfn ""
printfn "%A" student3
