(*
    http://strangelights.com/blog/archive/2007/10/24/1601.aspx
*)

open System
open System.IO
open System.ComponentModel
open System.Threading
type Message=
    | Word of string 
    | Fetch of AsyncReplyChannel<Map<string,int>> 
    | Stop
    | EmptyMap

let keys (m: Map<'Key, 'T>) =
    Map.fold (fun keys key _ -> key::keys) [] m
let emptyMap map kys=
    let rec loop map kys=
        match kys with
        | [] -> map
        | hd::tail -> let map=Map.remove hd map
                      loop map tail
    loop map kys

type WordCountingAgent()=
    let counter=MailboxProcessor.Start(fun inbox ->
        let rec loop (words:Map<string,int>)=
            async{
                let! msg=inbox.Receive()
                match msg with
                | Word word -> if words.ContainsKey word then
                                   let count=words.[word]
                                   let words=words.Remove word
                                   return! loop (words.Add (word,(count+1)))
                               else
                                   return! loop (words.Add (word,1))
                | Stop -> return ()
                | Fetch replyChannel -> do replyChannel.Reply words
                                        return! loop words
                | EmptyMap -> let kys=keys words
                              let words=emptyMap words kys
                              return! loop words
            }
        loop Map.empty
    )
    member a.AddWord n =counter.Post (Word n)
    member a.Stop()=counter.Post Stop
    member a.Fetch()=counter.PostAndReply (fun replyChannel -> Fetch replyChannel)
    member a.EmptyMap()=counter.Post EmptyMap


let readLines file=
    [
        use r=new StreamReader (File.OpenRead file)
        while not r.EndOfStream do yield r.ReadLine()
    ]

let counter=WordCountingAgent()
let processFile file=
    let lines=readLines file
    let punctuation=[|' ';'.';'"';''';',';';';':';'!';'?';'-';'(';')';'*';'%';'{';'}';'=';'<';'>';'/';'[';']';'0';'1';'2';'3';'4';'5';'6';'7';'8';'9';'#'|]
    for line in lines do
        printfn "%s" line
        let words=line.Split punctuation
        for word in words do
            if word.Length>0 then
                counter.AddWord word  
    
let main() =
    let files = Directory.GetFiles(@"C:\Users\Nelu\Documents\testFSharp")
    for file in files do
        printfn "Starting '%s'" (Path.GetFileNameWithoutExtension file)
        processFile file
        let result=counter.Fetch()
        printfn "The number of words is=%i" result.Count
        for KeyValue (w,n) in result do
            printfn "Number of: %25s word is %5d" w n
        printfn "Finished '%s'" (Path.GetFileNameWithoutExtension file)
        counter.EmptyMap()
    counter.Stop()

main() 