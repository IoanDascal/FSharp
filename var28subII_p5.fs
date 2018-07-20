(*
    Given an input string write a program that eliminates only one 
vowel at a time and print the new string, if it exists.
*)
let s="instantaneously"

let vowelOut inputString ch=
    let removeVowel ch=
        String.collect (fun c -> if c=ch then sprintf ""
                                 else sprintf "%c" c) inputString
    let str=removeVowel ch
    if str.Length<> s.Length then printfn "%s" str
let vowels="aeiou"
let res=String.iter (fun x -> vowelOut s x) vowels