using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private int pontos;
    [SerializeField] private float Velocidade;

    private void Update()
    {
        transform.Translate(Vector2.left * Velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<ControleDePontos>().DarPontos(pontos);
            Destroy(gameObject);
        }
    }
}
