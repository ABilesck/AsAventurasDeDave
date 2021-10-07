using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLoja : MonoBehaviour
{
    [SerializeField] private int qtdUpgrade = 0;
    [SerializeField] private Image[] Preenchimento;
    [SerializeField] private TMPro.TextMeshProUGUI txtValor;
    [Header("Controle UI")]
    [SerializeField] private TMPro.TextMeshProUGUI txtTotalMoedas;

    private void OnEnable()
    {
        txtTotalMoedas.text = GameManager.instancia.TotalMoedas.ToString();
        qtdUpgrade = GameManager.instancia.MaxVida - 1;
        int novoValor = (qtdUpgrade + 1) * 100;
        txtValor.text = novoValor.ToString();
        AtualizarPreechimento();
    }

    public void btnUpgrade_click()
    {
        if(qtdUpgrade < Preenchimento.Length)
        {
            if(GameManager.instancia.TotalMoedas >= Convert.ToInt32(txtValor.text))
            {
                GameManager.instancia.MaxVida++;
                qtdUpgrade++;
                int novoValor = (qtdUpgrade + 1) * 100;
                GameManager.instancia.AtualizarMoedas(-Convert.ToInt32(txtValor.text));
                txtValor.text = novoValor.ToString();
                txtTotalMoedas.text = GameManager.instancia.TotalMoedas.ToString();
                AtualizarPreechimento();
            }
            
        }
    }

    private void AtualizarPreechimento()
    {
        for (int i = 0; i < Preenchimento.Length; i++)
        {
            if(i < qtdUpgrade)
            {
                Preenchimento[i].enabled = true;
            }
            else
            {
                Preenchimento[i].enabled = false;
            }
        }
    }
}
