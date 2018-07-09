using System;

public class Test
{
    public static void Main()
    {
        int a, b, c;
        a = 0;
        b = 0;
        c = 0;
        Console.WriteLine(Builder(a, b, c));
    }
    private static string Builder(int a, int b, int c)
    {
        string s = "";
        if (a == 0 && b == 0 && c == 0)
        {
            s += 0;
        }
        s += GetA(a, b, c);
        s += GetB(a, b, c);
        s += GetC(a, b, c);
        s += " = 0";

        return s;
    }
    private static string GetA(int a, int b, int c)
    {
        return First(a, "x<sup>2</sup>");
    }
    private static string GetB(int a, int b, int c)
    {
        string s = "";
        if (a == 0)
        {
            return First(b, "x");
        }
        if (b != 0)
        {
            if (b < 0)
            {
                s += " - ";
                b = -b;
            }
            else
            {
                s += " + ";
            }
            if (b != 1)
            {
                s += b;
            }
            s += "x";
        }
        return s;
    }
    private static string GetC(int a, int b, int c)
    {
        if (a == 0 && b == 0)
        {
            return First(c, "");
        }
        string s = "";
        if (c != 0)
        {
            if (c < 0)
            {
                s += " - ";
                c = -c;
            }
            else
            {
                s += " + ";
            }
            s += c;
        }
        return s;
    }
    private static string First(int d, string x)
    {
        string s = "";
        if (d != 0)
        {
            if (d < 0)
            {
                s += "-";
                d = -d;
            }
            if (d != 1)
            {
                s += d;
            }
            if (d == 1 && x == "")
            {
                s += 1;
            }
            s += x;
        }
        return s;
    }
}