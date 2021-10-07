using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadosJogador
{
    public int moedas;
    public int maxVida;

    public DadosJogador(int moedas, int vida)
    {
        this.moedas = moedas;
        this.maxVida = vida;
    }
}
