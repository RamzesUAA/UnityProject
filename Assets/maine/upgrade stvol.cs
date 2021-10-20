using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class eshgb : MonoBehaviour
{

    public int upins;
    public int downs;
    public int uroven;
    public int progg;
    public int cina;

    [SerializeField]
    private Text up;
    [SerializeField]
    private Text down;
    [SerializeField]
    private Text up2;
    [SerializeField]
    private Text down2;
    [SerializeField]
    private Text lowi;
    [SerializeField]
    private Text lvl;
    [SerializeField]
    private Text lvl2;
    [SerializeField]
    private Text prog;
    [SerializeField]
    private Text prog2;
    [SerializeField]
    private Text ugrade;
    [SerializeField]
    private Text ugrade2;
    [SerializeField]
    private Text cena2;
    [SerializeField]
    private Text cena;



    // Start is called before the first frame update
    void Start()
    {
        upins = 100;
        downs = 0;
        uroven = 1;
        progg = 2;
        cina = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (uroven < 8)
        {
            if ( Input.GetKeyDown( KeyCode.Space ))
            {
                if (Random.Range(100, 0) > downs)
                {
                    upins = upins - 15;
                    downs = downs + 15;
                    uroven = uroven + 1;
                    lvl.text = uroven + " LvL ";
                    lvl2.text = uroven + " LvL ";
                    progg = progg + 1;
                    cina = cina + 100;
                }
                else
                {
                    upins = upins + 15;
                    downs = downs - 15;
                    uroven = uroven - 1;
                    lvl.text = uroven + " LvL ";  
                    lvl2.text = uroven + " LvL ";
                    progg = progg - 1;
                    cina = cina - 100;       
                }
            }
        }
        else
        {
            ugrade.text = " Max LvL ";
            ugrade2.text = " Max LvL ";
            upins = 0;
            downs = 100;
        }

        up.text = "" + upins + " % ";
        down.text = "" + downs + " % ";
        up2.text = "" + upins + " % ";
        down2.text = "" + downs + " % ";
        prog.text = progg + " LvL ";
        prog2.text = progg + " LvL ";
        cena.text = "" + cina;
        cena2.text = "" + cina; 
    }
}
