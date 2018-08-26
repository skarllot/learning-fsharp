module RomanNumeralsV2
    type RomanDigit =
        | I | II | III | IIII
        | IV | V
        | IX | X | XX | XXX | XXXX
        | XL | L
        | XC | C | CC | CCC | CCCC
        | CD | D
        | CM | M | MM | MMM | MMMM
    type RomanNumeral = RomanNumeral of RomanDigit list

    let digitToInt =
        function
        | I -> 1 | II -> 2 | III -> 3 | IIII -> 4
        | IV -> 4 | V -> 5
        | IX -> 9 | X -> 10 | XX -> 20 | XXX -> 30 | XXXX -> 40
        | XL -> 40 | L -> 50
        | XC -> 90 | C -> 100 | CC -> 200 | CCC -> 300 | CCCC -> 400
        | CD -> 400 | D -> 500
        | CM -> 900 | M -> 1000 | MM -> 2000 | MMM -> 3000 | MMMM -> 4000

    let digitsToInt list = list |> List.sumBy digitToInt

    let toInt (RomanNumeral digits) = digitsToInt digits

    type ParsedChar =
        | Digit of RomanDigit
        | BadChar of char

    let rec toRomanDigitListRec charList =
        match charList with

        | 'I'::'I'::'I'::'I'::ns ->
            Digit IIII :: (toRomanDigitListRec ns)
        | 'X'::'X'::'X'::'X'::ns ->
            Digit XXXX :: (toRomanDigitListRec ns)
        | 'C'::'C'::'C'::'C'::ns ->
            Digit CCCC :: (toRomanDigitListRec ns)
        | 'M'::'M'::'M'::'M'::ns ->
            Digit MMMM :: (toRomanDigitListRec ns)

        | 'I'::'I'::'I'::ns ->
            Digit III :: (toRomanDigitListRec ns)
        | 'X'::'X'::'X'::ns ->
            Digit XXX :: (toRomanDigitListRec ns)
        | 'C'::'C'::'C'::ns ->
            Digit CCC :: (toRomanDigitListRec ns)
        | 'M'::'M'::'M'::ns ->
            Digit MMM :: (toRomanDigitListRec ns)

        | 'I'::'I'::ns ->
            Digit II :: (toRomanDigitListRec ns)
        | 'X'::'X'::ns ->
            Digit XX :: (toRomanDigitListRec ns)
        | 'C'::'C'::ns ->
            Digit CC :: (toRomanDigitListRec ns)
        | 'M'::'M'::ns ->
            Digit MM :: (toRomanDigitListRec ns)

        | 'I'::'V'::ns ->
            Digit IV :: (toRomanDigitListRec ns)
        | 'I'::'X'::ns ->
            Digit IX :: (toRomanDigitListRec ns)
        | 'X'::'L'::ns ->
            Digit XL :: (toRomanDigitListRec ns)
        | 'X'::'C'::ns ->
            Digit XC :: (toRomanDigitListRec ns)
        | 'C'::'D'::ns ->
            Digit CD :: (toRomanDigitListRec ns)
        | 'C'::'M'::ns ->
            Digit CM :: (toRomanDigitListRec ns)

        | 'I'::ns ->
            Digit I :: (toRomanDigitListRec ns)
        | 'V'::ns ->
            Digit V :: (toRomanDigitListRec ns)
        | 'X'::ns ->
            Digit X :: (toRomanDigitListRec ns)
        | 'L'::ns ->
            Digit L :: (toRomanDigitListRec ns)
        | 'C'::ns ->
            Digit C :: (toRomanDigitListRec ns)
        | 'D'::ns ->
            Digit D :: (toRomanDigitListRec ns)
        | 'M'::ns ->
            Digit M :: (toRomanDigitListRec ns)

        | badChar::ns ->
            BadChar badChar :: (toRomanDigitListRec ns)

        | [] ->
            []

    let toRomanDigitList (s:string) =
        s.ToCharArray()
        |> List.ofArray
        |> toRomanDigitListRec

    let toRomanNumeral s =
        toRomanDigitList s
        |> List.choose (
            function
            | Digit digit ->
                Some digit
            | BadChar ch ->
                eprintfn "%c is not a valid character" ch
                None
            )
        |> RomanNumeral

    let rec isValidDigitList digitList =
        match digitList with

        | [] -> true

        | d1::d2::_
            when d2 <= d1 ->
                false

        | _::ds ->
            isValidDigitList ds

    let isValid (RomanNumeral digitList) =
        isValidDigitList digitList