using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.SceneManagement;

public class NavegacaoTelas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void navegarParaFase1()
    {
        SceneManager.LoadScene("Fase1");
    }

    public void navegarParaCreditos()
    {
        SceneManager.LoadScene("Creditos");
    }
}
