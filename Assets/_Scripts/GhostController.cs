/* Filename: GhostController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Modified: Sep 10, 2019
 * This script is responsible for the Ghost game object controller. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class GhostController : MonoBehaviour
{
    public GameController gameController;
    public GameObject fire; // Represents a GameObject to store a reference for a fire object 
    public GameObject death; // Represents a GameObject to store a reference for a death object(death animation)
    public float nextFire; 
    public float fireRate = 2.0f;
    public float horizontalSpeed = 0.02f; // Represents a float for a horizontal speed
    public float leftBoundary = 0.0f; // Represents a left boundary for an object
    public float topBoundary = 0.2f; // Represents a top boundary for an object(indicates y position)
    public AudioSource gotHitByFire;
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Fire();
    }
    /// <summary>
    /// Resets gameObject position
    /// </summary>
    private void Reset()
    {
        float randomXPosition = Random.Range(2.0f, 5.0f);
        transform.position = new Vector2(randomXPosition, 0.2f);
    }
    /// <summary>
    /// This method is used to move the object that has this script attached to it
    /// </summary>
    private void Move()
    {
        if(transform.position.x > 0.2)
        {
            Vector2 currentPosition = transform.position;
            currentPosition -= new Vector2(horizontalSpeed, 0.0f);
            transform.position = currentPosition;
        }
    }
    /// <summary>
    /// This method generates a fire object that can hurt a player.
    /// </summary>
    private void Fire()
    {
        if (Time.time > nextFire && transform.position.x < 0.5f)
        {
            nextFire = Time.time + fireRate;
            Instantiate(fire, transform.position + new Vector3(-0.2f, 0.0f), transform.rotation);
        }
    }
    /// <summary>
    /// This method is checking if this object collides with object that has "Fire" tag. If it does then 
    /// this object will be reset and the 10 points will be added to a score
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Instantiate(death, transform.position, transform.rotation);
            Destroy(GameObject.FindGameObjectWithTag("Enemy_Death"), 0.4f);
            gotHitByFire.Play();
            Reset();
            Destroy(collision.gameObject);
            gameController.Score += 10;
        }
    }
}
