# CSharpFunctionalPrograming
Example of using Linq to functional programming in C #

Na začiatok skúsme napísať algoritmus na nasledovné zadanie:

Napíšme funkciu, ktorá dostane na vstupe vetu a vráti vetu, v ktorej bude otočné poradie slov.
Pre jednoduchosť berme, že oddeľovač slov je len medzera a neriešime veľkosť písmen.
```[Fact]
public static void ReverseSentenceTest()
{
    "Bob has dog".ReverseSentence().Should().Be("dog has Bob");
}
```
No a teraz to skúsme ešte raz bez použita cyklov a if-ov.

>Stretol som sa s názorom, že načo vedieť LINQ, veď u nás až tak s dátami nerobíme. Ja si ten if v cykle napíšem.
Častokrát u ľudí, ktorí si neuvedomujú, že linq nie je len dotazovacím jazykom.
Ale v kombinácií s delegátmi prináša do OOP jazyka prvky funkcionálneho programovania.

Napíšte funkciu, ktorá každému písmenu vo vete zmení prvé písmeno na veľké.
```
[Fact]
public static void ToTitleCaseTest()
{
    "How can mirrors be real if our eyes aren't real"
    .ToTitleCase()
        .Should()
        .Be("How Can Mirrors Be Real If Our Eyes Aren't Real");

    //Bez použitia CultureInfo.CurrentCulture.TextInfo.ToTitleCase(phrase);
}
```
Napíšte funkciu, ktorá znásobí text, ktorý dostane na vstupe podľa patternu.
Viď test.
```
[Fact]
public static void AccumTest()
{
    "abcd"
    .Accum()
        .Should()
        .Be("A-Bb-Ccc-Dddd");
}
```
Napíšte funckiu, ktorá z textu vyberie najnižšie a najvyššie číslo.
Predpokladajme, že tam budú naozaj len celé čísla a ich oddeľovač je medzera.
```
[Fact]
public static void HighAndLowTest()
{
    "8 3 -5 42 -1 0 0 -9 4 7 4 -4"
    .HighAndLow()
        .Should()
        .Be("42 -9");
}
```
 Napíšte metódu, ktorá nájde v postupnosti znakov ten, ktorý tam chýba.
 Predpokladajme, že vždy chýba len jeden znak a že idú postupne.
 ```
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
```
Máme pole čísel s duplicitami.
Napíšme funkciu, ktorá ich zoradí a pridá k ním aj ich početosti.
Zoradené vzostupne podľa čísla.
```
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
```
Napíšme funkciu, ktorá spočíta mocniny čísel od 1 po zvolené číslo.
Obmena, len párnych.
```
[Fact]
public void SumOfPowersTest()
{
    50. SumOfPowers()
        .Should().Be(42925);

    100. SumOfPowers()
        .Should().Be(338350);
}
```
Napíšte funkciu, ktorá vytvorí nové číslo z pôvodného tak, že číslice budú zostupné.
 ```
[Fact]
public void DescendingNumberTest()
{
    214123154
        .DescendingNumber()
        .Should()
        .Be(544322111);
}
```
Napísať funkciu, ktorá vynásobi medzi sebou hodnoty dvoch kolekcií.
V kolekciach nemusí byť rovnaký počet čísel.
```
[Fact]
public void MultiplicationTableTest()
{
    var numbers1 = new List<int>() { 2, 4, 9, 11 };
    var numbers2 = new List<int>() { 10, 12, 13, 15, 22 };

    numbers1.MultiplicationTable(numbers2)
        .ShouldBeEquivalentTo(new List<int>() { 20, 48, 117, 165 });
}
```
Napíšme funkciu, ktorá ma vstupné parametre `pole stringov` a číslo `k`.
Našou úlohou je vrátiť prvý najdlhší reťazec pozostávajúci z `k` po sebe nasledujúcich reťazcov odobraných v poli.
ak `n = 0 or k > n or k <= 0 return string.Empty`
```
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
```
Zahrajme sa.

Skúsme napísať TowerBuilder.

Funkciu, ktorej zadáme výšku budovy a ona nám vráti jednotlivé poschodia.

```
[
  '     *     ',
  '    ***    ',
  '   *****   ',
  '  *******  ',
  ' ********* ',
  '***********'
]
```

```
[Fact]
public void TowerBuilderTest()
{
    1. TowerBuilder()
        .ShouldAllBeEquivalentTo(new List<string>() { "*" });

    2. TowerBuilder()
        .ShouldAllBeEquivalentTo(new List<string>() { " * ", "***" });

    3. TowerBuilder()
        .ShouldAllBeEquivalentTo(new List<string>() { "  *  ", " *** ", "*****" });

    4. TowerBuilder()
        .ShouldAllBeEquivalentTo(new List<string>() { "   *   ", "  ***  ", " ***** ", "*******" });
}
```

Napíšme funkciu, ktorá zvaliduje vstupný string, či obsahuje sprváne uzátvorkované výrazy.

```
[Fact]
public void ValidParenthesesTest()
{
    "()".ValidParentheses().Should().BeTrue();
    ")(()))".ValidParentheses().Should().BeFalse();
    "(".ValidParentheses().Should().BeFalse();
    "(())((()())())".ValidParentheses().Should().BeTrue();
    ")((((".ValidParentheses().Should().BeFalse();
    "))))))".ValidParentheses().Should().BeFalse();
    "(((())))".ValidParentheses().Should().BeTrue();
    "((((".ValidParentheses().Should().BeFalse();
}
```

Napíšme funkciu, ktorá vygeneruje náhodné čísla.

```
var random = 20.GenerateRandom();
```

Napíšme funkciu, ktorá premapuje zoznam mien na zoznam osôb.

```
[Fact]
public void MapPeopleTest()
{
    var names = new List<string>() { "Milan", "Zuzka", "Ninka", "Mišo", "Jano" };

    var people = names.MapNamesToPeople();

    people.Select(p => p.Name)
        .Should().BeEquivalentTo(names);
}
```