using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    // Start is called before the first frame update
    protected virtual void Start()
    {
        DisableBarrier();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected void EnableBarrier()
    {
        gameObject.SetActive(true);
    }

    private void DisableBarrier()
    {
        gameObject.SetActive(false);
    }
}
