using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public LayerMask mask;

    private void OnCollisionEnter(Collision collision) {

        if(mask == (mask | (1 << collision.gameObject.layer))){

            Destroy(gameObject);

        }

    }
    private void Start(){
        StartCoroutine(limiter());
    }

    private void OnDisable(){
        StopAllCoroutines();
    }
    IEnumerator limiter() {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        yield return null;
    }
}
