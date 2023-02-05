using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class QuestionMaster : MonoBehaviour
{   
    private string PotentialAnswer;

    public GameObject VicScreen;

    public TextMeshProUGUI coords,XQuestionText,MapQuestionText,XDis,YDis,PlayerCoordsBox; 

    bool Xgot,Ygot = false;

    public Vector2 MapCoords,ExitCoords,XCoords,YCoords;

    public GameObject MapChest,Player;

    public Button B1,B2,B3,B4;

    public Button FB1,FB2,FB3,FB4;

    public
    // Start is called before the first frame update
    void Start()
    {
        VicScreen.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 PlayerPos = Player.transform.position;

        if(Xgot && Ygot)
        {
            coords.text = "(" + MapCoords.x + "," + MapCoords.y + ")";
            MapChest.SetActive(true);
            XDis.text = "";
            YDis.text = "";
        }
        else if(Xgot)
        {
            coords.text = "(" + MapCoords.x + ",y)";
            XDis.text = "";
            YDis.text = "Distance to Y: " + (PlayerPos-YCoords).magnitude;
        }
        else if(Ygot)
        {
            coords.text = "(x," + MapCoords.y + ")";
            XDis.text = "Distance to X: " + (PlayerPos-XCoords).magnitude;
            YDis.text = "";
        }
        else
        {
            coords.text = "(x,y)";
            XDis.text = "Distance to X: " + (PlayerPos-XCoords).magnitude;
            YDis.text = "Distance to Y: " + (PlayerPos-YCoords).magnitude;
        }

        PlayerCoordsBox.text = "Player: " +  Mathf.Round(PlayerPos.x)  + "," + Mathf.Round(PlayerPos.y) + ")";

        if(Input.GetKeyDown(KeyCode.R))
        {
            restart();
        }

    }

    public void factorXChest(){
        //Program generates random number between 1 and 5. let num be this number. num cannot be equal to x_coord.
        int num = Random.Range(1,6);
        if(MapCoords.x > num)
        {
            XQuestionText.text = "Factor. one of the roots are the x-coordinate for the final chest: " + "x^2 - " + (MapCoords.x - num) + "x" + " + " + (MapCoords.x * num);
        } 
        else
        {
            XQuestionText.text = "Factor. one of the roots are the x-coordinate for the final chest: " + "x^2 - " + (num - MapCoords.x) + "x" + " + " + (MapCoords.x * num);
        }
        B1.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
        B2.GetComponentInChildren<TextMeshProUGUI>().text = MapCoords.x.ToString();
        B3.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
        B4.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
    }

    public void factorfinalChest(){
        
        if(ExitCoords.y > ExitCoords.x)
        {
            MapQuestionText.text = "Factor. the roots are the coordinates for the exit: " + "x^2 - " + (ExitCoords.y - ExitCoords.x) + "x" + " + " + (ExitCoords.x * ExitCoords.y);
            
        } 
        else
        {
            MapQuestionText.text = "Factor. the roots are the coordinates for the exit: " + "x^2 - " + (ExitCoords.x - ExitCoords.y) + "x" + " + " + (ExitCoords.x * ExitCoords.y);
            
        }
        FB1.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
        FB2.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
        FB3.GetComponentInChildren<TextMeshProUGUI>().text = ExitCoords.x.ToString();
        FB4.GetComponentInChildren<TextMeshProUGUI>().text = Random.Range(1,6).ToString();
    
    }

    public void TextInput(string s)
    {
        PotentialAnswer = s;
        Debug.Log(PotentialAnswer);
    }

    public void AnswerCheck(GameObject GivenScreen)
    {
        /*
        if(givenAnswer = MapCoords.x)
        {

        }
        */
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

    public void Quit()
    {
        Debug.Log("application quitting!");
        Application.Quit();
    }
}
