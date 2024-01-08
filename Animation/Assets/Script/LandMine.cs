using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMine : MonoBehaviour
{
    public float range = 2f;
    public float force = 2f;
    public float up = 4f;
    private bool active = true;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player" && active)
        {
            active = false;
            StartCoroutine(Reactivate());

            collision.gameObject.GetComponent<RagdollCharacter>().ActivateRagdoll();

            Vector3 explosionPos = transform.position;
            
            Collider[] colliders = Physics.OverlapSphere(explosionPos, range);



            foreach (Collider hit in colliders)
            {
                if (hit.GetComponent<Rigidbody>())
                {
                    hit.GetComponent<Rigidbody>().AddExplosionForce(force, explosionPos, range, up);
                }
            }           
        }
    }

    IEnumerator Reactivate()
    {
        yield return new WaitForSeconds(2);
        active = true;
       
    }

}
