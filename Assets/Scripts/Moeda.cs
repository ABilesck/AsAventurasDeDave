using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moeda : MonoBehaviour
{
    [SerializeField] private int quantidade;
    [SerializeField] private bool acompanhaObstaculo = false;
    
    private float velocidade;

    private void Update()
    {
        velocidade = GameManager.instancia.VelocidadeDoJogo;
        if(!acompanhaObstaculo)
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ControleAudio.instancia.Tocar("moeda");
            FindObjectOfType<ControleDeMoedas>().DarMoedas(quantidade);
            Destroy(gameObject);
        }
    }
}
