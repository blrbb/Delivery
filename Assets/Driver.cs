using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
[SerializeField] float steerSpeed = 1f;
[SerializeField] float defaultMoveSpeed = 30f;
[SerializeField] float moveSpeed = 30f;
[SerializeField] float slowSpeed = .5f;
[SerializeField] float boostSpeed = 1.5f;

    void Start()
    {
        moveSpeed = defaultMoveSpeed;
    }
    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;

        transform.Rotate(0,0,moveAmount >= 0 ? -steerAmount : steerAmount);
        transform.Translate(0,moveAmount,0);
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boost")
        {
            Debug.Log("BOOST!!");
            moveSpeed = defaultMoveSpeed * boostSpeed;
        }

    }
    private void OnCollisionEnter2D(Collision2D other) 
    {
            Debug.Log("SLOW!!");
            moveSpeed = defaultMoveSpeed * slowSpeed;
    }
}
