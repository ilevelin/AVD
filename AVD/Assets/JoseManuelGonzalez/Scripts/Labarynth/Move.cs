using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveType{
    objective, pointAndClick
}

[RequireComponent(typeof(UnityEngine.AI.NavMeshAgent)), RequireComponent(typeof(Animator))]
public class Move : MonoBehaviour
{

    private UnityEngine.AI.NavMeshAgent agent;
    private Animator animator;
    private RaycastHit hitInfo;
    public GameObject objective;
    public GameObject pointAndClickObjective;
    public MoveType movementType;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(movementType){
            case MoveType.objective:
                agent.destination = objective.transform.position;
                break;
            case MoveType.pointAndClick:
                if(Input.GetMouseButtonDown(0)){
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
                        agent.destination = hitInfo.point;
                        pointAndClickObjective.transform.position = new Vector3(hitInfo.point.x, hitInfo.point.y + 0.01f, hitInfo.point.z);
                }
                break;

        }
    }
}
