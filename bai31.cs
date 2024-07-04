using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SinhVien
{
    public string MSSV { get; set; }
    public string HoTen { get; set; }
    public double DiemToan { get; set; }
    public double DiemLy { get; set; }
    public double DiemHoa { get; set; }

    public double DiemTrungBinh
    {
        get { return (DiemToan + DiemLy + DiemHoa) / 3; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<SinhVien> danhSachSinhVien = new List<SinhVien>();

        int soLuongSinhVien = NhapSoLuongSinhVien();
        NhapThongTinSinhVien(soLuongSinhVien, danhSachSinhVien);
        TinhDiemTrungBinh(danhSachSinhVien);
        HienThiThongTinSinhVien(danhSachSinhVien);
        HienThiSinhVienDiemCao(danhSachSinhVien);
        DemSinhVienDiemLon(danhSachSinhVien);
        SapXepSinhVienTheoDiem(danhSachSinhVien);
        SapXepSinhVienTheoTen(danhSachSinhVien);
        GhiThongTinSinhVienVaoFile(danhSachSinhVien);
        DocThongTinSinhVienTuFile();
    }

    static int NhapSoLuongSinhVien()
    {
        int soLuongSinhVien = 0;
        try
        {
            Console.Write("Nhap so luong sinh vien: ");
            soLuongSinhVien = int.Parse(Console.ReadLine());
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi: {ex.Message}");
        }
        return soLuongSinhVien;
    }

    static void NhapThongTinSinhVien(int soLuong, List<SinhVien> danhSach)
    {
        for (int i = 0; i < soLuong; i++)
        {
            try
            {
                SinhVien sv = new SinhVien();
                Console.Write("Nhap MSSV: ");
                sv.MSSV = Console.ReadLine();
                Console.Write("Nhap Ho Ten: ");
                sv.HoTen = Console.ReadLine();
                Console.Write("Nhap Diem Toan: ");
                sv.DiemToan = double.Parse(Console.ReadLine());
                Console.Write("Nhap Diem Ly: ");
                sv.DiemLy = double.Parse(Console.ReadLine());
                Console.Write("Nhap Diem Hoa: ");
                sv.DiemHoa = double.Parse(Console.ReadLine());
                danhSach.Add(sv);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Loi: {ex.Message}");
            }
        }
    }

    static void TinhDiemTrungBinh(List<SinhVien> danhSach)
    {
        foreach (var sv in danhSach)
        {
            Console.WriteLine($"Diem Trung Binh cua SV {sv.HoTen}: {sv.DiemTrungBinh}");
        }
    }

    static void HienThiThongTinSinhVien(List<SinhVien> danhSach)
    {
        foreach (var sv in danhSach)
        {
            Console.WriteLine($"MSSV: {sv.MSSV}, Ho Ten: {sv.HoTen}, Diem Trung Binh: {sv.DiemTrungBinh:F2}");
        }
    }

    static void HienThiSinhVienDiemCao(List<SinhVien> danhSach)
    {
        foreach (var sv in danhSach)
        {
            if (sv.DiemTrungBinh > 9.5)
            {
                Console.WriteLine($"SV co diem TB > 9.5: {sv.HoTen}, Diem TB: {sv.DiemTrungBinh}");
                break;
            }
        }
    }

    static void DemSinhVienDiemLon(List<SinhVien> danhSach)
    {
        int count = 0;
        foreach (var sv in danhSach)
        {
            if (sv.DiemTrungBinh > 5.0)
            {
                count++;
            }
        }
        Console.WriteLine($"So luong sinh vien co diem TB > 5.0: {count}");
    }

    static void SapXepSinhVienTheoDiem(List<SinhVien> danhSach)
    {
        var sapXepTheoDiem = danhSach.OrderBy(sv => sv.DiemTrungBinh).ToList();
        Console.WriteLine("Danh sach sinh vien sap xep theo diem TB tang dan:");
        HienThiThongTinSinhVien(sapXepTheoDiem);
    }

    static void SapXepSinhVienTheoTen(List<SinhVien> danhSach)
     {
        var sapXepTheoTen = danhSach.OrderBy(sv => sv.HoTen).ToList();
        Console.WriteLine("Danh sach sinh vien sap xep theo ten alphabet:");
        HienThiThongTinSinhVien(sapXepTheoTen);
    }

    static void GhiThongTinSinhVienVaoFile(List<SinhVien> danhSach)
    {
        try
        {
            Console.Write("Nhap ten file de ghi thong tin: ");
            string fileName = Console.ReadLine();
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (var sv in danhSach)
                {
                    sw.WriteLine($"{sv.MSSV},{sv.HoTen},{sv.DiemToan},{sv.DiemLy},{sv.DiemHoa},{sv.DiemTrungBinh:F2}");
                }
            }
            Console.WriteLine("Da ghi thong tin sinh vien vao file thanh cong.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi khi ghi file: {ex.Message}");
        }
    }

    static void DocThongTinSinhVienTuFile()
    {
        try
        {
            Console.Write("Nhap ten file de doc thong tin: ");
            string fileName = Console.ReadLine();
            List<SinhVien> danhSachSinhVien = new List<SinhVien>();

            using (StreamReader sr = new StreamReader(fileName))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var data = line.Split(',');
                    SinhVien sv = new SinhVien
                    {
                        MSSV = data[0],
                        HoTen = data[1],
                        DiemToan = double.Parse(data[2]),
                        DiemLy = double.Parse(data[3]),
                        DiemHoa = double.Parse(data[4])
                    };
                    danhSachSinhVien.Add(sv);
                }
            }
            Console.WriteLine("Da doc thong tin sinh vien tu file thanh cong.");
            HienThiThongTinSinhVien(danhSachSinhVien);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Loi khi doc file: {ex.Message}");
        }
    }
}