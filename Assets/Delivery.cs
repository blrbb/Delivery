using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);
    [SerializeField] Color32 hasPackageColor = new Color32(85,229,74,255);
    [SerializeField] float destroyDelay = .5f;
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;
    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("ouch! we crashed :(");
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Package" && hasPackage == false)
            {
            Debug.Log("Picked up package!");        
            hasPackage = true;
            Destroy(other.gameObject,destroyDelay);
            spriteRenderer.color = hasPackageColor;
            }

        if(other.tag == "Customer" && hasPackage == true)
        {
            Debug.Log("Dropped off package!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }
    }
}
