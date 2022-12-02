open System.IO

type Hand = Rock | Paper | Scissor
type GameResult = Win | Lose | Draw
type Game =  { Me: Hand; Opponent: Hand }

let win (game: Game) =
    match game with
    | { Game.Me = Rock; Game.Opponent = Scissor } -> true
    | { Game.Me = Paper; Game.Opponent = Rock } -> true
    | { Game.Me = Scissor; Game.Opponent = Paper } -> true
    | _ -> false

let toHand (c: char) =
    match c with
    | 'A' | 'X' -> Rock
    | 'B' | 'Y' -> Paper
    | 'C' | 'Z' -> Scissor
    | _ -> failwith "invalid char"


let toGameResult (c: char) =
    match c with
    | 'X' -> Lose
    | 'Y' -> Draw
    | 'Z' -> Win
    | _ -> failwith "invalid char"

let toGame (line: string) =
    let split = line.Split " " |> Array.map char
    {
        Opponent = split |> Array.head |> toHand
        Me = split |> Array.last |> toHand
    }

let selectionScore (game: Game) =
    match game.Me with
    | Rock -> 1
    | Paper -> 2
    | Scissor -> 3

let resultScore (game: Game) =
    if game.Me = game.Opponent then 3
    else if win game then 6
    else 0

let play (game: Game) = resultScore game + selectionScore game

let input = File.ReadAllLines "input.txt"

let solution1 =
    input
    |> Array.map toGame
    |> Array.map play
    |> Array.sum

// let solution2 =
//     input
//     |> Array.map singleBlock
//     |> Array.sortDescending
//     |> Array.take 3
//     |> Array.sum

let run = printf $"solution: %i{solution1}"