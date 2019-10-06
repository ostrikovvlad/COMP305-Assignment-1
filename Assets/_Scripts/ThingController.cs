/* Filename: ThingController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Modified: Sep 10, 2019
 * This script is responsible for the Thing game object controller. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Util;
public class ThingController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary; // This object is used to manage boundaries for this object
    public AudioSource gotHitByFire; // Is used to store an audio file that will be played once this object gets hit
    public Animator animator;
    public GameObject death; // Is used to store a GameObject to use it when this object gets hit

    public GameController gameController;
    public float horizontalSpeed = 0.01f; // Represents a float for a horizontal speed of this object
    // Start is called before the first frame update
    void Start()
    {
        Reset();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    /// <summary>
    /// This method is used to reset a position of this object to a random position between left boundary
    /// and right boundary on x axis and on the start boundary on y axis
    /// </summary>
    void Reset()
    {
        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, boundary.StartBounds);
    }
    /// <summary>
    /// This method is used to check wheather this object passed a boundary where it is not allowed
    /// and then resets it position if so
    /// </summary>
    void CheckBounds()
    {
        if (transform.position.x <= boundary.EndBounds)
        {
            Reset();
        }
    }
    /// <summary>
    /// This method is used to move this object horizontally with the specified speed
    /// </summary>
    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(horizontalSpeed, 0.0f);
        transform.position = currentPosition;
    }
    /// <summary>
    /// This method is used to destroy Fire object, increase game score and reset this object's position
    /// if this object collides with a Fire object
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
