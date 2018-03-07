(*
                Instruction pointers and the stack
        Whenever  you call a function the instruction pointer (address in the program code that
    identifies the next operation to execute) is pushed on the stack. Once the function returns a value, 
    the stack is cleared and the instruction pointer is restored. Resuming the program in
    its previous state.
        Tail recursion is a specialized type of recursion where there is a guarantee that nothing is 
    left to execute in the function after a recursive call. In other words the function returns the result 
    of a recursive call.
        If there is no additional instructions to execute, then there is no need to store the instruction 
    pointer on the stack, since the only thing left to do once the recursive call exits is restore the stack.
    So rather than needlessly modifying the stack, tail calls use a GOTO statement for the recursion.
    And once the recursion eventually succeeds the function will return to the original instruction pointer location.
*)

let factorial x=
    ///Keep track of both x and an accumulator value acc
    let rec tailRecursiveFactorial x acc=
        if x<=1I then 
            acc
        else
            tailRecursiveFactorial (x-1I) (acc*x)
    tailRecursiveFactorial x 1I

[1I..45I] |>Seq.iter (fun x -> printfn "Factorial de %O = %O" x (factorial x))