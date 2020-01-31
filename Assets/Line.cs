using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed;

    public LineRenderer lineRenderer;

    public float doubleChance;
    public float destructChance;

    private bool isDouble;
    private bool isDestructable;

    // Start is called before the first frame update
    void Start()
    {
        if(doubleChance == Random.Range(0,doubleChance)){
            isDouble = true;
            lineRenderer.SetPosition(0,new Vector3(-3,0,1));
            lineRenderer.SetPosition(1,new Vector3(3,0,1));
            rb.position = new Vector2(Random.Range(-4.5f, 4.5f), 5f);
        }
        else{
            isDouble = false;
            rb.position = new Vector2(Random.Range(-6f, 6f), 5f);
        }
        if(destructChance == Random.Range(0,destructChance)){
            isDestructable=true;
            lineRenderer.startColor= Color.cyan;
            lineRenderer.endColor= Color.cyan;
        }
        else{isDestructable = false;}
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(0, speed);
        if(rb.position.y < -5)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(isDestructable){
            Destroy(gameObject);
        }
    }
}
