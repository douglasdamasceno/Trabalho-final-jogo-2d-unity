using UnityEngine;
using UnityEngine.SceneManagement;
public class RecarregarFase1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadGame()
    {
        SceneManager.LoadScene("Fase1");
    }
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene("MenuInicial");
    }
}
