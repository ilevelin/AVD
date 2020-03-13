using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject turretBall;
    [Min(0.1f)] public float ballSpeed;
    public GameObject summonedTurret;
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.P) && transform.childCount == 0){ 
            GameObject tmp = Instantiate(turretBall, transform.position, new Quaternion(0.0f, transform.rotation.y, 0.0f, 0.0f), transform);
            tmp.GetComponent<Rigidbody>().AddRelativeForce(0.0f, 0.0f, ballSpeed);
        }
    }
}
