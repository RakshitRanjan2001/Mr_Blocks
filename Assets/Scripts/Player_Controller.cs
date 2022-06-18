using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public GameObject GameWonPanel;
    public GameObject GamePausedPanel;
    public GameObject GameLostPanel;
    public float speed;

    private bool isGameOver;
    private bool isGamePaused= false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)){
            if(isGamePaused==true){
                isGamePaused = false;
            }
            else{
                isGamePaused = true;
            }
            GamePausedPanel.SetActive(isGamePaused);
            Debug.Log("Game Paused");
        }
        
        if (isGameOver==true || isGamePaused==true){
            return;
        }

        if (Input.GetAxis("Horizontal") > 0) // it is positive
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        else if (Input.GetAxis("Horizontal") < 0) // it is negative
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        else if (Input.GetAxis("Vertical") > 0) // it is positive
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        else if (Input.GetAxis("Vertical") < 0) // it is negative
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if (Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal") == 0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
            //stop
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Door")
        {
            Debug.Log("Level Completed!!");
            GameWonPanel.SetActive(true);
            isGameOver = true;
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else if (other.tag == "Enemy")
        {
            Debug.Log("Level Lost");
            GameLostPanel.SetActive(true);
            isGameOver = true;
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        else if (other.tag == "Wall")
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
    }

    public void RestartGame(int sce){
        SceneManager.LoadScene(sce);
        Debug.Log("Restart Level");
    }
}
