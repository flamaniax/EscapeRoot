using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    public GameObject DirtTile;

    public int Width,Height,XOffset,YOffset;

    public Vector2 UScale;

    public GameObject Exit,MapChest,Xchest,Ychest;

    public QuestionMaster QM;

    // Start is called before the first frame update
    void Start()
    {
        DirtTile.transform.localScale = UScale;

        float ScaleX = DirtTile.transform.localScale.x;
        float ScaleY = DirtTile.transform.localScale.y;


        //randomize coordinates of ExitPortal
        Exit.transform.position = new Vector3((Random.Range(0,Width)-(XOffset*1/ScaleX)),(Random.Range(0,Height)-(YOffset*1/ScaleY)-0.5f),Exit.transform.position.z)*ScaleX;
        //Exit.SetActive(false);
        
        //Create question to open ExitPortal, and change the text in MapChest for it

        

        //randomize cooridnates of MapChest

        MapChest.transform.position = new Vector3((Random.Range(0,Width)-(XOffset*1/ScaleX)),(Random.Range(0,Height)-(YOffset*1/ScaleY)-0.5f),Exit.transform.position.z)*ScaleX;
        QM.MapCoords = MapChest.transform.position;

        // give X coordinate to Xchest, and give a fitting question

        // give y coordinate to Ychest, and give a fitting question

        for(int x = 0; x<=1/ScaleX*Width; x++)
        {
            for(int y = 0; y<=1/ScaleY*Height; y++)
            {
                Instantiate(DirtTile,new Vector3((x-(XOffset*1/ScaleX)),(y-(YOffset*1/ScaleY)-0.5f),0)*ScaleX,Quaternion.identity);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
