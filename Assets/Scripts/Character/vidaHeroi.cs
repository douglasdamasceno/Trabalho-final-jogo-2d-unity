
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class vidaHeroi : MonoBehaviour
{
    public int vidaAtual = 100;
    private int vidaMaxima = 100;
    public Image vidaBar;

    public Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
       
    }

    void sofrerDano(int dano)
    {
        if (vidaAtual > 0)
        {
            this.vidaAtual -= dano;
            vidaBar.fillAmount = (float)vidaAtual / 100;
            Debug.Log("tumou dano itoru");
        }
        if (vidaAtual==0 || vidaAtual < 0)
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
        }
        else
        {
            vidaAtual += valor;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            sofrerDano(10);
            
        }
    }
}
