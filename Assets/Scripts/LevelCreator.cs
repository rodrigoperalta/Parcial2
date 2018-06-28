using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour {
    public GameObject[] templates;
    // Use this for initialization
    void Start () {
        for (int h = 0; h < 3; h++)
        {
            Vector3 pos = new Vector3(-5.72f + 6.2f * h, -2.44f, 0); //Excuse my magic numbers
            int n = Random.Range(0, templates.Length);
            Instantiate(templates[n], pos, Quaternion.identity);
        }
    }	
}
