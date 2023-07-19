using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallDown : MonoBehaviour
{
    Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
   
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player"))
            StartCoroutine("Down");
    }
    
    IEnumerator Down()
    {
        yield return new WaitForSeconds(0.6f);
        rb.GetComponent<Rigidbody>().isKinematic = false;
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
