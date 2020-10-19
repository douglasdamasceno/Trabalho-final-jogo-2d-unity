using System.Collections;
using UnityEngine;

public class SeguirPlayer : MonoBehaviour
{
    private float velMove = 5f;
    private Rigidbody2D rbZombie;
    private bool moveE;
    [SerializeField]
    private Transform[] limite;

    [SerializeField]
    private bool visaoV;
    [SerializeField]
    float raio;
    [SerializeField]
    private LayerMask layerV;
    [SerializeField]
    private SpriteRenderer srender;
    private bool chamado = true;
    private WaitForSeconds tempo = new WaitForSeconds(2);

    void Start()
    {
        rbZombie = GetComponent<Rigidbody2D>();
        srender = GetComponent<SpriteRenderer>();
        moveE = false;
    }

    void Update()
    {
        visaoV = Physics2D.OverlapCircle(transform.position, raio, layerV);
        if (visaoV)
        {
            var relativeP = transform.InverseTransformPoint(Physics2D.OverlapCircle(transform.position, raio, layerV).gameObject.transform.position);

            if (relativeP.x < 0.0f)
            {
                srender.flipX = true;
                moveE = false;
            }
            else if (relativeP.x > 0.0f)
            {

                srender.flipX = false;
                moveE = true;
            }
        }



        if (moveE)
        {
            rbZombie.velocity = new Vector2(velMove, rbZombie.velocity.y);
        }
        else
        {
            rbZombie.velocity = new Vector2(-velMove, rbZombie.velocity.y);
        }

        verificaColisao();


    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, raio);
    }

    void verificaColisao()
    {
        if (!Physics2D.Raycast(limite[0].position, Vector2.down, 0.1f) && chamado
            || !Physics2D.Raycast(limite[1].position, Vector2.down, 0.1f) && chamado
            )
        {
            StartCoroutine(ChamarFlip());
        }
    }
    IEnumerator ChamarFlip()
    {
        flip();
        chamado = false;
        yield return tempo;
        chamado = true;
    }
    void flip()
    {
        moveE = !moveE;
        if (moveE)
        {
            srender.flipX = false;

        }
        else
        {

            srender.flipX = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("inimigo");

            foreach (GameObject obj in otherObjects)
            {
                Physics2D.IgnoreCollision(obj.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            }

        }
    }
   
}