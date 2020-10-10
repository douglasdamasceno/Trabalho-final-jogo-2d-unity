using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentacaoPartular : MonoBehaviour
{

    private float velMove = 2f;
    private Rigidbody2D rbZombie;
    private bool moveDireita;
    [SerializeField]
    private Transform limite;
    // Start is called before the first frame update
    void Start()
    {
        rbZombie = GetComponent<Rigidbody2D>();
        moveDireita = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveDireita)
        {
            rbZombie.velocity = new Vector2(velMove, rbZombie.velocity.y);
        }
        else
        {
            rbZombie.velocity = new Vector2(-velMove, rbZombie.velocity.y);
        }

        verificaColisao();
    }
    void verificaColisao()
    {
        if (!Physics2D.Raycast(limite.position,Vector2.down,0.1f))
        {
            flip();
        }
    }
    void flip()
    {
        moveDireita = !moveDireita;
        Vector3 temp = transform.localScale;
        if (moveDireita)
        {
            temp.x = Mathf.Abs(temp.x);

        }
        else
        {
            temp.x = -Mathf.Abs(temp.x);
        }
        transform.localScale = temp;
    
    }
}
