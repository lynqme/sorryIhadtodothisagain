using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity =1f;
    private Vector3 direction;
    public float gravity = -9.8f;
    public float strength = 5f;
    private Rigidbody2D rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();    
    }

    private void OnEnable(){
        Vector3 position = transform.position;
        position.y = 0f;
        transform.position = position;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)){
            rb.velocity = Vector2.up * velocity;
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Obstacle"){
            FindObjectOfType<GameManager>().GameOver();
        } else if(other.gameObject.tag == "Scoring"){
            FindObjectOfType<GameManager>().IncreaseScore();
        }
        //direction.y += gravity + Time.deltaTime;
       // transform.position += direction + Time.deltaTime;
    }
}
