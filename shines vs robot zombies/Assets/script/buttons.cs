using UnityEngine;
using UnityEngine.SceneManagement;

public class buttons : MonoBehaviour
{
    public void startLevel1(){

        //Laad het huidige level in met de SceneManager.
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void startLevel2()
    {

        //Laad het huidige level in met de SceneManager.
        SceneManager.LoadScene("main");
        Time.timeScale = 1;
    }

    public void menu(){

        //Laad het huidige level in met de SceneManager.
        SceneManager.LoadScene("startScene");
        Time.timeScale = 1;
    }

    public void quit() {

        Application.Quit();
        Debug.Log("quit");
    
    }
}
