using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using TMPro;

public class MenuGameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI txtPontos;


    public void Replay()
    {
        Time.timeScale = 1f;
        GameManager.instancia.ResetVelocidade();
        GameManager.instancia.AtualizarMoedas(FindObjectOfType<ControleDeMoedas>().Moedas);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Sair()
    {
        Time.timeScale = 1f;
        GameManager.instancia.AtualizarMoedas(FindObjectOfType<ControleDeMoedas>().Moedas);
        SceneManager.LoadScene("MenuPrincipal");
    }

    private void OnEnable()
    {
        txtPontos.text = FindObjectOfType<ControleDePontos>().Pontos.ToString();
    }
}
