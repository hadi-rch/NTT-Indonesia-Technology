using System;
using System.Linq;

public class Program
{
    // Variabel untuk menampung data parkir.
    // 'static' agar bisa diakses di seluruh bagian program.
    private static Kendaraan[] _slots;

    public static void Main(string[] args)
    {
        while (true)
        {
            string input = Console.ReadLine().Trim();
            if (string.IsNullOrEmpty(input)) continue;

            string[] parts = input.Split(' ');
            string command = parts[0];

            if (command == "exit")
            {
                break;
            }

            switch (command)
            {
                case "create_parking_lot":
                    // Ambil jumlah slot dari argumen kedua
                    int jumlahSlot = int.Parse(parts[1]);
                    // Buat array dengan ukuran yg ditentukan. Kita tambah 1 agar bisa pakai index 1-based.
                    _slots = new Kendaraan[jumlahSlot + 1];
                    Console.WriteLine($"Created a parking lot with {jumlahSlot} slots");
                    break;

                case "park":
                    // Cek dulu apakah lahan parkir sudah dibuat
                    if (_slots == null)
                    {
                        Console.WriteLine("Parking lot belum dibuat. Gunakan perintah 'create_parking_lot'.");
                        break;
                    }

                    // Cari slot pertama yang kosong (null)
                    int slotNumber = -1;
                    for (int i = 1; i < _slots.Length; i++)
                    {
                        if (_slots[i] == null)
                        {
                            slotNumber = i;
                            break;
                        }
                    }

                    if (slotNumber == -1)
                    {
                        Console.WriteLine("Sorry, parking lot is full");
                    }
                    else
                    {
                        // Ambil data kendaraan dari argumen
                        string nomorPolisi = parts[1];
                        string warna = parts[2];
                        string tipe = parts[3]; // Di soal aslinya "B-1234-XYZ Putih Mobil" , tapi contohnya "park B-1234-XYZ Putih Mobil". Kita ikuti contoh dengan 4 bagian.

                        _slots[slotNumber] = new Kendaraan(nomorPolisi, tipe, warna);
                        Console.WriteLine($"Allocated slot number: {slotNumber}");
                    }
                    break;

                case "leave":
                    int slotToLeave = int.Parse(parts[1]);
                    if (_slots != null && slotToLeave > 0 && slotToLeave < _slots.Length)
                    {
                        _slots[slotToLeave] = null; // Kosongkan slot
                        Console.WriteLine($"Slot number {slotToLeave} is free");
                    }
                    break;

                case "status":
                    if (_slots == null) break;

                    Console.WriteLine("Slot\tNo.\t\tType\tRegistration No Colour");
                    for (int i = 1; i < _slots.Length; i++)
                    {
                        if (_slots[i] != null)
                        {
                            var kendaraan = _slots[i];
                            // Format agar rapi seperti tabel
                            Console.WriteLine($"{i}\t{kendaraan.NomorPolisi}\t{kendaraan.Tipe}\t{kendaraan.Warna}");
                        }
                    }
                    break;

                case "type_of_vehicles":
                    string tipeKendaraan = parts[1];
                    // Hitung kendaraan di array yg tidak null dan tipenya cocok
                    int countByType = _slots.Count(k => k != null && k.Tipe.Equals(tipeKendaraan, StringComparison.OrdinalIgnoreCase));
                    Console.WriteLine(countByType);
                    break;

                case "registration_numbers_for_vehicles_with_ood_plate": // Ini 'odd' (ganjil)
                                                                         // Ambil semua nopol yg angka terakhirnya ganjil
                    var oddPlates = _slots.Where(k => k != null && int.Parse(k.NomorPolisi.Split('-')[1]) % 2 != 0)
                                          .Select(k => k.NomorPolisi);
                    Console.WriteLine(string.Join(", ", oddPlates));
                    break;

                case "registration_numbers_for_vehicles_with_event_plate": // Ini 'even' (genap)
                                                                           // Ambil semua nopol yg angka terakhirnya genap
                    var evenPlates = _slots.Where(k => k != null && int.Parse(k.NomorPolisi.Split('-')[1]) % 2 == 0)
                                           .Select(k => k.NomorPolisi);
                    Console.WriteLine(string.Join(", ", evenPlates));
                    break;

                case "registration_numbers_for_vehicles_with_colour":
                    string warnaUntukCari = parts[1];
                    var platesByColor = _slots.Where(k => k != null && k.Warna.Equals(warnaUntukCari, StringComparison.OrdinalIgnoreCase))
                                               .Select(k => k.NomorPolisi);
                    Console.WriteLine(string.Join(", ", platesByColor));
                    break;

                case "slot_numbers_for_vehicles_with_colour":
                    string warnaSlot = parts[1];
                    // Kita butuh index (nomor slot), jadi kita tidak bisa pakai query biasa
                    var slotNumbersByColor = Enumerable.Range(1, _slots.Length - 1)
                                                       .Where(i => _slots[i] != null && _slots[i].Warna.Equals(warnaSlot, StringComparison.OrdinalIgnoreCase))
                                                       .Select(i => i.ToString());
                    Console.WriteLine(string.Join(", ", slotNumbersByColor));
                    break;

                case "slot_number_for_registration_number":
                    string nopolUntukCari = parts[1];
                    int slotResult = -1;
                    for (int i = 1; i < _slots.Length; i++)
                    {
                        if (_slots[i] != null && _slots[i].NomorPolisi.Equals(nopolUntukCari, StringComparison.OrdinalIgnoreCase))
                        {
                            slotResult = i;
                            break;
                        }
                    }

                    if (slotResult != -1)
                    {
                        Console.WriteLine(slotResult);
    }
                    else
                    {
                        Console.WriteLine("Not found");
    }
                    break;

                default:
                    Console.WriteLine("Perintah tidak dikenali.");
                    break;
            }
        }
    }
}