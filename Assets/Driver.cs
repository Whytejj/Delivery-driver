using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 300f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 20f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] Color32 hasBoostColor = new Color32 (1, 1, 1, 1);

    SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount); 
        transform.Translate(0,moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other) {

        if(other.tag == "Boost"){
            Debug.Log("Boost");
            moveSpeed = boostSpeed;
            spriteRenderer.color = hasBoostColor;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
