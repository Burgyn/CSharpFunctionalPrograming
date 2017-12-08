# CSharpFunctionalPrograming

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

Dnes si ukážeme ako sa dá začať "funkcionálne" programovať, bez teórie.

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

Napíšme funkciu, ktorá zvaliduje vstupný string, či obsahuje správne uzátvorkované výrazy.

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

Napíšme vlastnú implementáciu linqovej `Where` metódy

```
[Fact]
public void FilterTest()
{
    Predicate<int> isEven = p => p % 2 == 0;

    new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 }
        .Filter(isEven)
        .ShouldAllBeEquivalentTo(new List<int>() { 2, 4, 6, 8 });
}
```

Teraz si vyskúšajme napísať odľahčenú verziu quicksort-u.
Klasickým imperatívnym spôsobom programovania by to mohlo vyzerať nasledovne:
```
public static List<T> QuickSort<T>(List<T> values) where T : IComparable
{
    if (values.Count == 0)
    {
        return new List<T>();
    }

    T firstElement = values[0];

    var smallerElements = new List<T>();
    var largerElements = new List<T>();
    for (int i = 1; i < values.Count; i++)
    {
        var elem = values[i];
        if (elem.CompareTo(firstElement) < 0)
        {
            smallerElements.Add(elem);
        }
        else
        {
            largerElements.Add(elem);
        }
    }

    var result = new List<T>();
    result.AddRange(QuickSort(smallerElements.ToList()));
    result.Add(firstElement);
    result.AddRange(QuickSort(largerElements.ToList()));

    return result;
}
```

My to skúsme napísať "funkcionálne" ako extension na `IEnumerable<T>`.
Pokúsme sa čo najviac eliminovať kód highlevel funkcie.

```
[Fact]
public void QuickSortTest()
{
    var data = new List<int>() { 2, 8, 1, 4, 6, 9, 8, 7, 2, 45, 98, 41, 32, 23, 7 };

    data.QuickSort()
        .ShouldAllBeEquivalentTo(new List<int>() { 1, 2, 2, 4, 6, 7, 7, 8, 8, 9, 23, 32, 41, 45, 98 });
}
```

----
Takto by to mohlo vyzerať napríklad v jazyku F#, ktorý je od začiatku hlavne funkcionálnym jazykom. :-)

```
let rec quicksort = function
   | [] -> []
   | first::rest ->
        let smaller, larger = List.partition ((>=) first) rest
        List.concat [quicksort smaller; [first]; quicksort larger]
```

----
Predsa len málo, naozaj málo "teórie" na záver.

Funkcionálne programovanie je "štýl" programovania pri ktorom sa zdôrazňujú funkcie a vyhýbame state mutation.
Dva základné koncepty:
1. Functions as first-class values

    V týchto jazykoch môžete používať funkcie ako vstupy alebo výstupy pre ďalšie funkcie. Možete ich priradzovať do premenných a ukladať v koleciach.
```
    Func<int, bool> isEven = (i) => i % 2 == 0;
    Func<int, int> pow = (i) => i * i;

    var data = Enumerable.Range(0, 10000)
        .Where(isEven)
        .Select(pow);
```
2. Avoiding state mutation

Výstup funkcie závisí len od vstupných parametrov a táto funkcie nesmie meniť stav vstupných parametrov, respektíve systému ako takého.

```
    var nums = Range(-10000, 20001).Reverse().ToList();

    Action task1 = () => WriteLine(nums.Sum());
    Action task2 = () => { nums.Sort(); WriteLine(nums.Sum()); };
```

Čo sa vypíše na konzolu?

V mojom prípade to bolo:
```
1268
0
```

Ale keď to napíšeme nasledovne:
```
var nums = Range(-10000, 20001).Reverse().ToList();

Action task1 = () => WriteLine(nums.Sum());
Action task2 = () => { WriteLine(nums.**OrderBy(p => p)**.Sum()); };

Parallel.Invoke(task1, task2);
```

Teraz je už výsledok správny.

----
Microsoft sa snaží každou novou verziou C# viac podporovať funkcionálne programovanie.

Novinky v posledných verziach:

https://blogs.msdn.microsoft.com/dotnet/2016/08/24/whats-new-in-csharp-7-0/

1. Expression Bodied Functions and Properties
```
public bool IsSet => true;

public static int SumOfPowers(IEnumerable<int> values) => values.Select(p => p * p).Sum();
```
2. Out variables

![Out variables](https://pbs.twimg.com/media/DIdkzaJXYAAWLEG.jpg)

3. Pattern matching
```
if (node is BinaryExpression binExp)
{
    if (binExp.Left is MethodCallExpression mcExp && IsVbOperatorsExpression(mcExp))
    {
        return base.Visit(VisitVbOperatorsMethods(mcExp, binExp.NodeType));
    }
}
```

```
switch(shape)
{
    case Circle c:
        WriteLine($"circle with radius {c.Radius}");
        break;
    case Rectangle s when (s.Length == s.Height):
        WriteLine($"{s.Length} x {s.Height} square");
        break;
    case Rectangle r:
        WriteLine($"{r.Length} x {r.Height} rectangle");
        break;
    default:
        WriteLine("<unknown shape>");
        break;
    case null:
        throw new ArgumentNullException(nameof(shape));
}
```
4. Tuples
```
(string first, string middle, string last) = LookupName(id1); // deconstructing declaration
WriteLine($"found {first} {last}.");
```
5. Local Functions
```
public int Fibonacci(int x)
{
    if (x < 0) throw new ArgumentException("Less negativity please!", nameof(x));
    return Fib(x).current;

    (int current, int previous) Fib(int i)
    {
        if (i == 0) return (1, 0);
        var (p, pp) = Fib(i - 1);
        return (p + pp, p);
    }
}
```
6. Using static
```
public double Circumference
   => PI * 2 * Radius;
```

Plánované novinky:
- Record types (boilerplate-free immutable types)
- Algebraic data types (a powerful addition to the type system)

----
Ak ostane čas:
- Skúste napísať substring bez použitia substring.

ToWeirdCase( "String" );//=> returns "StRiNg"
ToWeirdCase( "Weird string case" );//=> returns "WeIrD StRiNg CaSe"


Assert.AreEqual(true, IsPangram("The quick brown fox jumps over the lazy dog."));

87 + 78 = 165; 165 + 561 = 726; 726 + 627 = 1353; 1353 + 3531 = 4884
Assert.AreEqual(4, PalindromeChainLength(87));


