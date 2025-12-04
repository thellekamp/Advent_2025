module Advent2025_3

open System
open System.IO

let lines = File.ReadAllLines(@"C:\Users\t.hellekamp\Documents\projects\fsharp\Advent2025\3\3.txt")

let testItems = [| "987654321111111";"811111111111119";"234234234234278";"818181911112111" |]

let latestNRemoved n (text:string) = text.Substring(0, text.Length - n)

let latestOneRemoved = latestNRemoved 1

let toInts (text:string) =
    text.ToCharArray() |> Array.map(fun c -> Int32.Parse(c.ToString())) 

let highestDigit (text:string) = 
        text |> toInts |> Array.sortDescending |> Array.head  

let highest (text:string) = 
    let highestFirstDigit = 
        text |> latestOneRemoved |> highestDigit
    let highestSecondDigit =
        text.Substring(text.IndexOf(highestFirstDigit.ToString()) + 1) |> highestDigit
    highestFirstDigit * 10 + highestSecondDigit

let advent2025_3_1 items =
    items
    |> Array.map highest
    |> Array.sum

testItems |> advent2025_3_1 |> printfn "test 1: %A"
lines |> advent2025_3_1 |> printfn "test 1: %A"
