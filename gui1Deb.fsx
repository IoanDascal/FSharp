open System
open System.Drawing
open System.Windows.Forms
open System.Windows.Forms.Design

let form=new Form(Width=600,Height=425,Text="first")
let button=new Button(Location = Point(30,40), 
                      Size = Size(50,25),
                      Text="click",
                      ForeColor=System.Drawing.Color.Red)

button.Click.Add(fun _ -> Application.Exit() |> ignore)
form.Controls.Add(button)

form.MouseDown
    |> Event.map (fun args -> printfn "%d %d" args.X args.Y)

[<STAThread>]
do Application.Run(form)
System.Console.ReadKey() |> ignore
