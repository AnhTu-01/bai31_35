using System;

// Định nghĩa lớp trừu tượng Shape
public abstract class Shape
{
    private int _soDinh;

    public int SoDinh
    {
        get { return _soDinh; }
        set
        {
            if (value <= 0)
                throw new ArgumentException("Số đỉnh phải lớn hơn 0.");
            _soDinh = value;
        }
    }
}

// Định nghĩa lớp tam_giac kế thừa từ Shape
public class tam_giac : Shape
{
    public tam_giac()
    {
        SoDinh = 3; // Số đỉnh của tam giác luôn là 3
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Tạo một đối tượng tam_giac
        tam_giac t = new tam_giac();
        Console.WriteLine($"Số đỉnh của tam giác: {t.SoDinh}");

        // Tạo một đối tượng Shape với số đỉnh không hợp lệ
        try
        {
            Shape s = new tam_giac
            {
                SoDinh = 0
            };
        }
        catch (ArgumentException e)
        {
            Console.WriteLine(e.Message);
        }
    }
}