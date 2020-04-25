using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModdedPlayerController : MonoBehaviour
{
    public GameObject turret;
    private int cooldown = 0;

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P) && cooldown == 0)
        {
            if (GameObject.FindGameObjectWithTag("ModdedManager").GetComponent<ModController>().UseCharge())
            {
                GameObject tmp = Instantiate(turret,
                    new Vector3(transform.position.x, transform.position.y + .75f, transform.position.z),
                    new Quaternion(0.0f, transform.rotation.y, 0.0f, 0.0f));
                cooldown = 30;
            }
        }
        else cooldown = Mathf.Max(cooldown - 1, 0);
    }
}
