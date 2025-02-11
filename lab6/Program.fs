//zad1
(*open System

let liczSowaIZnaki (tekst: string) =
    let liczbaSlow = tekst.Split([|' '; '\t'; '\n'|], StringSplitOptions.RemoveEmptyEntries).Length
    let liczbaZnakow = tekst.Replace(" ", "").Length
    liczbaSlow, liczbaZnakow

printf "Podaj tekst: "
let tekst = Console.ReadLine()

let liczbaSlow, liczbaZnakow = liczSowaIZnaki tekst

printfn "Liczba słów: %d" liczbaSlow
printfn "Liczba znaków (bez spacji): %d" liczbaZnakow*)


//zad2
(*open System

let liczSowaIZnaki (tekst: string) =
    let liczbaSlow = tekst.Split([|' '; '\t'; '\n'|], StringSplitOptions.RemoveEmptyEntries).Length
    let liczbaZnakow = tekst.Replace(" ", "").Length
    liczbaSlow, liczbaZnakow

let czyPalindrom (tekst: string) =
    let oczyszczony = tekst.Replace(" ", "").ToLower()
    oczyszczony = String(oczyszczony.ToCharArray() |> Array.rev)

printf "Podaj tekst: "
let tekst = Console.ReadLine()

let liczbaSlow, liczbaZnakow = liczSowaIZnaki tekst

let wynikPalindrom = if czyPalindrom tekst then "jest palindromem" else "nie jest palindromem"

printfn "Liczba słów: %d" liczbaSlow
printfn "Liczba znaków (bez spacji): %d" liczbaZnakow
printfn "Podany tekst %s" wynikPalindrom*)

//zad3
(*open System

let liczSowaIZnaki (tekst: string) =
    let liczbaSlow = tekst.Split([|' '; '\t'; '\n'|], StringSplitOptions.RemoveEmptyEntries).Length
    let liczbaZnakow = tekst.Replace(" ", "").Length
    liczbaSlow, liczbaZnakow

let czyPalindrom (tekst: string) =
    let oczyszczony = tekst.Replace(" ", "").ToLower()
    oczyszczony = String(oczyszczony.ToCharArray() |> Array.rev)

let usunDuplikaty (lista: string list) =
    lista |> List.distinct

printf "Podaj tekst: "
let tekst = Console.ReadLine()

let liczbaSlow, liczbaZnakow = liczSowaIZnaki tekst

let wynikPalindrom = if czyPalindrom tekst then "jest palindromem" else "nie jest palindromem"

let slowa = tekst.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |> Array.toList
let unikalneSlowa = usunDuplikaty slowa

printfn "Liczba słów: %d" liczbaSlow
printfn "Liczba znaków (bez spacji): %d" liczbaZnakow
printfn "Podany tekst %s" wynikPalindrom
printfn "Unikalne słowa: %A" unikalneSlowa
*)

//zad4
(*open System

let przeksztalcWpis (tekst: string) =
    let dane = tekst.Split(';')
    if dane.Length = 3 then
        let imie = dane.[0].Trim()
        let nazwisko = dane.[1].Trim()
        let wiek = dane.[2].Trim()
        sprintf "%s, %s (%s lat)" nazwisko imie wiek
    else
        "Niepoprawny format danych"

let przetworzWpisy () =
    printfn "Wprowadź wpisy w formacie 'imię; nazwisko; wiek'. Wpisz 'stop', aby zakończyć."
    let rec wczytajWpisy acc =
        let wpis = Console.ReadLine()
        if wpis.ToLower() = "stop" then
            acc
        else
            let przeksztalcony = przeksztalcWpis wpis
            if przeksztalcony <> "Niepoprawny format danych" then
                printfn "Przekształcony wpis: %s" przeksztalcony
            else
                printfn "Błąd: %s" przeksztalcony
            wczytajWpisy (przeksztalcony :: acc)
    
    wczytajWpisy []

[<EntryPoint>]
let main argv =
    let wynik = przetworzWpisy ()
    printfn "\nWszystkie przetworzone wpisy:"
    wynik
    |> List.rev
    |> List.iter (printfn "%s")
    0
*)

//zad5
(*open System

let znajdzNajdluzszeSlowo (tekst: string) =
    let slowa = tekst.Split([|' '; '\t'; '\n'; '\r'; '.'; ','; ';'; ':'; '!'; '?'|], StringSplitOptions.RemoveEmptyEntries)
    if slowa.Length > 0 then
        let najdluzsze = slowa |> Array.maxBy (fun s -> s.Length)
        let dlugosc = najdluzsze.Length
        najdluzsze, dlugosc
    else
        "", 0

[<EntryPoint>]
let main argv =
    printfn "Wprowadź tekst:"
    let tekst = Console.ReadLine()
    let najdluzszeSlowo, dlugosc = znajdzNajdluzszeSlowo tekst
    if dlugosc > 0 then
        printfn "Najdłuższe słowo: \"%s\" (długość: %d)" najdluzszeSlowo dlugosc
    else
        printfn "Nie znaleziono żadnych słów w podanym tekście."
    0
*)

//zad6
(*open System

let zamienSlowo (tekst: string) (slowoDoZamiany: string) (noweSlowo: string) =
    tekst.Replace(slowoDoZamiany, noweSlowo)

[<EntryPoint>]
let main argv =
    printfn "Wprowadź tekst:"
    let tekst = Console.ReadLine()
    
    printfn "Wprowadź słowo, które chcesz zamienić:"
    let slowoDoZamiany = Console.ReadLine()
    
    printfn "Wprowadź nowe słowo:"
    let noweSlowo = Console.ReadLine()
    
    let zmodyfikowanyTekst = zamienSlowo tekst slowoDoZamiany noweSlowo
    
    printfn "\nZmodyfikowany tekst:"
    printfn "%s" zmodyfikowanyTekst
    0*)