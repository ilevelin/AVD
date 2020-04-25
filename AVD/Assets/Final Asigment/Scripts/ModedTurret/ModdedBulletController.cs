using CreatorKitCode;
using CreatorKitCodeInternal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedBulletController : MonoBehaviour
{
    public LayerMask groundMask, enemyMask;

    private void OnCollisionEnter(Collision collision) {
        if(groundMask == (groundMask | (1 << collision.gameObject.layer)))
        {
            Destroy(gameObject);
        }
        if (enemyMask == (enemyMask | (1 << collision.gameObject.layer)))
        {
            collision.gameObject.GetComponent<SimpleEnemyController>().m_CharacterData.Stats.ChangeHealth(-1);
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
