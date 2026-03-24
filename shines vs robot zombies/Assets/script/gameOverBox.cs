using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverBox : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "zombie") {

            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("gameOver");
        }
    }
}
