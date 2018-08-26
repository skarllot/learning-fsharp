module ``Convert string to roman numeral and validate it``
    open FsUnit.Xunit
    open RomanNumeralsV1
    open Xunit

    [<Fact>]
    let ``Given IIII should return true`` () = "IIII" |> toRomanNumeral |> isValid |> should equal true

    [<Fact>]
    let ``Given IV should return true`` () = "IV" |> toRomanNumeral |> isValid |> should equal true

    [<Fact>]
    let ``Given XIV should return true`` () = "XIV" |> toRomanNumeral |> isValid |> should equal true

    [<Fact>]
    let ``Given MMDXC should return true`` () = "MMDXC" |> toRomanNumeral |> isValid |> should equal true

    [<Fact>]
    let ``Given emptry string should return true`` () = "" |> toRomanNumeral |> isValid |> should equal true

    [<Fact>]
    let ``Given IIXX should return false`` () = "IIXX" |> toRomanNumeral |> isValid |> should equal false

    [<Fact>]
    let ``Given VV should return false`` () = "VV" |> toRomanNumeral |> isValid |> should equal false