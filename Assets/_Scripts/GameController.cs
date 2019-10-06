/* Filename: GameController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Last modifed: Oct 2, 2019
 * This script is used to manage a game, game settings and sounds
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Util
{
    [System.Serializable]
    public class GameController : MonoBehaviour
    {
        [Header("Scene Game Objects")]
        public GameObject spider; // Represents a GameObject to store a reference for a Spider object 
        public GameObject thing; // Represents a GameObject to store a reference for a Thing object 
        public GameObject ghost; // Represents a GameObject to store a reference for a Ghost object 

        [Header("Spider Controller")]
        public int noOfSpiders; // Represents a number of Spider items that will be spawned in the game
        public List<GameObject> spiders; // Represents a List to store multiple Spider objects

        [Header("Thing Controller")]
        public int noOfThings; // Represents a number of Thing items that will be spawned in the game
        public List<GameObject> things; // Represents a List to store multiple Thing objects

        [Header("Ghost Controller")]
        public int noOfGhosts; // Represents a number of Ghost items that will be spawned in the game
        public List<GameObject> ghosts; // Represents a List to store multiple Ghost objects

        [Header("Audio Sources")]
        public AudioClip defaultSoundClip; // Represents an AudioClip object that will be used to manage game sounds
        public AudioSource[] audioSources; // Represents a list of AudioSource objects that store sounds 
                                           // that will be used in the game

        [Header("Scoreboard")]
        [SerializeField]
        private int _score; // Represents a variable to store an integer number for a game score
        public Text scoreLabel; // Represents Text object where game score will appear

        [SerializeField]
        private int _lives; // Represents a variable to store an integer number for a player lives
        public Text livesLabel; // Represents Text object where player lives will appear

        // PUBLIC Properties
        public int Score
        {
            get
            {
                return _score;
            }

            set
            {
                _score = value;
                scoreLabel.text = "Score: " + _score.ToString(); 
            }
        }
        public int Lives
        {
            get
            {
                return _lives;
            }

            set
            {
                _lives = value;
                if (_lives <= 0)
                {
                    SceneManager.LoadScene("End");
                }
                livesLabel.text = "Lives: " + _lives.ToString() + "/100";
            }
        }
        // Start is called before the first frame update
        void Start()
        {
            Lives = 100;
            Score = 0;
            // This if statement is used to play game music on a loop(infinite)
            if ((defaultSoundClip != AudioClip.NONE) && (defaultSoundClip != AudioClip.NUMBER_OF_CLIPS))
            {
                AudioSource defaultClip = audioSources[(int)defaultSoundClip];
                defaultClip.playOnAwake = true;
                defaultClip.loop = true;
                defaultClip.Play();
            }
            // Spawn as many spiders as noOfSpiders value
            for (int spiderNumber = 0; spiderNumber < noOfSpiders; spiderNumber++)
            {
                spiders.Add(Instantiate(spider));
            }
            // Spawn as many things as noOfThings value
            for (int thingNumber = 0; thingNumber < noOfThings; thingNumber++)
            {
                things.Add(Instantiate(thing));
            }
            // Spawn as many ghosts as noOfGhosts value
            for (int ghostNumber = 0; ghostNumber < noOfGhosts; ghostNumber++)
            {
                ghosts.Add(Instantiate(ghost));
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
