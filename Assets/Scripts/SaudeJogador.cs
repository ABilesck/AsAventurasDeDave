using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaudeJogador : MonoBehaviour
{
    [SerializeField] private Image[] Coracoes;
    [SerializeField] private GameObject TelaDeGameOver;

    private Animator animator;
    private int saude;

    private void Start()
    {
        saude = GameManager.instancia.MaxVida;
        animator = GetComponent<Animator>();
        UpdateCoracoes();
    }

    public bool JogadorEstaVivo()
    {
        if (saude > 0)
            return true;
        else
            return false;
    }

    public void LevarDano(int qtd)
    {
        saude -= qtd;
        UpdateCoracoes();

        if (saude <= 0)
        {
            
            animator.SetBool("perdeu", true);
        }
    }

    public void DarVida(int qtd)
    {
        saude += qtd;

        if (saude > GameManager.instancia.MaxVida)
        {
            saude = GameManager.instancia.MaxVida;
        }

        UpdateCoracoes();
    }

    private void UpdateCoracoes()
    {
        for (int i = 0; i < Coracoes.Length; i++)
        {
            if (i < saude)
            {
                Coracoes[i].enabled = true;
            }
            else
            {
                Coracoes[i].enabled = false;
            }
        }
    }

    public void Morrer()
    {
        GameManager.instancia.VelocidadeDoJogo = 0;
        TelaDeGameOver.SetActive(true);
    }
}
