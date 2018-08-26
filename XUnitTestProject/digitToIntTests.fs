module ``Converting one digit to integer``
    open Xunit
    open RomanNumeralsV1
    open FsUnit.Xunit
    [<Fact>]
    let ``Given I digit should return 1`` () = I |> digitToInt |> should equal 1

    [<Fact>]
    let ``Given V digit should return 5`` () = V |> digitToInt |> should equal 5

    [<Fact>]
    let ``Given M digit should return 1000`` () = M |> digitToInt |> should equal 1000