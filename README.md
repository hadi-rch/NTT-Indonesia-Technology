# Sistem Parkir Sederhana (Console App)

Ini adalah aplikasi konsol sederhana untuk mensimulasikan sistem manajemen parkir. Aplikasi ini dibangun sebagai latihan dasar menggunakan C# dan .NET.

---

## 🚀 Fitur

* Membuat lahan parkir dengan jumlah slot yang ditentukan.
* Memarkirkan kendaraan (Mobil atau Motor).
* Mengeluarkan kendaraan dari slot parkir.
* Menampilkan status slot parkir yang terisi.
* Menyediakan berbagai laporan berdasarkan tipe kendaraan, warna, dan nomor polisi (ganjil/genap).

---

## 🛠️ Teknologi yang Digunakan

* **C#**
* **.NET** (Kompatibel dengan .NET 5 dan versi yang lebih baru)
* **Visual Studio 2022**

---

## ⚙️ Cara Menjalankan Proyek

1.  **Clone repository ini:**
    ```bash
    git clone https://github.com/hadi-rch/NTT-Indonesia-Technology
    ```
2.  **Buka proyek:**
    Buka file `ParkingLot.sln` menggunakan Visual Studio 2022.
3.  **Jalankan program:**
    Tekan `Ctrl + F5` atau klik tombol "Start" berwarna hijau di Visual Studio untuk menjalankan aplikasi.

---

## 📋 Daftar Perintah

Setelah aplikasi berjalan, kamu bisa menggunakan perintah-perintah berikut di dalam konsol:

### Manajemen Parkir

* **Membuat lahan parkir**
    ```
    create_parking_lot 6
    ```

* **Memarkirkan kendaraan**
    ```
    park B-1234-XYZ Putih Mobil
    ```

* **Mengeluarkan kendaraan**
    ```
    leave 4
    ```

* **Melihat status parkir**
    ```
    status
    ```

### Laporan

* **Jumlah kendaraan berdasarkan tipe**
    ```
    type_of_vehicles Mobil
    ```

* **Nomor polisi ganjil**
    ```
    registration_numbers_for_vehicles_with_ood_plate
    ```

* **Nomor polisi genap**
    ```
    registration_numbers_for_vehicles_with_event_plate
    ```

* **Nomor polisi berdasarkan warna**
    ```
    registration_numbers_for_vehicles_with_colour Putih
    ```

* **Nomor slot berdasarkan warna**
    ```
    slot_numbers_for_vehicles_with_colour Putih
    ```

* **Mencari nomor slot berdasarkan nomor polisi**
    ```
    slot_number_for_registration_number B-1234-XYZ
    ```

### Lainnya

* **Keluar dari aplikasi**
    ```
    exit
    ```
