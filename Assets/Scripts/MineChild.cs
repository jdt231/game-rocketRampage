using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineChild : MonoBehaviour
{
    public Mine parentMine;
    bool isActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isActive == true)
        {
            isActive = false;
            parentMine.ExplodeMine();
        }
    }
}
