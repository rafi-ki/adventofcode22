open System
open System.IO

let input =
    let text = File.ReadAllText "input.txt"
    text.Split (Environment.NewLine + Environment.NewLine)

let singleBlock (block: string) =
    block.Split Environment.NewLine
    |> Array.map int
    |> Array.sum

let solution1 =
    input
    |> Array.map singleBlock
    |> Array.max

let solution2 =
    input
    |> Array.map singleBlock
    |> Array.sortDescending
    |> Array.take 3
    |> Array.sum

let run = printf $"solution: %i{solution2}"