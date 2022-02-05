using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{ 
    [SerializeField] Color32 hasPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 noPackageColor = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 wrongCollisionColor = new Color32 (1, 1, 1, 1);
    [SerializeField] float destroyDelay = 0.5f;
    bool hasPackage;
    SpriteRenderer spriteRenderer;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other) {
        Debug.Log("ouch");
        spriteRenderer.color = wrongCollisionColor;
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        //car collided with package and doesnt already have a package. destroy the collided object "Package" 
        if (other.tag == "Package" && !hasPackage)
        {
            Debug.Log("package recieved");
            hasPackage = true;
            spriteRenderer.color = hasPackageColor;
            Destroy(other.gameObject, destroyDelay);
        }
        //car collided with customer and already has a package. 
        if (other.tag == "Customer" && hasPackage)
        {
            Debug.Log("package delivered");
            spriteRenderer.color = noPackageColor;
            hasPackage = false;
        }
    }
}
