using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask clickable;

    private NavMeshAgent playerAgent;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown (0))
        {
            Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast (mouseRay, out hit, 100, clickable))
            {
                if (hit.collider.gameObject.layer == 8 )
                {
                    playerAgent.SetDestination(hit.point);
                }
            }
        }
    }
}
