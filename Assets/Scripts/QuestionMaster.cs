using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionMaster : MonoBehaviour
{   
    private string PotentialAnswer;

    public GameObject VicScreen;

    public TextMeshProUGUI coords; 

    bool Xgot,Ygot = false;

    public Vector2 MapCoords;
    // Start is called before the first frame update
    void Start()
    {
        VicScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Xgot && Ygot)
        {
            coords.text = "(" + MapCoords.x + "," + MapCoords.y + ")";
        }
        else if(Xgot)
        {
            coords.text = "(" + MapCoords.x + ",y)";
        }
        else if(Ygot)
        {
            coords.text = "(x," + MapCoords.y + ")";
        }
        else
        {
            coords.text = "(x,y)";
        }

    }

    public void TextInput(string s)
    {
        PotentialAnswer = s;
        Debug.Log(PotentialAnswer);
    }

    public void AnswerCheck(GameObject GivenScreen)
    {
        Debug.Log("This is the Correct Answer");        
        GivenScreen.SetActive(false);
        PlayerPrefs.SetInt("HasControl",1);
    }

    public void GiveCoord(bool isX)
    {
        if(isX)
        {
            Xgot = true;
        }
        else
        {
            Ygot = true;
        }
    }

    public void SummonPortal(GameObject Portal)
    {
        Portal.SetActive(true);
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
