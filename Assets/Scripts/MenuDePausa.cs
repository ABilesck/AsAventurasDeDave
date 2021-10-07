using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuDePausa : MonoBehaviour
{
    [SerializeField] GameObject Menu;
    public static bool estaPausado;

    public void Pausar()
    {
        estaPausado = true;
        Menu.SetActive(true);
        Time.timeScale = 0;

    }

    public void Resumir()
    {
        estaPausado = false;
        Menu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
