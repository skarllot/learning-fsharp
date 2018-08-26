module ``Converting one digit to integer``
    open Xunit
    open RomanNumeralsV2
    open FsUnit.Xunit

    type TestData =
        static member DigitsData : obj[][] =
            [|
                [|I;1|]
                [|III;3|]
                [|V;5|]
                [|CM;900|]
                [|M;1000|]
            |]

    [<Theory; MemberData("DigitsData", MemberType=typeof<TestData>)>]
    let ``Given one digit should return the equivalent number`` digit (expected:int) = digit |> digitToInt |> should equal expected