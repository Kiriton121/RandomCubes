/****
 * Created By: Zhiyong Lu
 * Date Created: Jan 24, 2022
 * 
 * Last Edited By: Zhiyong Lu
 * Last Edited: Jan26, 2022
 * 
 * Description: Spam 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    public GameObject cubePrefab; //new game object
    public float scalingFactor = 0.95f;// amount each cube will shrink each frame
    public int numberOfCubes = 0;//Total number of cubes instatied
    public List<GameObject> gameObjectList; // list for all the cubes
    


    
    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>();// instated the list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; // add to the number of cubes 

        GameObject gObj = Instantiate<GameObject>(cubePrefab); // craetes cube instance

        gObj.name = "Cube" + numberOfCubes;// name of cube instance

        Color randColor = new Color(Random.value, Random.value, Random.value); // creates a new random colar

        gObj.GetComponent<Renderer>().material.color = randColor; // assigns random color to game object

        gObj.transform.position = Random.insideUnitSphere;//random location inside a sphere radius of 1 out from 0,0,0

        gameObjectList.Add(gObj); // add to list

        List<GameObject> removeList = new List<GameObject> ();// list for removed objects

        foreach(GameObject goTemp in gameObjectList ){
            float scale = goTemp.transform.localScale.x;//records current scale 
            scale *= scalingFactor; // scale multipled by scale factor
            goTemp.transform.localScale = Vector3.one * scale; //transform scale

            if(scale <= 0.1f)
            {
                removeList.Add(goTemp);
            }// end if (scale < 0.1f)
        }// end foreach (GameObject goTemp in gameObjectList)

        foreach (GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); // remove from object list
            Destroy(goTemp);//destorys game object
            Debug.Log(removeList);
        }// end foreach (GameObject goTemp in removeList)
    }
}
