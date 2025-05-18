using System;
using System.Collections.Generic;
using System.Linq;
abstract class ManajemenMahasiswa
{
    public abstract void TambahMahasiswa();
    public abstract void LihatMahasiswa();
    public abstract void UpdateMahasiswa();
    public abstract void HapusMahasiswa();
}
class Mahasiswa
{
    private string nim;
    private string nama;#if
    private string jurusan;

    public string NIM
    {
        get { return nim; }
        set { nim = value; }
    }

    public string Nama
    {
        get { return nama; }
        set { nama = value; }
    }

    public string Jurusan
    {
        get { return jurusan; }
        set { jurusan = value; }
    }
}
class TurunanMahasiswa : ManajemenMahasiswa
{
    private List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();

    public override void TambahMahasiswa()
    {
        Console.Write("Masukkan NIM: ");
        string nim = Console.ReadLine();

        if (daftarMahasiswa.Any(m => m.NIM == nim))
        {
            Console.WriteLine("NIM sudah ada. Mahasiswa gagal ditambahkan.");
            return;
        }

        Console.Write("Masukkan Nama: ");
        string nama = Console.ReadLine();
        Console.Write("Masukkan Jurusan: ");
        string jurusan = Console.ReadLine();

        Mahasiswa mhs = new Mahasiswa
        {
            NIM = nim,
            Nama = nama,
            Jurusan = jurusan
        };

        daftarMahasiswa.Add(mhs);
        Console.WriteLine("Mahasiswa berhasil ditambahkan.\n");
    }

    public override void LihatMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Belum ada data mahasiswa.\n");
            return;
        }

        Console.WriteLine("\nData Mahasiswa:");
        foreach (var m in daftarMahasiswa)
        {
            Console.WriteLine($"NIM: {m.NIM}, Nama: {m.Nama}, Jurusan: {m.Jurusan}");
        }
        Console.WriteLine();
    }

    public override void UpdateMahasiswa()
    {
        Console.Write("Masukkan NIM mahasiswa yang ingin diupdate: ");
        string nim = Console.ReadLine();

        var mahasiswa = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);
        if (mahasiswa == null)
        {
            Console.WriteLine("Mahasiswa dengan NIM tersebut tidak ditemukan.\n");
            return;
        }

        Console.Write("Masukkan Nama baru: ");
        mahasiswa.Nama = Console.ReadLine();
        Console.Write("Masukkan Jurusan baru: ");
        mahasiswa.Jurusan = Console.ReadLine();

        Console.WriteLine("Data mahasiswa berhasil diupdate.\n");
    }

    public override void HapusMahasiswa()
    {
        Console.Write("Masukkan NIM mahasiswa yang ingin dihapus: ");
        string nim = Console.ReadLine();

        var mahasiswa = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);
        if (mahasiswa == null)
        {
            Console.WriteLine("Mahasiswa dengan NIM tersebut tidak ditemukan.\n");
            return;
        }

        daftarMahasiswa.Remove(mahasiswa);
        Console.WriteLine("Mahasiswa berhasil dihapus.\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        TurunanMahasiswa turunan = new TurunanMahasiswa();
        int pilihan;

        do
        {
            Console.WriteLine("=== Menu Mahasiswa ===");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih menu (1-5): ");
            if (!int.TryParse(Console.ReadLine(), out pilihan)) pilihan = 0;

            Console.WriteLine();
            switch (pilihan)
            {
                case 1:
                    turunan.TambahMahasiswa();
                    break;
                case 2:
                    turunan.LihatMahasiswa();
                    break;
                case 3:
                    turunan.UpdateMahasiswa();
                    break;
                case 4:
                    turunan.HapusMahasiswa();
                    break;
                case 5:
                    Console.WriteLine("Terima kasih. Program selesai.");
                    break;
                default:
                    Console.WriteLine("Pilihan tidak valid.\n");
                    break;
            }

        } while (pilihan != 5);
    }
}
