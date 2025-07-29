public class Kendaraan
{
    public string NomorPolisi { get; set; }
    public string Tipe { get; set; } // "Mobil" atau "Motor"
    public string Warna { get; set; }

    public Kendaraan(string nomorPolisi, string tipe, string warna)
    {
        NomorPolisi = nomorPolisi;
        Tipe = tipe;
        Warna = warna;
    }
}
