using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ClickMeToSetDestination : MonoBehaviour
{
    private NavMeshAgent playerNavMeshAgent;
    private MeshRenderer meshRenderer;
    private bool mouseOver = false;

    private Color unselectedColor;


    // Start is called before the first frame update
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        unselectedColor = meshRenderer.sharedMaterial.color;

        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");
        playerNavMeshAgent = playerGO.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && mouseOver)
        {
            playerNavMeshAgent.SetDestination(transform.position);
        }
    }

    private void OnMouseOver()
    {
        mouseOver = true;
        meshRenderer.sharedMaterial.color = Color.yellow;
    }

    private void OnMouseExit()
    {
        mouseOver = false;
        meshRenderer.sharedMaterial.color = unselectedColor;
    }
}
