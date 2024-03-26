using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsCollider : MonoBehaviour
{
    string status;

    private void OnCollisionEnter(Collision collision)
    {
        status = "collision enter: " + collision.gameObject.name;
    }

    private void OnCollisionStay(Collision collision)
    {
        status = "collision stay: " + collision.gameObject.name;
    }

    private void OnCollisionExit(Collision collision)
    {
        status = "collision exit: " + collision.gameObject.name;
    }

    private void OnTriggerEnter(Collider other)
    {
        status = "trigger enter: " + other.gameObject.name;
    }

    private void OnTriggerStay(Collider other)
    {
        status = "trigger stay: " + other.gameObject.name;
    }

    private void OnTriggerExit(Collider other)
    {
        status = "trigger exit: " + other.gameObject.name;
    }

    private void OnGUI()
    {
        GUI.skin.label.fontSize = 16;
        
        Vector2 screen = Camera.main.WorldToScreenPoint(transform.position);

        GUI.Label(new Rect(screen.x, Screen.height - screen.y, 250, 70), status);
    }
}
