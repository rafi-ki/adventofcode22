open System.IO

let input = File.ReadAllText "input.txt"

let containsDuplicates (pack: char[]) =
    let distLength = Array.distinct pack |> Array.length
    distLength = 14 |> not

let solution1 =
    let length = input
                |> Seq.windowed 14
                |> Seq.takeWhile (fun x -> containsDuplicates x)
                |> Seq.length
    length + 14

let run = printf $"solution: %i{solution1}"