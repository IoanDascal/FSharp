(*
    https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/async.startwithcontinuations%5b't%5d-method-%5bfsharp%5d
    Runs an asynchronous computation, starting immediately on the current operating 
system thread. Call one of the three continuations when the operation completes.

    // Signature:
    static member StartWithContinuations : Async<'T> * ('T -> unit) * (exn -> unit) * (OperationCanceledException -> unit) * ?CancellationToken -> unit

    // Usage:
    Async.StartWithContinuations (computation, continuation, exceptionContinuation, cancellationContinuation)
    Async.StartWithContinuations (computation, continuation, exceptionContinuation, cancellationContinuation, cancellationToken = cancellationToken)

    https://msdn.microsoft.com/en-us/visualfsharpdocs/conceptual/async.canceldefaulttoken-method-%5bfsharp%5d
    Raises the cancellation condition for the most recent set of asynchronous 
computations started without any specific cancellation token. Replaces the global 
System.Threading.CancellationTokenSource object with a new global token source for 
any asynchronous computations created after this point without any specific cancellation token.

    // Signature:
    static member CancelDefaultToken : unit -> unit

    // Usage:
    Async.CancelDefaultToken ()
*)


open System.Windows.Forms

let bufferData = Array.zeroCreate<byte> 1000000

let async1 (label:System.Windows.Forms.Label) filename =
     Async.StartWithContinuations(
         async {
            label.Text <- "Operation started."
            use outputFile = System.IO.File.Create(filename)
            use outputFile1 = System.IO.File.Create("longout.dat")
            do! outputFile.AsyncWrite(bufferData)
            do! outputFile1.AsyncWrite(bufferData)
            },
         (fun _ -> label.Text <- "Operation completed."),
         (fun _ -> label.Text <- "Operation failed."),
         (fun _ -> label.Text <- "Operation canceled."))
    
  

let form = new Form(Text = "Test Form")
let button1 = new Button(Text = "Start")
let button2 = new Button(Text = "Start Invalid", Top = button1.Height + 10)
let button3 = new Button(Text = "Cancel", Top = 2 * button1.Height + 20)
let label1 = new Label(Text = "", Width = 200, Top = 3 * button1.Height + 30)
form.Controls.AddRange [| button1; button2; button3; label1 |]
button1.Click.Add(fun args -> async1 label1 "longoutput.dat")
// Try an invalid filename to test the error case.
button2.Click.Add(fun args -> async1 label1 "|invalid.dat")
button3.Click.Add(fun args -> Async.CancelDefaultToken())
form.ShowDialog() |> ignore