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
    | 'A' -> Rock
    | 'B' -> Paper
    | 'C' -> Scissor
    | _ -> failwith "invalid char"

let toWin (h: Hand) =
    match h with
    | Paper -> Scissor
    | Rock -> Paper
    | Scissor -> Rock

let toLose (h: Hand) =
    match h with
    | Paper -> Rock
    | Rock -> Scissor
    | Scissor -> Paper

let toHand2 (opponent: Hand) (result: GameResult) =
    match result with
    | Draw -> opponent
    | Win -> toWin opponent
    | Lose -> toLose opponent

let toGameResult (c: char) =
    match c with
    | 'X' -> Lose
    | 'Y' -> Draw
    | 'Z' -> Win
    | _ -> failwith "invalid char"

let toGame (line: string) =
    let split = line.Split " " |> Array.map char
    let desiredResult = split |> Array.last |> toGameResult
    let opp = split |> Array.head |> toHand
    {
        Opponent = opp
        Me = toHand2 opp desiredResult
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

let solution =
    input
    |> Array.map toGame
    |> Array.map play
    |> Array.sum


let run = printf $"solution: %i{solution}"