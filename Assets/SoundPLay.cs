using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPLay : MonoBehaviour
{ 
        public AudioSource clickSound;

        

        public void onClick()
        {
            
            clickSound.Play();
         
        }
}

