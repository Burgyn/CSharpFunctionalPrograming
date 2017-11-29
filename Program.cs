using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CSharpFunctionalPrograming
{
 public class Program
    {
        // Na začiatok skúsme napísať algoritmus na nasledovné zadanie.
        // Napíšme funkciu, ktorá dostane na vstupe vetu a vráti vetu, v ktorej bude otočné poradie slov.
        // Pre jednoduchosť berme, že oddeľovač slov je len medzera a neriešime veľkosť písmen.

        // No a teraz to skúsme ešte raz bez použita cyklov a if-ov.
        [Fact]
        public static void ReverseSentenceTest()
        {
            "Bob has dog".ReverseSentence().Should().Be("dog has Bob");
        }

        // Stretol som sa s názorom, že načo vedieť LINQ, veď u nás až tak s dátami nerobíme. Ja si ten if v cykle napíšem.
        // Častokrát u ľudí, ktorý si neuvedomujú, že linq nie je len dotazovacím jazykom.
        // Ale v kombinácií s delegátmi prináša do OOP jazyka prvky funkcionálneho programovania.

        // Napíšte funkciu, ktorá každému písmenu vo vete zmení prvé písmeno na veľké.
        [Fact]
        public static void ToTitleCaseTest()
        {
            "How can mirrors be real if our eyes aren't real"
            .ToTitleCase()
                .Should()
                .Be("How Can Mirrors Be Real If Our Eyes Aren't Real");

            //Bez použitia CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
        }

        // Napíšte funkciu, ktorá znásobí text, ktorý dostane na vstupe podľa patternu.
        // Viď test.
        [Fact]
        public static void AccumTest()
        {
            "abcd"
            .Accum()
                .Should()
                .Be("A-Bb-Ccc-Dddd");
        }

        // Napíšte funckiu, ktorá z textu vyberie najnižšie a najvyššie číslo.
        // Predpokladajme, že tam budú naozaj len celé čísla a ich oddeľovač je medzera.
        [Fact]
        public static void HighAndLowTest()
        {
            "8 3 -5 42 -1 0 0 -9 4 7 4 -4"
            .HighAndLow()
                .Should()
                .Be("42 -9");
        }

        // Napíšte metódu, ktorá nájde, ktorá nájde v postupnosti znakov ten, ktorý tam chýba.
        // Predpokladajme, že vždy chýba len jeden znak a že idú postupne.
        [Fact]
        public static void FindMessingLetterTest()
        {
            "abcefgh"
            .FindMissingLetter()
                .Should().Be('d');

            "EFHI"
            .FindMissingLetter()
                .Should().Be('G');
        }

        // Máme pole čísel s duplicitami.
        // Vypíšme ich zoradené na konzolu očistené od duplicít aj s ich početnosťou.
        // Zoradené vzostupne podľa čísla.
        [Fact]
        public void GroupByWithCountShould()
        {
            new int[] { 1, 2, 5, 4, 1, 3, 8, 1, 4, 5, 8, 4 }
                .GroupByWithCount()
                .ShouldAllBeEquivalentTo(
                    new List<(int, int)>()
                    {
                        (1, 3), (2, 1), (3, 1), (4, 3), (5, 2), (8, 2)
                    });
        }

        // Napíšme funkciu, ktorá spočíta mocniny čísel od 1 po zvolené číslo.
        // Obmena, len párnych
        [Fact]
        public void SumOfPowersTest()
        {
            50. SumOfPowers()
                .Should().Be(42925);

            100. SumOfPowers()
                .Should().Be(338350);
        }

        // Napíšte funkciu, ktorá vytvorí nové číslo z pôvodného tak, že číslice budú zostupné.
        [Fact]
        public void DescendingNumberTest()
        {
            214123154
                .DescendingNumber()
                .Should()
                .Be(544322111);
        }

        // Napísať funkciu, ktorá vynásobi medzi sebou hodnoty dvoch kolekcií.
        // V kolekciach nemusí byť rovnaký počet čísel.
        [Fact]
        public void MultiplicationTableTest()
        {
            var numbers1 = new List<int>() { 2, 4, 9, 11 };
            var numbers2 = new List<int>() { 10, 12, 13, 15, 22 };

            numbers1.MultiplicationTable(numbers2)
                .ShouldBeEquivalentTo(new List<int>() { 20, 48, 117, 165 });
        }

        // Napíšme funkciu, ktorá ma vstupné parametre pole stringov a číslo k.
        // Našou úlohou je vrátiť prvý najdlhší reťazec pozostávajúci z k po sebe nasledujúcich reťazcov odobraných v poli.
        // ak n = 0 or k > n or k <= 0 return string.Empty
        [Fact]
        public void LongestConsecTest()
        {
            new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }
                .LongestConsec(2)
                .Should().Be("abigailtheta");
            new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }
                .LongestConsec(1)
                .Should().Be("oocccffuucccjjjkkkjyyyeehh");
            new String[] { }.LongestConsec(3).Should().BeEmpty();
            new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }
                .LongestConsec(2)
                .Should().Be("wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }
                .LongestConsec(2)
                .Should().Be("wlwsasphmxxowiaxujylentrklctozmymu");
            new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }
                .LongestConsec(-2)
                .Should().BeEmpty();
            new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }
                .LongestConsec(3)
                .Should().Be("ixoyx3452zzzzzzzzzzzz");
        }

        private static void UseZip()
        {
            foreach (var item in Enumerable.Zip(new int[] { 25, 45, 78 }, new string[] { "sk", "cz", "hu" }, (n, v) => $"{n} - {v}"))
            {
                System.Console.WriteLine(item);
            }
        }

        private static void GeneratePeople()
        {
            var random = new Random();
            var data = new List<string>() { "Milan", "Fero", "Jano", "Evka", "Zuzka", "Katka" };
            var i = 1;
            foreach (var item in Enumerable.Range(1, 100).Select(_ => new Person()
                {
                    Id = i++,
                        Name = data[random.Next(data.Count - 1)]
                }))
            {
                System.Console.WriteLine($"{item.Id} - {item.Name}");
            }
        }

        class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }

        }

        private static void GenerateRandomData_int()
        {
            var random = new Random();
            foreach (var item in Enumerable.Range(1, 100).Select(_ => random.Next()))
            {
                System.Console.WriteLine(item);
            }
        }
    }

    public static class Extensions
    {
        public static string ReverseSentence(this string value) =>
            string.Join(" ", value.Split(' ').Reverse());

        public static string ToTitleCase(this string value) =>
            string.Join(" ", value.Split(' ').Select(p => $"{char.ToUpper(p[0])}{p.Substring(1)}"));

        public static string Accum(this string value)
        {
            var i = 0;
            return string.Join("-",
                value.Select(c => $"{char.ToUpper(c)}{new String(char.ToLower(c), i++)}"));
        }

        public static string HighAndLow(this string value)
        {
            Func<string, IEnumerable<int>> parse = (t) => t.Split(' ').Select(c => int.Parse(c));

            return $"{parse(value).Max()} {parse(value).Min()}";
        }

        public static char FindMissingLetter(this string chars) =>
            (char) Enumerable.Range((int) chars.First(), chars.Length)
            .FirstOrDefault(p => !chars.Contains((char) p));

        public static IEnumerable<(int number, int count)> GroupByWithCount(this IEnumerable<int> value) =>
            value
            .GroupBy(p => p)
            .Select(p =>(number : p.Key, count : p.Count()))
            .OrderBy(p => p.number);

        public static int SumOfPowers(this int number) =>
            Enumerable.Range(1, number).Sum(p => p * p);

        public static int DescendingNumber(this int number) =>
            int.Parse(
                string.Join("",
                    number.ToString()
                    .Select(p => int.Parse(p.ToString()))
                    .OrderByDescending(p => p)));

        public static IEnumerable<int> MultiplicationTable(this IEnumerable<int> numbers1, IEnumerable<int> numbers2) =>
            numbers1.Zip(numbers2, (n1, n2) => n1 * n2);

        public static string LongestConsec(this IEnumerable<string> s, int k) =>
            s.Count() < k || k <= 0 ? string.Empty :
            Enumerable.Range(0, s.Count() - k + 1)
            .Select(x => string.Join("", s.Skip(x).Take(k)))
            .OrderByDescending(p=> p.Length)
            .First();

    }
}
