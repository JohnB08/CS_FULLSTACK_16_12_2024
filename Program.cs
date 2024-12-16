namespace CS_FULLSTACK_16_12_2024;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        //int: datatypen til variabelen.
        //myInt: Navnet til variablen.
        //10: verdien til variablen.
        int myInt = 10;
        int largestInt = int.MaxValue;
        //maks verdien til en integer er +/- 2^31;
        Console.WriteLine(largestInt);
        uint unsignedInt = 14;
        //maks verdien til en unsigned int er 2^32;
        uint uMax = uint.MaxValue;
        Console.WriteLine(uMax);
        //en double er en 64-bit datatype, hvor 11 av bits er brukt til å holde hele tall, en bit for +/- 
        //Selv om doublen har 52 bits tilgjengelig ekstra for desimalverdi, er den likevell kun nøyaktig til 
        //rundt 16 desimalverdier.
        double myDouble = 4.99;
        double justEnoughDecimals = 4.999999999999999;
        double tooManyDecimals = 4.999999999999999999;
        Console.WriteLine(Math.Truncate(justEnoughDecimals));
        //Når vi er over desimalnøyaktigheten sliter datamaskiner å se hva tallet egentlig skal være. Her burde vi fått ut tallet 4 for begge trucatene.
        //Men siden tooManyDecimals har flere desimaltall enn en double har nøyakthet for, så klarer ikke datamaskinen å se forskjell på
        //desimaltallet tooManyDecimals, og tallet 5. 
        Console.WriteLine(Math.Truncate(tooManyDecimals));

        //Her nede ser vi litt på forskjellen mellom en verdi type og en referansetype.
        //Vi prøver å klone myDouble
        double myClonedDoule = myDouble;
        //Vi øker myClonedDouble med 1.
        myClonedDoule++;
        //Vi ser at verdien av myClonedDouble og myDouble er forskjellig.
        Console.WriteLine(myClonedDoule);
        Console.WriteLine(myDouble);
        //Dette er fordi double er en verditype i C#. Og hver gang vi initialiserer en ny verditype i C#, 
        //Lager vi en ny region i memory som skal holde den verdien. Det vil si myDouble og myClonedDouble er forskjellige regioner i minnet,
        //Selv om den ene ble laget for å lage den andre. Verdien blir klonet og plasert en annen plass.  




        //Vi prøver å gjøre det samme i et array. 
        //Vi definerer først et int array som heter myNumCollection.
        int[] myNumCollection = [1, 2, 3, 4, 5, 6, 7, 8];
        //Vi prøver å klone arrayet via å definere et nytt array som skal være likt det forrige.
        int[] myClonedCollection = myNumCollection;
        //Vi setter myClonedCollection index 2 til å være lik 42;
        myClonedCollection[2] = 42;
        //Vi skriver alle verdiene i det orginale arrayet ut i terminalen vår.
        foreach (var num in myNumCollection)
        {
            Console.WriteLine(num);
        }
        //Oi, her har vi også endret verdien i myNumCollection.
        //Det er fordi arrays er referanser til steder i memory.
        //Både myNumCollection og myClonedCollection refererer til samme område i minnet til datamaskinen vår, så gjør vi endringer
        //I ett, gjør vi også endringer i et annet.

        //Hvis man lurer på hvilken verdi som er referansetyper, kan man holde musepekeren over datatypen og lese om datatypen er av type struct eller class 
        //!!(obs, når man definerer et array, bruker man ofte aliaset type[], aka int[] som over, og da fungerer ikke dette)
        //hvis datatypen er av typen Class, som f.eks under med listen, er det en referansetype. Eller hvis man ser på en int, vil man se det er en struct.
        List<string> myNames = ["John", "Kristian"];
        //!!Structs refererer til minnestructurer i minnet, og hver gang man lager en struct, lager man en ny struktur i minnet.

        //!!Class er en samling av referanser til minnelokasjoner.





        //Her ser vi litt på casting av datatyper, en til en annen. 
        int num1 = 1;
        int num2 = 2;
        //hvis vi ikke husker å caste ene inten til en double i denne operasjonen, så får vi ikke ut et naturlig svar. 
        var division = num1 / (double)num2;
        //Siden vi caster num2 til en double over, blir også num1 implicit castet til en double, og division blir også lagret som en double. Da vil man få ut desimalverdien man ønsker.
        Console.WriteLine(division);

        //Vi kan også gjøre det samme med en double, men da må man huske at desimalverdiene blir trunkert,
        //Aka alle desimaltallene forsvinner. Da sitter man kun igjen med det hele tallet. Ingen avrunding skjer.
        var sum = num1 + (int)myDouble;
        Console.WriteLine(sum);
        //Hvis man vil ha en avrunding kan man bruke de innebygde round metodene, før man caster til datatypen man vil ha.
        var roundedNum = (int)Math.Round(myDouble);
        var roundInt = (int)double.Round(myDouble);
        Console.WriteLine(roundedNum);

        //forskjell på struct og class, aka forskjell på verdi og referanse typer.

        //Vi definerer en ny partikkel
        var particle = new Particle(1, 2);

        //vi later som en kollisjon har skjedd, og vi trenger en ny klone av partikkelen vår, som kan holde andre koordinater.
        var secondParticle = particle;
        //Vi gir så second particle et annet set med koordinater:
        secondParticle.X = 10;
        //Vi ser her at second particle og particle er to separate verdier i minnet, og kan derfor holde forskjellige verdier.
        Console.WriteLine(particle.ToString());
        Console.WriteLine(secondParticle.ToString());

        //Vi prøver det samme med ParticleClass
        var particleClass = new ParticleClass(1, 2);
        var secondParticleClass = particleClass;
        secondParticleClass.Y = 42;
        //Her ser vi at via å sette secondParticleClass.Y til 42, har vi og endret på particleClass.Y, det er fordi både 
        //secondParticleClass og particleClass refererer til samme område i memory. De er referanser.
        Console.WriteLine(particleClass.ToString());
        Console.WriteLine(secondParticleClass.ToString());

    }
    public struct Particle(int x, int y)
    {
        public int X = x;
        public int Y = y;
        public new string ToString()
        {
            return $"{X}, {Y}";
        }

    }
    public class ParticleClass(int x, int y)
    {
        public int X = x;
        public int Y = y;
        public new string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}
