module Tests

open System
open Xunit
open RomanNumerals
open FsUnit.Xunit

module ``Converting one digit to integer`` =
    [<Fact>]
    let ``Given I digit should return 1`` () = I |> digitToInt |> should equal 1

    [<Fact>]
    let ``Given V digit should return 5`` () = V |> digitToInt |> should equal 5

    [<Fact>]
    let ``Given M digit should return 1000`` () = M |> digitToInt |> should equal 1000

module ``Converting digits to integer`` =
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
