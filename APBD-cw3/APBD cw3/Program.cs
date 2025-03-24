namespace APBD_cw3;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Tworzenie kontenera chłodniczego 1");
            KontenerChlodniczy kontenerChlodniczy1 = new KontenerChlodniczy(200, 300, 500, 2000, -5, Produkt.Meat);
            kontenerChlodniczy1.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Tworzenie kontenera chłodniczego 2");
            KontenerChlodniczy kontenerChlodniczy2 = new KontenerChlodniczy(200, 300, 500, 2000, -18, Produkt.IceCream);
            kontenerChlodniczy2.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Tworzenie kontenera na płyny 1");
            KontenerNaPlyny kontenerNaPlyny1 = new KontenerNaPlyny(200, 300, 500, 2000, true);
            kontenerNaPlyny1.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Tworzenie kontenera na gaz 1");
            KontenerNaGaz kontenerNaGaz1 = new KontenerNaGaz(200, 300, 500, 2000, 5);
            kontenerNaGaz1.WyswietlInformacje();
            Console.WriteLine("------------------");

            Console.WriteLine("Załadowanie ładunku do kontenera chłodniczego 1");
            kontenerChlodniczy1.Zaladuj(1500);
            kontenerChlodniczy1.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie ładunku do kontenera chłodniczego 2");
            kontenerChlodniczy2.Zaladuj(1800);
            kontenerChlodniczy2.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie ładunku do kontenera na płyny 1");
            kontenerNaPlyny1.Zaladuj(1000);
            kontenerNaPlyny1.WyswietlInformacje();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie ładunku do kontenera na gaz 1");
            kontenerNaGaz1.Zaladuj(1200);
            kontenerNaGaz1.WyswietlInformacje();
            Console.WriteLine("------------------");

            Console.WriteLine("Tworzenie kontenerowca 1");
            Kontenerowiec kontenerowiec1 = new Kontenerowiec(10000, 10, 20);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
            Console.WriteLine("Tworzenie kontenerowca 2");
            Kontenerowiec kontenerowiec2 = new Kontenerowiec(15000, 15, 25);
            kontenerowiec2.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");

            Console.WriteLine("Załadowanie kontenera chłodniczego 1 na kontenerowiec 1");
            kontenerowiec1.ZaladujKontener(kontenerChlodniczy1);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie kontenera chłodniczego 2 na kontenerowiec 1");
            kontenerowiec1.ZaladujKontener(kontenerChlodniczy2);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie kontenera na płyny 1 na kontenerowiec 1");
            kontenerowiec1.ZaladujKontener(kontenerNaPlyny1);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
            Console.WriteLine("Załadowanie kontenera na gaz 1 na kontenerowiec 1");
            kontenerowiec1.ZaladujKontener(kontenerNaGaz1);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");

            Console.WriteLine("Załadowanie listy kontenerów na kontenerowiec 2");
            List<Kontener> kontenery = new List<Kontener> { kontenerChlodniczy1, kontenerChlodniczy2, kontenerNaPlyny1, kontenerNaGaz1 };
            kontenerowiec2.ZaladujListeKontenerow(kontenery);
            kontenerowiec2.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");

            Console.WriteLine("Usunięcie kontenera chłodniczego 1 z kontenerowca 1");
            kontenerowiec1.RozladujKontener(kontenerChlodniczy1);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");

            Console.WriteLine("Rozładowanie kontenera chłodniczego 1");
            kontenerChlodniczy1.Rozladuj();
            kontenerChlodniczy1.WyswietlInformacje();
            Console.WriteLine("------------------");

            Console.WriteLine("Zastąpienie kontenera chłodniczego 2 na kontenerowcu 1 nowym kontenerem chłodniczym");
            KontenerChlodniczy nowyKontenerChlodniczy = new KontenerChlodniczy(200, 300, 500, 2000, -7, Produkt.Cheese);
            Console.WriteLine("Załadowanie ładunku do nowego kontenera");
            nowyKontenerChlodniczy.Zaladuj(1000);
            nowyKontenerChlodniczy.WyswietlInformacje();
            Console.WriteLine("------------------");
            kontenerowiec1.ZastapKontener(kontenerChlodniczy2.NumerSeryjny, nowyKontenerChlodniczy);
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");

            Console.WriteLine("Przeniesienie nowego kontenera chłodniczego z kontenerowca 1 na kontenerowiec 2");
            kontenerowiec1.PrzeniesKontener(kontenerowiec2, nowyKontenerChlodniczy);
            
            Console.WriteLine("Wypisanie informacji o kontenerowcu 1");
            kontenerowiec1.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
            
            Console.WriteLine("Wypisanie informacji o kontenerowcu 2");
            kontenerowiec2.WypiszInformacjeOStatku();
            Console.WriteLine("------------------");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Błąd: {e.Message}");
        }
    }
}