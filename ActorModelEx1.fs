(*
    https://fsharpforfunandprofit.com/posts/concurrency-actor-model/
    https://en.wikibooks.org/wiki/F_Sharp_Programming/MailboxProcessor
*)

let printerAgent=MailboxProcessor.Start(fun inbox ->
    let rec messageLoop()=async{
        let! msg=inbox.Receive()
        printfn "Message is:%s" msg 
        return! messageLoop()
    }
    messageLoop()
)

printerAgent.Post "hello"
for i in 1 ..100 do  
    printerAgent.Post ("hello  "+string(i))

let counter=MailboxProcessor.Start(fun inbox -> 
        let rec loop n=
            async{
                do printfn "n=%d, waiting..." n
                let! msg=inbox.Receive()
                return! loop(n+msg)
            }
        loop 0
    )
counter.Post 5
counter.Post 15

type msg=
    | Incr of int  
    | Fetch of AsyncReplyChannel<int>
let counterReply = MailboxProcessor.Start(fun inbox ->
        let rec loop n=
            async{
                let! msg=inbox.Receive()
                match msg with
                | Incr x -> return! loop (n+x)
                | Fetch replyChannel -> replyChannel.Reply(n)
                                        return! loop n
            }
        loop 0
    )

counterReply.Post (Incr 7)
counterReply.Post (Incr 77)
let res=counterReply.PostAndReply (fun replayChannel -> Fetch replayChannel)
printfn "%i" res
