open System.IO

type Range = { Start: int; End: int }

let input = File.ReadAllLines "input.txt"

let interferesTotally (ranges: Range*Range) =
    let f = fst ranges
    let s = snd ranges
    f.Start >= s.Start && f.Start <= s.End
    || s.Start >= f.Start && s.Start <= f.End
    || f.End >= s.Start && f.End <= s.End
    || s.End >= f.Start && s.End <= f.End


let toRange (line: string) =
    let split = line.Split(',')
    let fstRange = { Start = split[0].Split('-')[0] |> int; End = split[0].Split('-')[1] |> int }
    let sndRange = { Start = split[1].Split('-')[0] |> int; End = split[1].Split('-')[1] |> int }
    (fstRange, sndRange)

let solution1 =
    input
    |> Array.map toRange
    |> Array.where interferesTotally
    |> Array.length

let run = printf $"solution: %i{solution1}"