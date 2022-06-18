using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float espeed;
    public bool Ver_Hor;
    
    // Update is called once per frame
    void Update()
    {
        if (Ver_Hor==false){
            rigidbody2d.velocity = new Vector2(espeed, 0f);
        }
        else if (Ver_Hor==true){
            rigidbody2d.velocity = new Vector2(0f, espeed);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            espeed = -1*espeed;
        }
    }
}
