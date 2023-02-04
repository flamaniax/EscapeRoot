using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{

    public GameObject DirtTile;

    public float Width,Height,XOffset,YOffset;

    public Vector2 UScale;

    // Start is called before the first frame update
    void Start()
    {
        DirtTile.transform.localScale = UScale;

        float ScaleX = DirtTile.transform.localScale.x;
        float ScaleY = DirtTile.transform.localScale.y;

        for(int x = 0; x<=1/ScaleX*Width; x++)
        {
            for(int y = 0; y<=1/ScaleY*Height; y++)
            {
                Instantiate(DirtTile,new Vector3((x-(XOffset*1/ScaleX)-0.5f),(y-(YOffset*1/ScaleY)-0.5f),0)*ScaleX,Quaternion.identity);
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
