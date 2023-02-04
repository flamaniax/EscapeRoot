using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPatternSpawner : MonoBehaviour
{
    public GameObject WhiteTile,BlackTile;

    // Start is called before the first frame update
    void Start()
    {
        for(int x = 0; x<=21; x++)
        {
            for(int y = 0; y<=9; y++)
            {
                if(y%2 == x%2)
                {
                    Instantiate(WhiteTile,new Vector3((x-10.5f),(y-4.5f),0),Quaternion.identity);
                }
                else
                {
                    Instantiate(BlackTile,new Vector3((x-10.5f),(y-4.5f),0),Quaternion.identity);
                }
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
