/* Filename: UIController.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Modified: Sep 10, 2019
 * Represents a script that is controlling user interface. Depending on the active scene it will setup
 * different environment for the user interface
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Util;

public class UIController : MonoBehaviour
{
    public GameController gameController;

    public GameObject startLabel; // Represents a textbox for a start scene
    public GameObject endLabel; // Represents a textbox for an end scene
    public GameObject restartButton; // Represents a button that appears on an end scene
    public GameObject startButton; // Represents a button that appears on a start scene
    // Start is called before the first frame update
    void Start()
    {
        switch (SceneManager.GetActiveScene().name)
        {
            case "Start": // On the Start scene run this
                gameController.livesLabel.enabled = false;
                gameController.scoreLabel.enabled = false;
                restartButton.SetActive(false);
                endLabel.SetActive(false);
                break;
            case "Main": // On the Main scene run this
                startButton.SetActive(false);
                startLabel.SetActive(false);
                restartButton.SetActive(false);
                endLabel.SetActive(false);
                break;
            case "End": // On the End scene run this
                startButton.SetActive(false);
                startLabel.SetActive(false);
                gameController.livesLabel.enabled = false;
                gameController.scoreLabel.enabled = false;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /// <summary>
    /// This method will run after cliking Start button. After running it will load Main scene
    /// </summary>
    public void OnStartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
    /// <summary>
    /// This method will run after cliking Restart button. After running it will load Main scene
    /// </summary>
    public void OnRestartButtonClick()
    {
        SceneManager.LoadScene("Main");
    }
}
