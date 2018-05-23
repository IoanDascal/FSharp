(*
    Given a string that contains only lowercase letters, 
eliminate the last consonant.
Ex:  bingo is a simple game  ---->  bingo is a simple gae
*)

printf "Enter a string : "
let text=System.Console.ReadLine()
//let reverseText (text:string)=
  //  string(Array.rev (text.ToCharArray()))
let isVowel ch=
    match ch with
    | 'a' | 'e' | 'i' | 'o' | 'u' -> true
    | _ -> false
let consonants=[|for (ch:char) in 'a'..'z' do
                     if not (isVowel ch) then yield ch|]
let lastIndexOfConsonant=text.LastIndexOfAny consonants
let res=text.[..lastIndexOfConsonant-1]+ text.[lastIndexOfConsonant+1..]