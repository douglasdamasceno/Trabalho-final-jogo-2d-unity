using UnityEngine;
using UnityEngine.UI;

public class PauseGame : MonoBehaviour
{
    public Text txtPause;
    public bool PAUSADO;

    private void Start()
    {
        txtPause.enabled = false;
        PAUSADO = false;
    }
    public void Pause()
    {
        if (Time.timeScale ==1)
        {
            Time.timeScale = 0;
            txtPause.enabled = true;
            PAUSADO = true;
        }
        else
        {
            Time.timeScale = 1;
            txtPause.enabled = false;
            PAUSADO = false;
        }
    }
}
