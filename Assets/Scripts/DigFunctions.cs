using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigFunctions : MonoBehaviour
{

    public LayerMask DirtCheck;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 Aimdir = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if(Input.GetKeyDown(KeyCode.U))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position,Aimdir,distance,DirtCheck);

            if (hit.collider.gameObject.GetComponent<DirtBloc>() != null)
            {
                hit.collider.gameObject.GetComponent<DirtBloc>().Dugup();
            }
            else
            {
                Debug.Log("We Aint found Shit");
            }

        }
    }
}
