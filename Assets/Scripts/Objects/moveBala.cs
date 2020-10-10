
using UnityEngine;

public class moveBala : MonoBehaviour
{
    private float vel = 15.5f;
    public bool direcaoDireita;
    public float Vel
    {
        get { return vel; }
        set { vel = value; }
    }
    void Start()
    {
        
    }

    void Update()
    {
        Move();
    }

   
    void Move()
    {
        Vector3 aux = transform.position;
        aux.x += vel * Time.deltaTime;
        transform.position = aux;

        Destroy(this.gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("inimigo"))
        {
            Destroy(this.gameObject);
        }
    }
}
