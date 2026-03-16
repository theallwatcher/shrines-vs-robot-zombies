using UnityEngine;
using UnityEngine.InputSystem;

public class pauzer : MonoBehaviour
{
    public int t = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {

            if (t == 0)
            {

                Cursor.lockState = CursorLockMode.Locked;
                t = 1;
            }
            else if (t == 1)
            {

                Cursor.lockState = CursorLockMode.None;
                t = 0;
            }

        }
    }
}
