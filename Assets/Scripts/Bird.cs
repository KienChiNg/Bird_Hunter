using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float minSpeedY;
    public float maxSpeedY;
    public float speed;
    bool checkLeft;
    public GameObject blood;

    Rigidbody2D m_rb;
    
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        randomMovingDicrection();
        flip();
    }
    

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = checkLeft
        ? new Vector2(speed,Random.Range(minSpeedY,maxSpeedY))
        : new Vector2(-speed,Random.Range(minSpeedY,maxSpeedY));
    }
    
    public void randomMovingDicrection(){
        if (transform.position.x < 0){
            checkLeft = true;
        }
        else checkLeft = false;
    }
    public void flip(){
        if (transform.position.x < 0){
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }
        else 
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
    }
    public void die(){
        Destroy(gameObject);
        // Instantiate(blood,transform.position,Quaternion.identity);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("DeathZone")){
            Destroy(gameObject);
        }
    }
}
