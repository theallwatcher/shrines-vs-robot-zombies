using UnityEngine;

public class levelCounter : MonoBehaviour
{
    public static levelCounter Instance { get; private set; }
    public int level = 0;

    private void Awake(){

        if (Instance != null && Instance != this){

            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void LevelWin() { 
    
        level++;
    }
}
