/* Filename: ForestController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Last modified: Oct 2, 2019
 * This script is used on the Forest object to move it left and then return it back to right
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestController : MonoBehaviour
{
    //PUBLIC variables
    public float horizontalSpeed = 0.02f; // Represents a variable to store float horizontal speed
    public bool resetToLeftPosition = false; // Represents a boolean to determine if this object needs
    // to be reset to a left position
    //PRIVATE variables
    private float m_leftPositionReset = -0.3f; // Is float number representing left reset position of this object
    private float m_rightPositionReset = 2.36f; // Is float number representing right reset position of this object
    private bool m_isFirstRun = true; // Boolean to check if it is a first run of this script
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
    /// This method is used to reset a position of this object. Reset position differs if it a first run
    /// of this script
    /// </summary>
    void Reset()
    {
        Vector2 resetPosition = new Vector2(0.0f, 0.0f);
        if (m_isFirstRun)
        {
            resetPosition.x = (resetToLeftPosition) ? m_leftPositionReset : 1.78f;
            transform.position = resetPosition;
            m_isFirstRun = false;
        }
        else
        {
            transform.position = new Vector2(m_rightPositionReset, 0.0f);
        }
    }
    /// <summary>
    /// This method is used to check if this object has reached a position where it needs to be reset.
    /// If so then this object's position will be reset
    /// </summary>
    void CheckBounds()
    {
        if(transform.position.x <= -3.86f)
        {
            Reset();
        }
    }
    /// <summary>
    /// This method is used to move this object horizontally at a specified speed
    /// </summary>
    void Move()
    {
        Vector2 currentPosition = transform.position;
        currentPosition -= new Vector2(horizontalSpeed, 0.0f);
        transform.position = currentPosition;
    }
}
