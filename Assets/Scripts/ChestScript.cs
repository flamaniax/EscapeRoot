using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    public GameObject Question;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenChest()
    {
        //open canvas with problem
        PlayerPrefs.SetInt("HasControl",0);
        Question.SetActive(true);
        Destroy(gameObject);
    }
}
