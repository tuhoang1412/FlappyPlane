using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlaneScript : MonoBehaviour
{
    public GameObject mainCamera;
    public Rigidbody2D planeBody;

    private int pushStrength;
    private bool alive;
    private LogicHandler logicHandler;

    // Start is called before the first frame update
    void Start()
    {
        logicHandler = mainCamera.GetComponent<LogicHandler>();
        pushStrength = 6;
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (alive && Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            // Debug.Log("Push");
            planeBody.velocity = Vector2.up * pushStrength;
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (alive && other.gameObject.CompareTag("Star"))
        {
            // Debug.Log("Called Add score");
            logicHandler.UpdateScore(1);
        }
        else if (alive && other.gameObject.CompareTag("StarIce"))
        {

            // Debug.Log("Called Add score");
            logicHandler.UpdateScore(5);
        }
        Destroy(other.gameObject);
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if (alive && other.gameObject.CompareTag("Rock"))
        {
            alive = false;
            Invoke("DisplayGameOver", 0.2f);
        }
    }

    void DisplayGameOver()
    {
        logicHandler.GameOver();
    }
}
