module ``Converting string to RomanNumeral``
    open Xunit
    open RomanNumeralsV1
    open FsUnit.Xunit

    [<Fact>]
    let ``Given IIII should return parsed value`` () = "IIII" |> toRomanNumeral |> should equal (RomanNumeral [I;I;I;I])

    [<Fact>]
    let ``Given IV should return parsed value`` () = "IV" |> toRomanNumeral |> should equal (RomanNumeral [I;V])

    [<Fact>]
    let ``Given VI should return parsed value`` () = "VI" |> toRomanNumeral |> should equal (RomanNumeral [V;I])

    [<Fact>]
    let ``Given IX should return parsed value`` () = "IX" |> toRomanNumeral |> should equal (RomanNumeral [I;X])

    [<Fact>]
    let ``Given MCMLXXIX should return parsed value`` () = "MCMLXXIX" |> toRomanNumeral |> should equal (RomanNumeral [M;C;M;L;X;X;I;X])

    [<Fact>]
    let ``Given MCMXLIV should return parsed value`` () = "MCMXLIV" |> toRomanNumeral |> should equal (RomanNumeral [M;C;M;X;L;I;V])

    [<Fact>]
    let ``Given empty string should return empty value`` () = "" |> toRomanNumeral |> should equal (RomanNumeral [])

    [<Fact>]
    let ``Given MC?I should ignore invalid characters`` () = "MC?I" |> toRomanNumeral |> should equal (RomanNumeral [M;C;I])

    [<Fact>]
    let ``Given abc should return empty value`` () = "abc" |> toRomanNumeral |> should equal (RomanNumeral [])