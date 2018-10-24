(*
    https://msdn.microsoft.com/en-gb/visualfsharpdocs/conceptual/mailboxprocessor.postandasyncreply%5b'msg,'reply%5d-method-%5bfsharp%5d
    // Signature:
    member this.PostAndAsyncReply : (AsyncReplyChannel<'Reply> -> 'Msg) * ?int -> Async<'Reply>

    // Usage:
    mailboxProcessor.PostAndAsyncReply (buildMessage)
    mailboxProcessor.PostAndAsyncReply (buildMessage, timeout = timeout)

    Example:
    The following code example shows a mailbox processor agent that uses PostAndAsyncReply. 
The return value of PostAndAsyncReply is an asynchronous workflow, which in this example is 
started by using Async.StartWithContinuations, to set up the code that handles the reply.
*)

open System
type Message=string*AsyncReplyChannel<string>
let formatString="Message number {0} was received. Message contents: {1}"
let agent=MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n=
        async{
            let! (message,replyChannel)=inbox.Receive()
            //Delay so that the responses come in a different order
            do! Async.Sleep(5000-1000*n)  
            replyChannel.Reply(String.Format(formatString,n,message)) 
            do! loop (n+1)
        }
    loop 0
)
 
printfn "MailboxProcessor Test:"
printfn "Type some text and press Enter to submit a message."
while true do  
    printf ">"
    let input=Console.ReadLine()
    let messageAsync=agent.PostAndAsyncReply(fun replyChannel -> input,replyChannel)
    // Set up a continuation function (the first argument below) that prints the reply.
    // The second argument is the exception continuation (not used).
    // The third argument is the cancellation continuation (not used).
    Async.StartWithContinuations(messageAsync,(fun reply -> printfn "%s" reply),(fun _ -> ()),(fun _ -> ()))

printfn "Press Enter to continue"
Console.ReadLine() |> ignore