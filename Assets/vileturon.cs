using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vileturon : MonoBehaviour
{

    [HideInInspector] public float damage;
    private TextMesh textMesh;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "-" + damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
