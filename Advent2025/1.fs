module Advent2025_1

open System
open System.IO

let lines = File.ReadAllLines(@"C:\Users\t.hellekamp\Documents\projects\fsharp\Advent2025\1\1.txt")

let testItems = [| "L68";"L30";"R48";"L5";"R60";"L55";"L1";"L99";"R14";"L82" |]

let item (text:string) = 
    match (text)[0] with
    | 'L' -> -1  
    | 'R' -> 1 
    | _ -> 0
    * (text.[1..] |> Int32.Parse)

let advent2025_1 items = 
    let nextAcc acc num = 
        let newVal = fst(acc) + num
        match newVal % 100 with
        | 0 -> (0, snd(acc) + 1)
        | _ -> (newVal, snd(acc))

    items 
    |> Array.map item
    |> Array.fold nextAcc (50, 0)
    |> snd

testItems |> advent2025_1 |> printfn "%A"
lines |> advent2025_1 |> printfn "%A"
