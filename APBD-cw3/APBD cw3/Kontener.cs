namespace APBD_cw3;

public abstract class Kontener
{
    private static int NastepnyNumer = 1;
    public string NumerSeryjny { get; private set; }
    public double MaksymalnaLadownosc { get; set; }
    public double MasaLadunku { get; set; }
    public double Wysokosc { get; set; }
    public double WagaWlasna { get; set; }
    public double Glebokosc { get; set; }

    public Kontener(string typKontenera, double wysokosc, double glebokosc, double wagaWlasna, double maksymalnaLadownosc)
    {
        NumerSeryjny = "KON-" + typKontenera + "-" + NastepnyNumer++;
        Wysokosc = wysokosc;
        Glebokosc = glebokosc;
        WagaWlasna = wagaWlasna;
        MaksymalnaLadownosc = maksymalnaLadownosc;
        MasaLadunku = 0;
    }

    public abstract void Zaladuj(double ladunek);
    public abstract void Rozladuj();

    public virtual void WyswietlInformacje()
    {
        Console.WriteLine($"Kontener {NumerSeryjny}: Wysokość = {Wysokosc}, Głębokość = {Glebokosc}, Waga własna = {WagaWlasna}, Maksymalna ładowność = {MaksymalnaLadownosc}, Masa ładunku = {MasaLadunku}");
    }
}