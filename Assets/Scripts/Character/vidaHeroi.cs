
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class vidaHeroi : MonoBehaviour
{
    [Header("VIDA")]
    public int vidaAtual = 100;
    private int vidaMaxima = 100;
    public Image vidaBarraIMG;
    [Header("ENERGIA")]
    public int energiaAtual = 500;
    private int energiaMaxima = 500;
    public Image energiaBarraIMG;

    float tempo = 5;
    
    [Header("ANIMACAO")]
    public Animator animator;
    void Start()
    {
        vidaAtual = 100;
        vidaMaxima = 100;

        energiaAtual = 500;
        energiaMaxima = 500;
        

        animator = GetComponent<Animator>();

       
    }
    void Update()
    {
        if (tempo > 0)
        {
            tempo -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(energiaCoutinar());
            tempo = 5;
        }
    } 

    IEnumerator energiaCoutinar()
    {
        yield return new WaitForSeconds(2);
        perderEnergia(10);
    }

    void sofrerDano(int dano)
    {
        if (vidaAtual > 0)
        {
            this.vidaAtual -= dano;
            vidaBarraIMG.fillAmount = (float)vidaAtual / vidaMaxima;
        }
        if (vidaAtual==0 || vidaAtual < 0 )
        {
            animator.SetBool("morreu", true);
            SceneManager.LoadScene("RestateFase1");

        }
    }
    void ganharVida(int valor)
    {
        if((valor + vidaAtual)>vidaMaxima)
        {
            vidaAtual = vidaMaxima;
            vidaBarraIMG.fillAmount = (float)vidaAtual / vidaMaxima;
        }
        else
        {
            vidaAtual += valor;
            vidaBarraIMG.fillAmount = (float)vidaAtual / vidaMaxima;
        }
    }
    void ganharEnergia(int valor)
    {
        if ((valor + energiaAtual) > energiaMaxima)
        {
            energiaAtual = energiaMaxima;
            energiaBarraIMG.fillAmount = (float)energiaAtual / energiaMaxima;
        }
        else
        {
            energiaAtual += valor;
            energiaBarraIMG.fillAmount = (float)energiaAtual / energiaMaxima;
        }
    }
    void perderEnergia(int valor)
    {
        if (energiaAtual >= 0)
        {
            this.energiaAtual -= valor;
            energiaBarraIMG.fillAmount = (float) energiaAtual / energiaMaxima;
        }

        if(energiaAtual == 0 || energiaAtual < 0)
        {
            animator.SetBool("morreu", true);
            SceneManager.LoadScene("RestateFase1");
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.name.Equals("PlataformaMoveRight"))
        {
            this.transform.parent = collision.transform;

        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            int dano = 1;//collision.gameObject.GetComponent<MeuDanoInimigo>().MEUDANO;
            sofrerDano(dano);

        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            int dano = 1;//collision.gameObject.GetComponent<MeuDanoInimigo>().MEUDANO;
            sofrerDano(dano);
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("capsulaVida"))
        {
            ganharVida(10);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("capsulaEnergia"))
        {
            ganharEnergia(10);
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name.Equals("PlataformaMoveRight"))
        {
            this.transform.parent = null;

        }
    }
}
