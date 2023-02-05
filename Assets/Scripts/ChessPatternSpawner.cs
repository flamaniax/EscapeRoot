using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPatternSpawner : MonoBehaviour
{
    public GameObject WhiteTile,BlackTile;

    public float Width,Height,XOffset,YOffset;

    public Vector2 UScale;

    // Start is called before the first frame update
    void Start()
    {
        WhiteTile.transform.localScale = UScale;
        BlackTile.transform.localScale = UScale;

        float ScaleX = WhiteTile.transform.localScale.x;
        float ScaleY = WhiteTile.transform.localScale.y;

        for(int x = 0; x<=1/ScaleX*Width; x++)
        {
            for(int y = 0; y<=1/ScaleY*Height; y++)
            {
                if(y%2 == x%2)
                {
                    Instantiate(WhiteTile,new Vector3((x-(XOffset*1/ScaleX)),(y-(YOffset*1/ScaleY)),0)*ScaleX,Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackTile,new Vector3((x-(XOffset*1/ScaleX)),(y-(YOffset*1/ScaleY)),0)*ScaleY,Quaternion.identity);
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
