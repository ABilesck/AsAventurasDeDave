using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    [SerializeField] private int dano;
    
    private float velocidade;

    private void Update()
    {
        velocidade = GameManager.instancia.VelocidadeDoJogo;

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<SaudeJogador>().LevarDano(dano);
            Destroy(gameObject);
        }
    }
}
