using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilesInfinitos : MonoBehaviour
{
    [SerializeField] private float fimX;
    [SerializeField] private float InicioX;

    private float velocidade;
    
    private void Update()
    {
        velocidade = GameManager.instancia.VelocidadeDoJogo;

        transform.Translate(Vector2.left * velocidade * Time.deltaTime);

        if(transform.position.x < fimX)
        {
            Vector2 novaPos = new Vector2(InicioX, transform.position.y);
            transform.position = novaPos;
        }
    }
}
