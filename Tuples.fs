(*
        A tuple is defined as a comma separated collection of values.
    For example (10, "hello") is a tuple with the type (int*string).
    Parentheses are not part of the tuple but it is often necessary to
    add them to ensure that the tuple only includes what you think it includes.
        A tuple is considered a single argument. As a result tuples can be used
    to return multiple values. Every tuple has a property called arity, which
    is the number of arguments used to define a tuple.
        F# has two built in functions, fst and snd, which return the first and
    second items in a 2-tuple. These functions are defined as follows:
        let fst (a,b) = a
        let snd (a,b) = b

         https://en.wikibooks.org/wiki/F_Sharp_Programming/Tuples_and_Records   
*)

let f=fst (10,20)
let s=snd (10,20)

/// Ex1 : A function which multiplies a 3-tuple by a scalar value to return another 3-tuple
let scalarMultiply (s:float) (a,b,c)=(a*s,b*s,c*s)
let res=scalarMultiply 5.0 (2.0,4.0,5.0)

///Ex2 : A function which reverses the input of whatever is passed into the function. 
let swap (a,b)=(b,a)
let inter=swap("aaa",6)

/// Ex3 : A function which divides two numbers and returns the remainder simultaneously
let divrem x y=
    match y with
    | 0 -> None
    | _ -> Some(x/y, x%y)

let resdiv = divrem 10 3

///      Pattern Matching Tuples
/// Ex1 : Let's say we have a function greeting that prints out a
///        custom greeting based on the specified name and/or language
let greeting (name,language)=
    match (name,language) with
    | ("Steve",_) -> "Howdy Steve"
    | (name,"English") -> "Hello "+name
    | (name,_) when language.StartsWith("Span") -> "Hola "+name
    | (_,"French") -> "Bonjour"
    | _ -> "Does not compute"

let res2= greeting ("Steve","English")
let res3= greeting ("Roco","Chinese")
let res4= greeting ("Pierre","French")

/// Ex2 : We can conveniently match against the shape of a tuple using the 
///       alternative pattern matching syntax
let getLocation=function
    | (0,0) -> "origin"
    | (0,y) -> "on the y-axis at y="+y.ToString()
    | (x,0) -> "on the x axis at x="+x.ToString()
    | (x,y) -> "at x="+x.ToString()+"  y="+y.ToString()

let res5= getLocation (0,0)
let res6= getLocation (10,-5)

///     Assigning Multiple Variables Simultaneously
/// Tuples can be used to assign multiple values simultaneously. The syntax for doing so is: 
///   let val1,val2,val3,... valN = (expr1,expr2,expr3,... exprN)
let x,y,z = (1,2,30)
printfn "x=%i" x
printfn "y=%i" y 
printfn "z=%i" z