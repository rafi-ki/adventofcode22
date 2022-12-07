open System
open System.IO


let input = File.ReadAllLines "input.txt"

let halfIt (line: string) = (line.Substring(0, int(line.Length / 2)), line.Substring(int(line.Length / 2), int(line.Length / 2)))

let toPriority ch =
    if Char.IsLower ch then int ch - 96
    else int ch - 38

let findDuplicate (rucksack: string*string) =
    let f = fst rucksack
    let s = snd rucksack
    f
    |> Seq.sortBy (fun x -> s.Contains(x))
    |> Seq.last

let solution1 =
    input
    |> Array.map halfIt
    |> Array.map findDuplicate
    |> Array.map toPriority
    |> Array.sum

let run = printf $"solution: %i{solution1}"