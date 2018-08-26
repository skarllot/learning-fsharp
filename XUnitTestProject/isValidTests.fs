module ``Convert string to roman numeral and validate it``
    open FsUnit.Xunit
    open RomanNumeralsV2
    open Xunit

    [<Theory>]
    [<InlineData("IIII")>]
    [<InlineData("IV")>]
    [<InlineData("IX")>]
    [<InlineData("VX")>]
    [<InlineData("XIV")>]
    [<InlineData("XIX")>]
    [<InlineData("XXII")>]
    [<InlineData("")>]
    let ``Given a valid string should return true`` s = s |> toRomanNumeral |> isValid |> should equal true

    [<Theory>]
    [<InlineData("IIIII")>]
    [<InlineData("VV")>]
    [<InlineData("LL")>]
    [<InlineData("DD")>]
    [<InlineData("IIV")>]
    [<InlineData("XXXM")>]
    [<InlineData("CCCCD")>]
    [<InlineData("IVX")>]
    [<InlineData("XLD")>]
    [<InlineData("IIXX")>]
    let ``Given a invalid string should return false`` s = s |> toRomanNumeral |> isValid |> should equal false