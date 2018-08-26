module ``Converting digits to integer``
    open Xunit
    open RomanNumeralsV2
    open FsUnit.Xunit

    type TestData =
        static member DigitsData : obj[][] =
            [|
                [|[IIII];4|]
                [|[IV];4|]
                [|[V;I];6|]
                [|[IX];9|]
                [|[M;CM;L;X;X;IX];1979|]
                [|[M;CM;XL;IV];1944|]
            |]

    [<Theory; MemberData("DigitsData", MemberType=typeof<TestData>)>]
    let ``Give a list of digits should return the equivalent number`` digits (expected:int) =
        digits |> digitsToInt |> should equal expected

    [<Theory; MemberData("DigitsData", MemberType=typeof<TestData>)>]
    let ``Give a roman numeral should return the equivalent number`` digits (expected:int) =
        digits |> RomanNumeral |> toInt |> should equal expected