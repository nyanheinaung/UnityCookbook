using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveProp : MonoBehaviour
{
    public Transform targetBone;
    public GameObject prop;

    private void OnTriggerEnter(Collider collision)
    {
        if (targetBone.IsChildOf(collision.transform))
        {
            foreach(Transform child in targetBone)
            {
                if(child.name == prop.name)
                {
                    Destroy(child.gameObject);
                }
            }
        }
    }




}
