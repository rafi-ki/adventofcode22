open System.IO

let input = 
    File.ReadAllLines @"input.txt"
    |> Array.map int

let solution1 = 
    let solution = input
                   |> Array.pairwise
                   |> Array.filter (fun x -> fst x < snd x)
                   |> Array.length
    printf $"solution 1: %i{solution}\n"
    0

let solution2 =
    let solution = input
                    |> Array.windowed 3
                    |> Array.map (fun x -> x |> Array.sum)
                    |> Array.pairwise
                    |> Array.filter (fun x -> fst x < snd x)
                    |> Array.length
    printf $"solution 2: %i{solution}\n"
    0