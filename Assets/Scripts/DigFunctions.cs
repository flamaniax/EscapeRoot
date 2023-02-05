using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigFunctions : MonoBehaviour
{

    public LayerMask DirtCheck;
    public float distance;

    public AudioScript DigEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Aimdir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.U) && PlayerPrefs.GetInt("HasControl") == 1)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Aimdir,distance,DirtCheck); 
            

            if(hit.collider.gameObject.GetComponent<ChestScript>() != null)
            {
                DigEffect.PlayChest();
                hit.collider.gameObject.GetComponent<ChestScript>().OpenChest();
            }
            else if (hit.collider.gameObject.GetComponent<DirtBloc>() != null)
            {
                DigEffect.PlayDig();
                hit.collider.gameObject.GetComponent<DirtBloc>().Dugup();
            }
            else if(hit.collider.gameObject.GetComponent<ExitPortal>() != null)
            {
                hit.collider.gameObject.GetComponent<ExitPortal>().Victory();
            }
            else
            {
                Debug.Log("We Aint found Shit");
            }

        }
    }
}
