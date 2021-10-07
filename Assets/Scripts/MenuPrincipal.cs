using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    [SerializeField] private GameObject menuPrincipal;
    [SerializeField] private GameObject escolhaDoNivel;
    [SerializeField] private GameObject configuracoes;
    [SerializeField] private GameObject loja;
    [SerializeField] private GameObject sobre;

    private void Start()
    {
        FindObjectOfType<ControleAudio>().Parar("jogo");
        FindObjectOfType<ControleAudio>().Tocar("menu");
    }

    public void btnJogar_click()
    {
        menuPrincipal.SetActive(false);
        escolhaDoNivel.SetActive(true);
    }

    public void btnConfiguracoes_click()
    {
        menuPrincipal.SetActive(false);
        configuracoes.SetActive(true);
    }
    public void btnLoja_click()
    {
        menuPrincipal.SetActive(false);
        loja.SetActive(true);
    }

    public void btnSobre_click()
    {
        menuPrincipal.SetActive(false);
        sobre.SetActive(true);
    }

    public void VoltarAoMenu_click()
    {
        escolhaDoNivel.SetActive(false);
        configuracoes.SetActive(false);
        loja.SetActive(false);
        sobre.SetActive(false);
        menuPrincipal.SetActive(true);
    }

    public void escolherLevel_click(int metros)
    {
        FindObjectOfType<ControleAudio>().Parar("menu");
        FindObjectOfType<ControleAudio>().Tocar("jogo");
        Debug.Log(metros.ToString());
        GameManager.instancia.MetrosParaCorrer = metros;
        SceneManager.LoadScene("Jogo");
    }
}
