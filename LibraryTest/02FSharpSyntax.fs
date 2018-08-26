namespace LibraryTest

module FSharpSyntax =
    let myInt = 5
    let myFloat = 3.14f
    let twoToFive = [2;3;4;5]
    let oneToFive = 1 :: twoToFive
    let zeroToFive = [0;1] @ twoToFive

    let square x = x * x
    square 3

    let add x y = x + y
    add 2 3

    let evens list =
        let isEven x = x%2 = 0
        List.filter isEven list

    evens oneToFive

    let sumSquaresTo100 =
        List.sum (List.map square [1..100])

    let sumSquaresTo100Piped =
        [1..100] |> List.map square |> List.sum

    let sumSquaresTo100WithFun =
        [1..100] |> List.map (fun x->x*x) |> List.sum

    let simplePatternMatch =
        let x = "a"
        match x with
        | "a" -> printfn "x is a"
        | "b" -> printfn "x is b"
        | _ -> printfn "x is something else"

    let validValue = Some(99)
    let invalidValue = None

    let optionPatternMatch input =
        match input with
        | Some i -> printfn "input is an int=%d" i
        | None -> printfn "input is missing"

    optionPatternMatch validValue
    optionPatternMatch invalidValue

    let twoTuple = 1,2
    let threeTuple = "a",2,true

    type Person = {First:string; Last:string}
    let person1 = {First="john"; Last="Doe"}

    type Temp =
        | DegressC of float
        | DegreesF of float
    let temp = DegreesF 98.6

    type Employee =
        | Worker of Person
        | Manager of Employee list
    let jdoe = {First="John"; Last="Doe"}
    let worker = Worker jdoe