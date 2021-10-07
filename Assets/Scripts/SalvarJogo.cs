using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SalvarJogo
{
    public static void Salvar(int moedas, int vida)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "dinossauro.din";
        
        FileStream stream = new FileStream(path, FileMode.Create);

        DadosJogador dj = new DadosJogador(moedas, vida);
        formatter.Serialize(stream, dj);
        stream.Close();
    }

    public static DadosJogador Carregar()
    {
        string path = Application.persistentDataPath + "dinossauro.din";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            
            DadosJogador dj = formatter.Deserialize(stream) as DadosJogador;
            stream.Close();
            
            return dj;
        }
        else
        {
            Debug.LogError("Arquivo nao existe ou nao encontrado");
        }
        return null;
    }
}
