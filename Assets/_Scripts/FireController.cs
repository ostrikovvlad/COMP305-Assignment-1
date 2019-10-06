/* Filename: FireController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Last modified: Oct 2, 2019
 * This script is used to manage a behaviour for a Fire object. This script manages the speed of a fire
 * object and also a position at which this object will be destroyed.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class FireController : MonoBehaviour
{
    public float horizontalSpeed = 0.2f;
    public float verticalSpeed;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckBounds();
    }
    /// <summary>
    /// This method is used to move an object to which this script is attached. Movement of an object
    /// is based on the horizontal and vertical speed that can be set in the object settings.
    /// </summary>
    public void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition += new Vector2(horizontalSpeed, verticalSpeed);
        transform.position = currentPosition;
    }
    /// <summary>
    /// This method is used to check if the object that has this script attached to it is not entering 
    /// an area where this object shouldn't be. In this case object will be destroyed each time it 
    /// reaches 1.45 at x axis.
    /// </summary>
    public void CheckBounds()
    {
        if(this.transform.position.x >= 1.45f || this.transform.position.y <= -0.6f)
        {
            Destroy(this.gameObject);
        }
    }
}
