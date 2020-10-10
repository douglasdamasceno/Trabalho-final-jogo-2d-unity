
using UnityEngine;

public class dispararBalas : MonoBehaviour
{
    public GameObject balas;
    public GameObject cano;
    [Header("SONS")]
    public AudioClip shoot;
    
    private Animator animator;


    void Start()
    {
        animator = GetComponent<Animator>();
        //Quaternion canoRotation;
    }
        void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           // canoRotation = cano.transform.rotation;

           // Vector3 rotacao = canoRotation.eulerAngles;
            //rotacao.y *= -1;
            //canoRotation.eulerAngles = rotacao;
            //cano.transform.rotation = canoRotation;

            GameObject balaInstanciada = Instantiate(balas, cano.transform.position, Quaternion.identity) as GameObject;
            balaInstanciada.GetComponent<moveBala>().Vel *= transform.localScale.x;
            GetComponent<AudioSource>().PlayOneShot(shoot);

            animator.SetBool("atirando", true);
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            animator.SetBool("atirando", false);
        }
    }
}
