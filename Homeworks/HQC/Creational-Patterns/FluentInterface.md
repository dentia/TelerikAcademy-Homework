# Fluent Interface
### Creational Design Pattern

## Обобщение
Fluent Interface-ът цели да предостави по-четим и разбираем код. Намалява Syntactical noise-а и изразява по-ясно какво 
върши кода. Имплементира се чрез method cascading.

## Конкретна имплементация
Създаване на сродна душа:

###### Soulmate context
~~~c#
public class SoulmateContext
{
    public Gender Gender { get; set; }
    public string Name { get; set; }
    public HairColor Hair { get; set; }
    public EyeColor Eyes { get; set; }
    public string NicknameForMe { get; set; }
}
~~~

###### Soulmate
~~~c#
public class Soulmate
{
    private readonly SoulmateContext context;

    public Soulmate()
    {
        this.context = new SoulmateContext();;
    }

    public Soulmate Name(string name)
    {
        this.context.Name = name;
        return this;
    }

    public Soulmate Gender(Gender gender)
    {
        this.context.Gender = gender;
        return this;
    }

    public Soulmate Hair(HairColor hair)
    {
        this.context.Hair = hair;
        return this;
    }

    public Soulmate Eyes(EyeColor eyes)
    {
        this.context.Eyes = eyes;
        return this;
    }

    public Soulmate NicknameForMe(string nickname)
    {
        this.context.NicknameForMe = nickname;
        return this;
    }

    public void Introduce()
    {
        Console.WriteLine($"Hi, {this.context.NicknameForMe}!{Environment.NewLine}" +
                          $"I'm {this.context.Name}. I have {this.context.Hair} hair and " +
                          $"{this.context.Eyes} eyes!");
    }
}
~~~

###### Usage
~~~c#
static void Main()
{
    var soulmate = new Soulmate();

    soulmate.Gender(Gender.Male)
        .Name("A")
        .Eyes(EyeColor.Brown)
        .Hair(HairColor.Black)
        .NicknameForMe("B")
        .Introduce();
}
~~~
