using ConsoleApp1;

const string FilePath = "..\\..\\..\\data\\videogames.csv";

List<videojatekok> games = [];

using StreamReader stream = new(FilePath);
_ = stream.ReadLine();
while (!stream.EndOfStream) games.Add(new(stream.ReadLine()));

var strict4 = games.Count(g => g.Ertekeles > 4.5);
Console.WriteLine($"Hány olyan játék van a listában, aminek az értékelése szigorúan nagyobb, mint 4.5?: {strict4}");

var mostPlayed = games.MaxBy(g => g.AktivJatekosok);
Console.WriteLine($"Melyik az a játék a teljes kínálatból, amellyel a legtöbben játszanak?: {mostPlayed}");

//var isThereAnyBefore2020 = games.Find(g => g.KiadasDatum:yyyy.MM.dd);

var avgRating = games.Average(g => g.Ertekeles);
Console.WriteLine($"Mennyi a listában szereplő összes játék értékelésének az átlaga?: {avgRating}");

var singleCyber = games.Single(g => g.Cim == "Cyber City 2077");
Console.WriteLine("a egyetlen cyber city jatek: "+ singleCyber.Cim);

var allRpg = games.Where(g => g.Mufaj == "RPG").OrderByDescending(g => g.KiadasDatum).Select(g => g.Cim);
Console.WriteLine($"Listázd ki az összes \"RPG\" műfajú játékot, majd rendezd őket a kiadás dátuma szerint csökkenő sorrendbe!:");
foreach (var game in allRpg) Console.WriteLine($"\t - {game}");

var top3Games = games.OrderByDescending(g => g.Ertekeles).Select(g=>g.Cim).Take(3);
Console.WriteLine("Melyik a 3 legjobbra értékelt játék a teljes listában?");
foreach (var item in top3Games)
{
    Console.WriteLine($"\t - {item}");
}

var avgActivePlayer = games.Where(g => g.KiadasDatum.Year >= 2022).Average(g=>g.Ertekeles);
Console.WriteLine($"Mennyi az átlagos aktív játékosszám azokban a játékokban, amelyeket 2022-ben vagy azután adtak ki? : {avgActivePlayer:f02} ");

var countGenre = games.GroupBy(g => g.Mufaj);
Console.WriteLine("Csoportosítsd a játékokat műfaj szerint, és add meg, hogy az egyes műfajokban hány darab játék található!");
foreach (var item in countGenre)
{
    Console.WriteLine($"{item.Key, -12} {item.Count(),2}");
}

Console.WriteLine("**10.** Csoportosítsd a játékokat műfaj szerint, majd minden műfajból válaszd ki azt az EGY játékot, amelyik a legmagasabb értékeléssel rendelkezik!");
foreach (var grp in countGenre)
{
    Console.WriteLine($"\t{grp.Key}: ");
    foreach (var prod in grp)
    {
        Console.WriteLine($"\t\t  {prod.Ertekeles}");
        break;
    }
}