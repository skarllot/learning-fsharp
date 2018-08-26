module ``Converting string to RomanNumeral``
    open Xunit
    open RomanNumeralsV2
    open FsUnit.Xunit

    type TestData =
        static member StringData : obj[][] =
            [|
                [|"IIII";     RomanNumeral [IIII]|]
                [|"IV";       RomanNumeral [IV]|]
                [|"VI";       RomanNumeral [V;I]|]
                [|"IX";       RomanNumeral [IX]|]
                [|"MCMLXXIX"; RomanNumeral [M;CM;L;XX;IX]|]
                [|"MCMXLIV";  RomanNumeral [M;CM;XL;IV]|]
                [|"";         RomanNumeral []|]
                [|"MC?I";     RomanNumeral [M;C;I]|]
                [|"abc";      RomanNumeral []|]
            |]

    [<Theory; MemberData("StringData", MemberType=typeof<TestData>)>]
    let ```Give a string should return parsed roman numeral`` s (expected:RomanNumeral) =
        s |> toRomanNumeral |> should equal expected