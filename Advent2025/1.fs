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

let accFunc_1_1 acc num = 
    let newVal = fst(acc) + num
    match newVal % 100 with
    | 0 -> (0, snd(acc) + 1)
    | _ -> (newVal, snd(acc))

let accFunc_1_2 acc num = 
    let newVal = fst(acc) + num
    match (sign(fst(acc)), sign(newVal)) with
    | (1, -1) | (-1, 1) -> (newVal, snd(acc) + 1)
    | ( _ , 0) -> (newVal, snd(acc) + 1)
    | _ -> (newVal, snd(acc))
    |> fun (a,b) -> (a % 100, b + (abs(a) / 100))

let advent2025_1 accFunc items = 
    items 
    |> Array.map item
    |> Array.fold accFunc (50, 0)
    |> snd

testItems |> advent2025_1 accFunc_1_1 |> printfn "test 1: %A"
lines |> advent2025_1 accFunc_1_1 |> printfn "result 1: %A"
testItems |> advent2025_1 accFunc_1_2 |> printfn "test 2: %A"
lines |> advent2025_1 accFunc_1_2 |> printfn "result 2: %A"

