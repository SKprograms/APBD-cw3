namespace APBD_cw3;

public class KontenerNaPlyny : Kontener, InterfaceNiebezpieczenstwo
{
    public bool CzyNiebezpieczny { get; set; }

    public KontenerNaPlyny(double wysokosc, double glebokosc, double wagaWlasna, double maksymalnaLadownosc, bool czyNiebezpieczny)
        : base("L", wysokosc, glebokosc, wagaWlasna, maksymalnaLadownosc)
    {
        CzyNiebezpieczny = czyNiebezpieczny;
    }

    public override void Zaladuj(double ladunek)
    {
        double maksymalnaDopuszczalnaLadownosc;
        if (CzyNiebezpieczny)
        {
            maksymalnaDopuszczalnaLadownosc = MaksymalnaLadownosc * 0.5;
        }
        else
        {
            maksymalnaDopuszczalnaLadownosc = MaksymalnaLadownosc * 0.9;
        }

        if (MasaLadunku + ladunek > maksymalnaDopuszczalnaLadownosc)
        {
            Powiadom("Przepełnienie");
            throw new ExceptionPrzepelnienie("Nie można załadować więcej niż pojemność");
        }
        MasaLadunku += ladunek;
    }

    public override void Rozladuj()
    {
        MasaLadunku = 0;
    }

    public void Powiadom(string message)
    {
        Console.WriteLine($"Niebezpieczeństwo: {message} w kontenerze {NumerSeryjny}");
    }
    
    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine($"Czy niebezpieczny: {CzyNiebezpieczny}");
    }
}