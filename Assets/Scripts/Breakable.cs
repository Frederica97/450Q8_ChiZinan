using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    public void Break()
    {
        print("into break");
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

  
    // Update is called once per frame
    void Update()
    {
        
    }
}
