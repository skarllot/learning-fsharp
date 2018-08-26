module ``Validate digit list``
    open FsUnit.Xunit
    open RomanNumeralsV1
    open Xunit

    type TestData() =
        static member ValidList : seq<obj[]> = 
            seq {
                yield [|[I;I;I;I]|]
                yield [|[I;V]|]
                yield [|[I;X]|]
                yield [|[I;X;V]|]
                yield [|[V;X]|]
                yield [|[X;I;V]|]
                yield [|[X;I;X]|]
                yield [|[X;X;I;I]|]
            }
        static member InvalidList : seq<obj[]> = 
            seq {
                // Five in a row of any digit is not allowed
                yield [|[I;I;I;I;I]|]
                // Two in a row for V,L, D is not allowed
                yield [|[V;V]|]
                yield [|[L;L]|]
                yield [|[D;D]|]
                // runs of 2,3,4 in the middle are invalid if next digit is higher
                yield [|[I;I;V]|]
                yield [|[X;X;X;M]|]
                yield [|[C;C;C;C;D]|]
                // three ascending numbers in a row is invalid
                yield [|[I;V;X]|]
                yield [|[X;L;D]|]
            }

    [<Theory; MemberData("ValidList", MemberType=typeof<TestData>)>]
    let ``Given valid list sequence should return true`` validList = isValidDigitList validList |> should equal true

    [<Theory; MemberData("InvalidList", MemberType=typeof<TestData>)>]
    let ``Given invalid list sequence should return false`` validList = isValidDigitList validList |> should equal false
