using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour
{

    [SerializeField] private Transform respawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<Rigidbody2D>().velocity.Set(0, 0);
        collision.gameObject.transform.position.Set(respawnPoint.position.x, respawnPoint.position.y, respawnPoint.position.z);
    }
}
