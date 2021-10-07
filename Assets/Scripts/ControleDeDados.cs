using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeDados : MonoBehaviour
{
    public static ControleDeDados instancia;

    private void Awake()
    {
        if (instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void Salvar(int moedas, int vida)
    {
        SalvarJogo.Salvar(moedas, vida);
    }

    public void SalvarNovasMoedas(int moedas)
    {
        SalvarJogo.Salvar(moedas, GameManager.instancia.MaxVida);
    }
    public void SalvarVida(int qtd)
    {
        SalvarJogo.Salvar(GameManager.instancia.TotalMoedas, qtd);
    }
}
