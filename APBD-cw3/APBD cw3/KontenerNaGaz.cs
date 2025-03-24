namespace APBD_cw3;

public class KontenerNaGaz : Kontener, InterfaceNiebezpieczenstwo
{
    public double Cisnienie { get; set; }

    public KontenerNaGaz(double wysokosc, double glebokosc, double wagaWlasna, double maksymalnaLadownosc, double cisnienie)
        : base("G", wysokosc, glebokosc, wagaWlasna, maksymalnaLadownosc)
    {
        Cisnienie = cisnienie;
    }

    public override void Zaladuj(double ladunek)
    {
        if (MasaLadunku + ladunek > MaksymalnaLadownosc)
        {
            Powiadom("Przepełnienie");
            throw new ExceptionPrzepelnienie("Nie można załadować więcej niż pojemność");
        }
        MasaLadunku += ladunek;
    }

    public override void Rozladuj()
    {
        MasaLadunku *= 0.05;
    }

    public void Powiadom(string message)
    {
        Console.WriteLine($"Niebezpieczeństwo: {message} w kontenerze {NumerSeryjny}");
    }
    
    public override void WyswietlInformacje()
    {
        base.WyswietlInformacje();
        Console.WriteLine($"Ciśnienie: {Cisnienie}");
    }
}