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
    private Vector2 velocity = Vector2.zero, smoothDeltaPosition = Vector2.zero;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updatePosition = false;
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

        /*
        animator.SetFloat("XVel", agent.velocity.x);
        animator.SetFloat("YVel", agent.velocity.y);
        */

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        float dx = Vector3.Dot(transform.right, worldDeltaPosition);
        float dy = Vector3.Dot(transform.forward, worldDeltaPosition);
        Vector2 deltaPosition = new Vector2(dx, dy);

        // Low-pass filter the deltaMove
        float smooth = Mathf.Min(1.0f, Time.deltaTime / 0.15f);
        smoothDeltaPosition = Vector2.Lerp(smoothDeltaPosition, deltaPosition, smooth);

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

        bool shouldMove = velocity.magnitude > 0.5f && agent.remainingDistance > agent.radius;

        // Update animation parameters
        animator.SetBool("Walking", shouldMove);
        animator.SetFloat("XVel", velocity.x);
        animator.SetFloat("YVel", velocity.y);

    }
    void OnAnimatorMove()
    {
        // Update position to agent position
        transform.position = agent.nextPosition;
    }
}
