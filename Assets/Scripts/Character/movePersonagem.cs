
using UnityEngine;

public class movePersonagem : MonoBehaviour
{
    [Header("MOVIMENTAÇÃO")]
    float vel = 5.0f;
    float move = 0;
    [Header("ANIMAÇÃO")]
    private Animator animator;
    private bool paraDireita;
    public Transform playerTransform;
    int puloDuplo;


    [Header("SONS")]
    Rigidbody2D rbPlayer;
    float forca = 320f;
    
    public GameObject cano;
    [Header("SONS")]
    public AudioClip shoot;

    Quaternion canoRotation;
    [Header("Nova movimetcao")]
    bool noChao;
    public Transform groundCheck;

    public bool isPause;

    void Start()
    {
        isPause = false;
        animator = GetComponent<Animator>();
        rbPlayer = GetComponent<Rigidbody2D>();
        playerTransform = GetComponent<Transform>();
        puloDuplo = 2;
        paraDireita = true;
    }

    void Update()
    {

        noChao = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("chao"));

        move = Input.GetAxisRaw("Horizontal");

        transform.Translate(new Vector3(move * Time.deltaTime * vel, 0, 0));

        isPause = this.gameObject.GetComponent<PauseGame>().PAUSADO;
        if (!isPause)
        {


            if (move != 0)
            {
                if (move < 0 && paraDireita)
                {
                    flip();
                    transform.Translate(new Vector3(move * Time.deltaTime * vel * -1, 0, 0));
                }
                else if (move > 0 && !paraDireita)
                {
                    flip();
                    transform.Translate(new Vector3(move * Time.deltaTime * vel * -1, 0, 0));
                }

                animator.SetBool("correndo", true);
                animator.SetBool("parado", false);
                animator.SetBool("atirando", false);
            }
            else
            {
                animator.SetBool("correndo", false);
                animator.SetBool("parado", true);


            }


            if (puloDuplo > 0 || noChao)
            {

                Jump();

            }
        }
    }
   
    void flip()
    {
        paraDireita = !paraDireita;
        Vector3 scala = playerTransform.localScale;
        scala.x *= -1;
        playerTransform.localScale = scala;
    }
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
           animator.SetBool("pulando", true);
           rbPlayer.AddForce(new Vector2(0, forca * Time.deltaTime), ForceMode2D.Impulse);
           puloDuplo--;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("chao"))
        {

           animator.SetBool("pulando", false);
           puloDuplo = 2;
         
        }
    }
    
}
