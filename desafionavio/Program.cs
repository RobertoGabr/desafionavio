using System;
public class Program
{
    public static void Main()
    {
        string mensagem = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 " +
                          "00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";

        Console.WriteLine(Descriptografa(mensagem));
        Console.ReadLine();
    }

    static string InverteOsUltimosDoisBits(string byteStr)
    {
        string seisPrimeirosBits = byteStr.Substring(0, 6);
        string ultimosDoisInvertidos = byteStr[6] == '0' ? "1" : "0";
        ultimosDoisInvertidos += byteStr[7] == '0' ? "1" : "0";
        return seisPrimeirosBits + ultimosDoisInvertidos;
    }

    static string TrocaACadaQuatroBits(string byteStr)
    {
        return byteStr.Substring(4, 4) + byteStr.Substring(0, 4);
    }

    static string BinarioParaTexto(string[] binario)
    {
        string texto = "";
        foreach (string letra in binario)
        {
            char caractere = (char)Convert.ToInt32(letra, 2);
            texto += caractere;
        }
        return texto;
    }

    static string Descriptografa(string mensagem)
    {
        string[] byteStr = mensagem.Split(' ');
        for (int i = 0; i < byteStr.Length; i++)
        {
            byteStr[i] = InverteOsUltimosDoisBits(byteStr[i]);
            byteStr[i] = TrocaACadaQuatroBits(byteStr[i]);
        }
        return BinarioParaTexto(byteStr);
    }
}