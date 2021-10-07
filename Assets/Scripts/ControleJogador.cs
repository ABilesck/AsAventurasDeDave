using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ControleJogador : MonoBehaviour
{
    [Header("Controles")]
    [SerializeField] private float TempoNoAr = 0.3f;
    [SerializeField] private float ForcaDoPulo = 3f;
    [SerializeField] private LayerMask OQueEChao;
    [Header("Verificar chão")]
    [SerializeField] private float distanciaDoChao = 0.1f;
    [SerializeField] private Transform posicaoPes;

    private Animator animator;
    private Rigidbody2D rb;
    
    private bool noChao;
    private bool pulando;
    private float ContadorTempoNoAr;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }



    // Update is called once per frame
    void Update()
    {
        noChao = Physics2D.OverlapCircle(posicaoPes.position, distanciaDoChao, OQueEChao);

        controlarPulo();
        controlarAnim();
    }

    private void controlarAnim()
    {
        animator.SetBool("noChao", noChao);
        animator.SetBool("pulando", pulando);
    }

    private void controlarPulo()
    {
        if (noChao && Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) return;

            pulando = true;
            rb.velocity = Vector2.up * ForcaDoPulo;
            ContadorTempoNoAr = TempoNoAr;
        }
        if (Input.GetMouseButton(0) && pulando)
        {
            if (ContadorTempoNoAr > 0)
            {
                rb.velocity = Vector2.up * ForcaDoPulo;
                ContadorTempoNoAr -= Time.deltaTime;
            }
            else
            {
                pulando = false;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            pulando = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (!posicaoPes)
            return;
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(posicaoPes.position, distanciaDoChao);
    }
}
