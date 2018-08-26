module ``Converting digits to integer``
    open Xunit
    open RomanNumeralsV1
    open FsUnit.Xunit

    [<Fact>]
    let ``Given IIII digits should return 4`` () = RomanNumeral [I;I;I;I] |> toInt |> should equal 4

    [<Fact>]
    let ``Given IV digits should return 4`` () = [I;V] |> digitsToInt |> should equal 4

    [<Fact>]
    let ``Given VI digits should return 6`` () = [V;I] |> digitsToInt |> should equal 6

    [<Fact>]
    let ``Given IX digits should return 9`` () = [I;X] |> digitsToInt |> should equal 9

    [<Fact>]
    let ``Given MCMLXXIX digits should return 1979`` () = RomanNumeral [M;C;M;L;X;X;I;X] |> toInt |> should equal 1979

    [<Fact>]
    let ``Given MCMXLIV digits should return 1944`` () = [M;C;M;X;L;I;V] |> digitsToInt |> should equal 1944