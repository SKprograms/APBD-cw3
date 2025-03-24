namespace APBD_cw3;

public class Kontenerowiec
{
    public List<Kontener> Kontenery { get; set; } = new List<Kontener>();
    public double MaksymalnaWaga { get; set; }
    public int MaksymalnaLiczbaKontenerow { get; set; }
    public double MaksymalnaPredkosc { get; set; }

    public Kontenerowiec(double maksymalnaWaga, int maksymalnaLiczbaKontenerow, double maksymalnaPredkosc)
    {
        MaksymalnaWaga = maksymalnaWaga;
        MaksymalnaLiczbaKontenerow = maksymalnaLiczbaKontenerow;
        MaksymalnaPredkosc = maksymalnaPredkosc;
    }

    public void ZaladujKontener(Kontener kontener)
    {
        if (Kontenery.Count >= MaksymalnaLiczbaKontenerow || Kontenery.Sum(kontener => kontener.MasaLadunku) + kontener.MasaLadunku > MaksymalnaWaga)
        {
            throw new InvalidOperationException("Nie można załadować więcej kontenerów.");
        }
        Kontenery.Add(kontener);
    }

    public void ZaladujListeKontenerow(List<Kontener> kontenery)
    {
        foreach (var kontener in kontenery)
        {
            ZaladujKontener(kontener);
        }
    }

    public void RozladujKontener(Kontener kontener)
    {
        Kontenery.Remove(kontener);
    }

    public void ZastapKontener(string numerSeryjny, Kontener nowyKontener)
    {
        Kontener kontener = null;
        foreach (var k in Kontenery)
        {
            if (k.NumerSeryjny == numerSeryjny)
            {
                kontener = k;
                break;
            }
        }

        if (kontener != null)
        {
            RozladujKontener(kontener);
            ZaladujKontener(nowyKontener);
        }
    }

    public void PrzeniesKontener(Kontenerowiec docelowyStatek, Kontener kontener)
    {
        RozladujKontener(kontener);
        docelowyStatek.ZaladujKontener(kontener);
    }

    public void WypiszInformacjeOKontenerze(string numerSeryjny)
    {
        Kontener kontener = null;
        foreach (var k in Kontenery)
        {
            if (k.NumerSeryjny == numerSeryjny)
            {
                kontener = k;
                break;
            }
        }

        if (kontener != null)
        {
            Console.WriteLine($"Kontener {kontener.NumerSeryjny}");
        }
    }

    public void WypiszInformacjeOStatku()
    {
        Console.WriteLine($"Statek: Maksymalna waga = {MaksymalnaWaga}, Maksymalna liczba kontenerów = {MaksymalnaLiczbaKontenerow}, Maksymalna prędkość = {MaksymalnaPredkosc}");
        foreach (var kontener in Kontenery)
        {
            WypiszInformacjeOKontenerze(kontener.NumerSeryjny);
        }
    }
}