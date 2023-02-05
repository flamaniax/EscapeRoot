using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour
{
    public AudioSource Dig,Chest,Jump;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayDig()
    {
        Dig.Play();
    }

    public void PlayChest()
    {
        Chest.Play();
    }

    public void PlayJump()
    {
        Jump.Play();
    }
}
