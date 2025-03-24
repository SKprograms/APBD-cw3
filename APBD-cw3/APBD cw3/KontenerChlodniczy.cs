using System.Data;

namespace APBD_cw3;

public class KontenerChlodniczy : Kontener, InterfaceNiebezpieczenstwo
{
    public double Temperatura { get; set; }
    public Produkt Produkt { get; set; }

    public static Dictionary<Produkt, double> ListaProduktow = new Dictionary<Produkt, double>
    {
        {Produkt.Bananas, 13.3}, {Produkt.Chocolate, 18}, {Produkt.Fish, 2}, {Produkt.Meat, -15}, {Produkt.IceCream, -18}, {Produkt.FrozenPizza, -30}, {Produkt.Cheese, -7.2}, {Produkt.Sausage, -5}, {Produkt.Butter, 20.5}, {Produkt.Eggs, 19}
    };

    public KontenerChlodniczy(double wysokosc, double glebokosc, double wagaWlasna, double maksymalnaLadownosc, double temperatura, Produkt rodzajProduktu)
        : base("C", wysokosc, glebokosc, wagaWlasna, maksymalnaLadownosc)
    {
        Temperatura = temperatura;
        Produkt = rodzajProduktu;
        if (temperatura < ListaProduktow[rodzajProduktu])
        {
            throw new InvalidDataException("Temperatura jest niższa niż dopuszczalna dla tego produktu.");
        }
    }

    public override void Zaladuj(double ladunek)
    {
        if (MasaLadunku + ladunek > MaksymalnaLadownosc)
        {
            Powiadom("Próba przepełnienia");
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
        Console.WriteLine($"Temperatura: {Temperatura}, Produkt: {Produkt}");
    }
}