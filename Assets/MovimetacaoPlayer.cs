using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimetacaoPlayer : MonoBehaviour
{
    [Header("MOVIMENTO")]
    Rigidbody2D rbPlayer;
    float velocidade;
    float direcao;
    [Header("PULO")]
    float forcaPulo;
    bool estaNoChao;
    public LayerMask layerChao;
    public Transform posicaoPE;
    int puloDuplo = 2;
    [Header("ANIMACAO")]
    private Animator animator;
    private bool paraDireita;
    Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        velocidade = 5f;
        forcaPulo = 15f;
        paraDireita = true;
        puloDuplo = 2;
        rbPlayer = GetComponent<Rigidbody2D>();

        animator = GetComponent<Animator>();
        playerTransform = GetComponent<Transform>();
    }
    
    void Update()
    {
        estaNoChao = Physics2D.OverlapCircle(posicaoPE.position, 0.3f,layerChao);

        direcao = Input.GetAxisRaw("Horizontal");
        if (direcao != 0)
        {
            if (direcao < 0 && paraDireita)
            {
                flip();
            }
            else if (direcao > 0 && !paraDireita) {
                flip();
            
            }
            rbPlayer.velocity = new Vector2(direcao * velocidade, rbPlayer.velocity.y);

            animator.SetBool("correndo", true);
            animator.SetBool("parado", false);
            animator.SetBool("atirando", false);
        }
        else
        {
            animator.SetBool("correndo", false);
            animator.SetBool("parado", true);
        }

        if (estaNoChao)
        {
            puloDuplo = 2;
        }
        if (Input.GetKeyDown(KeyCode.Space) && puloDuplo>1)//&& estaNoChao)
        {
            puloDuplo--;
            rbPlayer.velocity = Vector2.up * forcaPulo;
            animator.SetBool("pulando", true);
            print("pulando");
        }
        else
        {
            animator.SetBool("pulando", false);
        }

    }



    void flip()
    {
        paraDireita = !paraDireita;
        Vector3 scala = playerTransform.localScale;
        scala.x *= -1;
        playerTransform.localScale = scala;
    }
}
