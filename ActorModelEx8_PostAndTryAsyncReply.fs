(*
    https://msdn.microsoft.com/en-gb/visualfsharpdocs/conceptual/mailboxprocessor.postandtryasyncreply%5b'msg,'reply%5d-method-%5bfsharp%5d
    // Signature:
    member this.PostAndTryAsyncReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> Async<'Reply option>

    // Usage:
    mailboxProcessor.PostAndTryAsyncReply (buildMessage)
    mailboxProcessor.PostAndTryAsyncReply (buildMessage, timeout = timeout)

*)

open System
type Message=string*AsyncReplyChannel<string>
let formatString="\nMessage number {0} was received. Message contents:{1}"
let agent=MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n=
        async{
            let! (message,replyChannel)=inbox.Receive();
            printfn "Mes %s" message
            do! Async.Sleep(200*n);
            if message="Stop" then
                replyChannel.Reply("Stop")
       
            else
                replyChannel.Reply(String.Format(formatString,n,message))
                return! loop (n+1)
        }
    loop 0
)
let mutable isCompleted = false

printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

(*printf ">="
let input=Console.ReadLine()
let messageAsync=agent.PostAndTryAsyncReply((fun replyChannel -> input,replyChannel),1000)
    // Set up a continuation function (the first argument below) that prints the reply.
    // The second argument is the exception continuation.
    // The third argument is the cancellation continuation (not used).
Async.StartWithContinuations(messageAsync,(fun reply -> match reply with
                                                        | None -> printfn "Reply timeout exceeded"
                                                        | Some reply -> if reply="Stop" then
                                                                             printfn "stopp"
                                                                             isCompleted <- true
                                                                         else printfn "----%s" reply),
                                           (fun exn -> printfn "Exception occured: %s" exn.Message),
                                           (fun _ -> ())
                                 )
printfn "%b" isCompleted
Stop*)





while (not isCompleted) do  
    printf ">="
    let input=Console.ReadLine()
    if input="Stop" then
        isCompleted <- true
    let messageAsync=agent.PostAndTryAsyncReply((fun replyChannel -> input,replyChannel),1000)
    // Set up a continuation function (the first argument below) that prints the reply.
    // The second argument is the exception continuation.
    // The third argument is the cancellation continuation (not used).
    Async.StartWithContinuations(messageAsync,(fun reply -> match reply with
                                                            | None -> printfn "Reply timeout exceeded"
                                                            | Some reply -> if reply="Stop" then
                                                                                isCompleted <- true
                                                                                printfn "complet11=%b" isCompleted
                                                                            else printfn "%s" reply),
                                               (fun exn -> printfn "Exception occured: %s" exn.Message),
                                               (fun _ -> ())
                                 )
    printfn "complet=%b" isCompleted

printfn "Press Enter to continue"
Console.ReadLine() |> ignore