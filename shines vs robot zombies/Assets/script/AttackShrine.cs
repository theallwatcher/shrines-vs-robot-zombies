using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackShrine : MonoBehaviour
{

    bool isShooting = false;
    [SerializeField] GameObject bulletPre;
    [SerializeField] Transform firePoint;

    Coroutine lastRoutine = null;


    // Update is called once per frame
    void Update(){

        if (ZombieInLane() == true && isShooting == false){

            StartShooting();
        }
        else if (ZombieInLane() == false && isShooting == true) {

            StopShooting();
        }
    }

    public void StartShooting() {

        //fixed with help of this discusion https://discussions.unity.com/t/stopcoroutine-is-not-stopping-my-coroutines/134523
        lastRoutine = StartCoroutine(shooting());
        isShooting = true;
    }

    public void StopShooting() { 
    
        StopCoroutine(lastRoutine);
        isShooting=false;
    }

    IEnumerator shooting() { 
    
        yield return new WaitForSeconds(1.5f);
        GameObject bullet = Instantiate(bulletPre, firePoint.position, firePoint.rotation);
        lastRoutine = StartCoroutine(shooting());
    }

    bool ZombieInLane(){

        int layerMask = ~LayerMask.GetMask("shrine", "bullet", "Default");
        RaycastHit _hit;

        if (Physics.Raycast(transform.position, transform.forward, out _hit, 27f,layerMask)){

            if (_hit.transform.tag == "zombie"){

                return true;
            }
        }
        return false;
    }
}
