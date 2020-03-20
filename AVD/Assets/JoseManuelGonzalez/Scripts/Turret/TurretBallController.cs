using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBallController : MonoBehaviour
{
    public LayerMask mask;
    public GameObject turret;

    private void OnCollisionEnter(Collision collision) {

        if (mask == (mask | (1 << collision.gameObject.layer))) {
            Instantiate(turret, transform.position, transform.rotation, transform.parent);
        }

        Destroy(gameObject);

    }
}
