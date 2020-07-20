using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public LayerMask clickable;

    private NavMeshAgent playerAgent;
    private NavMeshPath playerPath;
    private LineRenderer meshLine;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        meshLine = GetComponent<LineRenderer>();

        playerPath = new NavMeshPath();
    }

    void Update()
    {
        MovePlayer();
        ShowPath();
    }

    void MovePlayer()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(mouseRay, out hit, 100, clickable))
        {
            if (hit.collider.gameObject.layer == 8)
            {
                NavMesh.CalculatePath(transform.position, hit.point, NavMesh.AllAreas, playerPath);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            playerAgent.SetDestination(hit.point);
        }
    }

    void ShowPath()
    {
        meshLine.positionCount = playerPath.corners.Length;
        meshLine.SetPositions(playerPath.corners);
    }
}
