using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleDeMoedas : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI txtMoeda;

    private int moedas;

    public int Moedas { get => moedas; set => moedas = value; }

    private void Start()
    {
        moedas = 0;
        txtMoeda.text = moedas.ToString();
    }
    public void DarMoedas(int moedas)
    {
        this.moedas += moedas;
        txtMoeda.text = this.moedas.ToString();
    }
}
