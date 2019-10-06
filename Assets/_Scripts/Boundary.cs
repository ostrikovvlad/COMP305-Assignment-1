/* Filename: Boundary.cs
 * Author: Vladislav Ostrikov
 * Last modified by: Vladislav Ostrikov
 * Modified: Sep 10, 2019
 * This class is used for stroing boundary's values for objects
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Util
{

    [System.Serializable]
    public class Boundary
    {
        public float RightBounds; //  Represents float for the right boundary(indicates max spawn point)
        public float LeftBounds; // Represents float for the left boundary(indicates min spawn point)
        public float StartBounds; // Represents float for the start point(indicates start position on y axis)
        public float EndBounds; // Represents float for the end point(indicates end point for an object)
    }

}
