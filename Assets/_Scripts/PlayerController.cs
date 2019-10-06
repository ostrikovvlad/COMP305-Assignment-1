/* Filename: PlayerController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Last modified: Oct 2, 2019
 * This script is used for player controller. It manages movements(in this case only Jumping), shooting
 * and checking position of the player object.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Util;

public class PlayerController : MonoBehaviour
{
    public GameController gameController;
    public GameObject fire; // Represents an object for a fire object
    public float fireRate; // Is used to control how often a player can shoot
    public Animator animator; // Is used to control animations
    public AudioSource fireSound; // Is used to store an audio for a shooting sound
    public AudioSource gotHitByFire; // Is used to store an audio when player gets hit by an enemy fire
    public AudioSource painSound; // Is used to store an audio for loosing health

    private Rigidbody2D rgb;
    private Vector2 jump; // Is used to manage jumping force
    private bool isJumping; // Is used to check if a okayer is jumping
    private float nextFire; // Is used to manage shooting
    // Start is called before the first frame update
    void Start()
    {
        rgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckBounds();
        Fire();
    }
    /// <summary>
    /// This method is used to implement jumping of a player if a player is not jumping right now
    /// </summary>
    private void Jump()
    {
        jump = new Vector2(0.00f, 0.55f);
        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false && transform.position.y < -0.3f)
        {
            isJumping = true;
            animator.SetBool("IsJumping", true);
            rgb.AddForce(jump,ForceMode2D.Impulse);
        }
    }
    /// <summary>
    /// Is used to check if a user is on the ground, which means player is not jumping
    /// </summary>
    public void CheckBounds()
    {
        if(transform.position.y > -0.3f && transform.position.y < 0.4)
        {
            isJumping = false;
            animator.SetBool("IsJumping", false);
        }
    }
    /// <summary>
    /// This method is used to manage all the collisions that are interacting with this object
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.gameObject.tag)
        {
            case "Spider": // This will run if a player gets hit by a spider
                painSound.Play();
                gameController.Lives -= 10;
                animator.SetTrigger("IsHurted");
                break;
            case "Thing": // This will run if a player gets hit by a thing
                painSound.Play();
                gameController.Lives -= 10;
                animator.SetTrigger("IsHurted");
                break;
            case "GhostFire": // This will run if a player gets hit by a ghost fire
                gotHitByFire.Play();
                painSound.Play();
                gameController.Lives -= 10;
                animator.SetTrigger("IsHurted");
                Destroy(other.gameObject);
                break;
        }
    }
    /// <summary>
    /// This method is used to manage player shooting. Player will shoot as often as fire rate is set
    /// When shooting new Fire object will be instantiated near a player.
    /// </summary>
    public void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time > nextFire)
        {
            fireSound.Play();
            nextFire = Time.time + fireRate;
            //animator.SetTrigger("IsShooting");
            Instantiate(fire, transform.position + new Vector3(0.4f, 0.1f), transform.rotation);
        }
    }
}
