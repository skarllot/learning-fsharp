namespace LibraryTest

module CompareWithCSharp =
    let square x = x * x

    let sumSquares n =
        [1..n] |> List.map square |> List.sum

    sumSquares 100

    let squareF x = x * x

    let sumSquaresF n =
        [1.0..n] |> List.map squareF |> List.sum

    sumSquaresF 100.0

    let rec quicksort list =
        match list with
        | [] ->
            []
        | firstElem::otherElements ->
            let smallerElements =
                otherElements
                |> List.filter (fun e -> e < firstElem)
                |> quicksort
            let largerElements =
                otherElements
                |> List.filter (fun e -> e >= firstElem)
                |> quicksort
            List.concat [smallerElements; [firstElem]; largerElements]

    let rec quicksort2 = function
        | [] -> []
        | first::rest ->
            let smaller,larger = List.partition ((>=) first) rest
            List.concat [quicksort2 smaller; [first]; quicksort2 larger]

open System.Net
open System
open System.IO

module CompareWithCSharpDownloading =
    let fetchUrl callback url =
        let req = WebRequest.Create(Uri(url))
        use resp = req.GetResponse()
        use stream = resp.GetResponseStream()
        use reader = new IO.StreamReader(stream)
        callback reader url

    let myCallback (reader:IO.StreamReader) url =
        let html = reader.ReadToEnd()
        let html1000 = html.Substring(0, 1000)
        printfn "Downloaded %s. First 1000 is %s" url html1000
        html

    let fetchUrlWithCallback = fetchUrl myCallback

    let google = fetchUrlWithCallback "http://google.com"
    let bbc = fetchUrlWithCallback "http://news.bbc.co.uk"

    let sites = ["http://www.bing.com";
    "http://www.google.com";
    "http://www.yahoo.com"]

    let sitesContent = sites |> List.map fetchUrlWithCallback