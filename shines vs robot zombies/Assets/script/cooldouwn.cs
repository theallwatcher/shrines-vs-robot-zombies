using UnityEngine;
using UnityEngine.UI;


public class cooldouwn : MonoBehaviour
{
    [SerializeField] Image cooldown;
    [SerializeField] float cooldownTime;
    float cooldownMaxTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){

        cooldownMaxTime = cooldownTime;
    }

    // made whith help from this viedo:https://www.youtube.com/watch?v=POq1i8FyRyQ
    void Update(){

        if (cooldownTime > 0){

            cooldownTime -= Time.deltaTime;
        }
        else if (cooldownTime <= 0) { 

            Destroy(gameObject);
        }

        float newWidth = (float)cooldownTime / cooldownMaxTime;
        cooldown.fillAmount = newWidth;
    }
}
