/* Filename: SpiderController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Modified: Sep 10, 2019
 * This script is responsible for the Spider game object controller. 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class SpiderController : MonoBehaviour
{
    [SerializeField]
    public Boundary boundary;

    public float horizontalSpeed = 0.03f; // Represents a float for a horizontal speed
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
    /// Resets gameObject position
    /// </summary>
    void Reset()
    {
        float randomXPosition = Random.Range(boundary.LeftBounds, boundary.RightBounds);

        transform.position = new Vector2(randomXPosition, boundary.StartBounds);
    }
    /// <summary>
    /// This method is used to check if this object has reached a position where it needs to be reset.
    /// If so then this object's position will be reset
    void CheckBounds()
    {
        if (transform.position.x <= boundary.EndBounds)
        {
            Reset();
        }
    }
    /// <summary>
    /// This method is used to move the object that has this script attached to it
    /// </summary>
    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(horizontalSpeed, 0.0f);
        transform.position = currentPosition;
    }
}
