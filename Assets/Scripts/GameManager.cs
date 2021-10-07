using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class GameManager : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] private float velocidade = 7;
    [Header("Controle de anuncios")]
    [SerializeField] string androidGameId;
    [SerializeField] string IOSGameId;
    [SerializeField] bool testMode = true;
    [SerializeField] bool enablePerPlacementMode = true;

    private int metrosParaCorrer; //-1 para infinito
    public static GameManager instancia;
    private string gameId;
    private float velocidadeDoJogo;
    private int maxVida;
    private int totalMoedas;

    public int MetrosParaCorrer { get => metrosParaCorrer; set => metrosParaCorrer = value; }
    public float VelocidadeDoJogo { get => velocidadeDoJogo; set => velocidadeDoJogo = value; }
    public int MaxVida { get => maxVida; set => maxVida = value; }
    public int TotalMoedas { get => totalMoedas; set => totalMoedas = value; }

    private void Awake()
    {
        velocidadeDoJogo = velocidade;
        DadosJogador dj = SalvarJogo.Carregar();

        if (dj != null)
        {
            totalMoedas = dj.moedas;
            maxVida = dj.maxVida;
        }
        else
        {
            ControleDeDados.instancia.Salvar(0, 1);
            totalMoedas = 0;
            maxVida = 1;
        }

        if (instancia != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }

        InitializeAds();
    }

    public void ResetVelocidade()
    {
        velocidadeDoJogo = velocidade; 
    }

    public void AtualizarMoedas(int qtd)
    {
        this.totalMoedas += qtd;
        ControleDeDados.instancia.SalvarNovasMoedas(this.totalMoedas);
    }

    public void AtualizarVida(int qtd)
    {
        this.MaxVida += qtd;
        ControleDeDados.instancia.SalvarVida(this.maxVida);
    }

    public void InitializeAds()
    {
        gameId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? IOSGameId
            : androidGameId;
        Advertisement.Initialize(gameId, testMode, enablePerPlacementMode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.LogError($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}
