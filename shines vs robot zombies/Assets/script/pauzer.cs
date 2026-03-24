using UnityEngine;
using UnityEngine.InputSystem;

public class pauzer : MonoBehaviour
{
    public int t = 1;
    [SerializeField] GameObject pauseScreen;
    inventory inventory;
    player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        inventory = FindFirstObjectByType<inventory>();
        player = FindFirstObjectByType<player>();
    }

    // Update is called once per frame
    void Update(){

        if (Keyboard.current.pKey.wasPressedThisFrame){

            if (t == 0){

                //play
                inventory.paused = false;
                player.paused = false;
                Time.timeScale = 1;
                pauseScreen.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                t = 1;
            }
            else if (t == 1){

                //pause
                inventory.paused=true;
                player.paused = true;
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                t = 0;
            }

        }
    }
}
