using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Block : MonoBehaviour
{
    [SerializeField] int points = 100;
    [SerializeField] AudioSource audioSourcePoints;
    [SerializeField] AudioSource audioSourceHit;
    [SerializeField] Score scoreObj;

    Rigidbody rb;
    bool destroyed = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (rb.velocity.magnitude > 2 || rb.angularVelocity.magnitude > 2)
        {
            audioSourceHit.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!destroyed && other.CompareTag("Kill") && rb.velocity.magnitude == 0 && rb.angularVelocity.magnitude == 0)
        {
            scoreObj.score += points;
            print(points);
            audioSourcePoints.Play();
            Destroy(gameObject, 2);
            destroyed = true;
        }
    }
}
