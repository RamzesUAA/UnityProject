using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mov : MonoBehaviour
{
    public GameObject PersObject;
    // Start is called before the first frame update
    void Start()
    {
        PersObject.transform.hasChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
    if (PersObject.transform.hasChanged)
    {
        Debug.Log("Двигаешься" + PersObject.transform.position);
        PersObject.transform.hasChanged = false;
       
    }
    else Debug.Log("СТОИШЬ");
    }
}
