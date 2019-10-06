/* Filename: AudioClip.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Last modified: Oct 2, 2019
 * This class is an enum class that is used by other scripts and objects to manage audio clip that 
 * is going to play in certain cases.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum AudioClip 
{
    NONE = -1,
    MUSIC,
    FIRE,
    HIT,
    NUMBER_OF_CLIPS
}
