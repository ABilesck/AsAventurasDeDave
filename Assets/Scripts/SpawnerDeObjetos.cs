using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerDeObjetos : MonoBehaviour
{
    [Tooltip("Colocar todos os objetos que entrarão na cena e que tenha interação")]
    [SerializeField] private GameObject[] objetos;
    [Space]
    [Tooltip("Tempo inicial entre spawn entre dois objetos")]
    [SerializeField] private float tempoInicialDeSpawn;
    [Tooltip("decremento do tempo de spawn entre dois objetos")]
    [SerializeField] private float decrementoDeTempo;
    [Tooltip("tempo minimo de spawn entre dois objetos")]
    [SerializeField] private float MinTempoDeSpawn;

    private float tempoEntreSpawn;

    private void Update()
    {
        if(tempoEntreSpawn <= 0)
        {
            int rand = Random.Range(0, objetos.Length);
            Instantiate(objetos[rand], transform.position, Quaternion.identity);
            tempoEntreSpawn = tempoInicialDeSpawn;
            if(tempoInicialDeSpawn > MinTempoDeSpawn)
                tempoInicialDeSpawn -= decrementoDeTempo;
        }
        else
        {
            tempoEntreSpawn -= Time.deltaTime;
        }
    }
}
