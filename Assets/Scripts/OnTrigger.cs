using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTrigger : MonoBehaviour {

    public GameObject Bone;
   
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Scorescript.ScoreValue = +1;
         Destroy(Bone);
        }
        
        
    }


}
