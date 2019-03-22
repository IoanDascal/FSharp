(*
    https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.label?view=netframework-4.7.2
    https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.textbox?view=netframework-4.7.2
    https://www.c-sharpcorner.com/uploadfile/f5b919/windows-form-application-in-fsharp/
*)

open System.Drawing
open System.Windows.Forms


//F# class declaration
type HelloGUI()=
    // Constructor initializes the user interface
    let form=new Form(Width=600, Height=400,Text="Hello World from GUI",BackColor=Color.Yellow)
    let label=
        let lb=new Label()
        lb.Width <- 550
        lb.Height <- 50
        lb.Location <- Point(10,60)
        lb.Font <- new Font("Arial",32.0f)
        lb
    let textBox=
        let tb=new TextBox(Text=" here is ")
        tb
    let readButton=
        let rb=new Button()
        rb.Text <- "Read from Text Box"
        rb.Width <- 150
        rb.Location <- Point(10,30)
        rb
    do form.Controls.Add(textBox)
    do form.Controls.Add(readButton)
    do form.Controls.Add(label)

    // Build and display the message
    member x.DisplayMessage()=
        readButton.Click.AddHandler(fun _ _ -> let message=textBox.Text
                                               label.Text <- "Hello "
                                               label.Text <- label.Text+ message
                                               ())
            
    // Run the application
    member x.Show()=
        form.ShowDialog()

let hello=HelloGUI()
hello.DisplayMessage()
hello.Show() |> ignore
    