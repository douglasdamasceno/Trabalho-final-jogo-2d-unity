
using UnityEngine;

public class ControllerVida : MonoBehaviour 
{
    private Animator animator;
    [Header("Vida")]
    private int vida;
    public Transform healthBar; //barra verde
    public GameObject healthBarObject; // objeto pai

    private Vector3 healthBarScale; //tamanho da barra
    private float healthPercent;  // Percentual da vida para o calculo o tamanho da barra
    private bool morto;


    public GameObject particulaSangue; // objeto pai
    void Start()
    {
        animator = GetComponent<Animator>();
        this.vida = 100;
        healthBarScale = healthBar.localScale;
        healthPercent = healthBarScale.x / vida;
    }


    void updateBarraDeVida()
    {
        healthBarScale.x = healthPercent * vida;
        healthBar.localScale = healthBarScale;

    }

    public void tomarDano(int dano)
    {
        this.vida -= dano;
       
        if (this.vida<= 0)
        {
            this.vida = 0;
            animator.SetBool("atacar", false);
            animator.SetBool("morrer", true);
            Destroy(this.gameObject,0.5f);
        }
       
        updateBarraDeVida();
        
    }
    void Update()
    {
      
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("atacar", true);
        }
        if (collision.gameObject.CompareTag("bala"))
        {
            Destroy(Instantiate(particulaSangue, collision.gameObject.transform.position, collision.gameObject.transform.rotation),2);
            tomarDano(25);
        }


    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            animator.SetBool("atacar", false);
           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
    }


}
