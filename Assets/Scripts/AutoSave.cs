using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoSave : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoAutoSave", 10f, 5f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void DoAutoSave()
    {

    }
}
