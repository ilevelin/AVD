using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBallController : MonoBehaviour
{
    public LayerMask mask;
    public GameObject turret;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {

        if (mask == (mask | (1 << collision.gameObject.layer))) {
            Instantiate(turret, transform.position, transform.rotation, transform.parent);
        }

        Destroy(gameObject);

    }
}
