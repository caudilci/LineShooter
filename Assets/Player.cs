using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public KeyCode right;
    public KeyCode left;

    public KeyCode fireButton;

    //PLayer projectile fire rate
    public float fireRate = 1f;

    public GameObject projectilePrefab;

    //Player Move Speed
    public float moveSpeed = 600f;

    //Rigid body of Player
    public Rigidbody2D rb;

    //Move direction
    float move = 0;

    private float nextTimeToFire = 0f;

    // Update is called once per frame
    void Update()
    {
        //Directional Input
        if(Input.GetKey(right)){
            move = 1;
            Debug.Log("right");
        }
        else if (Input.GetKey(left)){
            move = -1;
            Debug.Log("Left");
        }
        else {
            move = 0;
        }

        //Projectile
        if(Input.GetKey(fireButton)){
            if(Time.time >= nextTimeToFire){
                Instantiate(projectilePrefab, new Vector2(rb.position.x, rb.position.y+0.5f), Quaternion.identity);
                nextTimeToFire = Time.time + 1f/fireRate;
            }
        }

        //Screenwrap
        if(rb.position.x > 7.5f){
            transform.position = new Vector2(-7.5f, -4);
        }
        else if(rb.position.x<-7.5f){
            transform.position = new Vector2(7.5f, -4);
        }
    }

    void FixedUpdate(){
        rb.velocity= new Vector2(move*moveSpeed, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
