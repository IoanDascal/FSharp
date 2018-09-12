(*
    https://msdn.microsoft.com/visualfsharpdocs/conceptual/mailboxprocessor.tryreceive%5b%27msg%5d-method-%5bfsharp%5d

    Signature:
    member this.TryReceive : ?int -> Async<'Msg option>

    Usage:
    mailboxProcessor.TryReceive()
    mailboxProcessor.TryReceive(timeout=timeout)
*)

open System
type Message=string*AsyncReplyChannel<string>
let formatString="Message number {0} was received. Message contents: {1}"
let agent=MailboxProcessor<Message>.Start(fun inbox ->
    let rec loop n=
        async{
            let! opt=inbox.TryReceive(5000)
            match opt with  
            | None -> do! loop (n+1)
            | Some (message,replyChannel) -> if message="Stop" then  
                                                 replyChannel.Reply("Stop")
                                             else
                                                 replyChannel.Reply(String.Format(formatString,n,message))
                                             do! loop (n+1)
        }
    loop 0
)
printfn "Mailbox Processor Test"
printfn "Type some text and press Enter to submit a message."
printfn "Type 'Stop' to close the program."

let mutable isCompleted=false
while (not isCompleted) do 
    printf ">"
    let input=Console.ReadLine()
    let reply=agent.PostAndReply(fun replyChannel -> input,replyChannel)
    if reply<>"Stop" then
        printfn "Reply: %s" reply
    else
        isCompleted <- true
printfn "Press Enter to continue"
Console.ReadLine() |> ignore