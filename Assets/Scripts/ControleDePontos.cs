using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ControleDePontos : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtPontos;
    [SerializeField] private float cronometro;
    [SerializeField] private GameObject telaVitoria;
    
    private int pontos;
    private int metrosTotais;

    public int Pontos { get => pontos; set => pontos = value; }

    private void Start()
    {
        Pontos = 0;
        txtPontos.text = pontos.ToString();
        if (GameManager.instancia != null)
            metrosTotais = GameManager.instancia.MetrosParaCorrer;
        else
            metrosTotais = -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("obstaculo"))
        {
            if(metrosTotais == -1)
            {
                pontos++;
                txtPontos.text = pontos.ToString();
            }
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag("bonus"))
        {
            Destroy(collision.gameObject);
        }

    }

    private void Update()
    {
        if(metrosTotais != -1)
        {
            cronometro += Time.deltaTime;

            if (cronometro >= 1)
            {
                DarPontos(1);
                cronometro = 0;
            }

            if(pontos >= metrosTotais)
            {
                Time.timeScale = 0f;
                telaVitoria.SetActive(true);
            }
        }
    }

    internal void DarPontos(int pontos)
    {
        if(GameManager.instancia.VelocidadeDoJogo != 0)
        {
            this.pontos += pontos;
            txtPontos.text = this.pontos.ToString();
        }
    }
}
