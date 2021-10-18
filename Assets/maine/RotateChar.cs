using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateChar : MonoBehaviour
{
    public float offset;
    public GameObject ammo;
    public Transform shotDir;

    private float timeShot;
    public float startTime;

    public int currentAmmo = 15;
    public int fullammo = 15;

    private Animator anim;

    public GameObject effects;

    [SerializeField]
    private Text ammoCount;
    [SerializeField]
    private Text reloadtx;

    AudioSource m_MyAudioSource;
    bool m_Play;
    bool m_ToggleChange;

    void OnGUI()
    {
        if (timeShot <= 0)
        {

        
            if (Event.current.Equals(Event.KeyboardEvent(KeyCode.Space.ToString())) && currentAmmo > 0)
            {
                Debug.Log("Space key is pressed.");
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
                currentAmmo = currentAmmo - 1;
            }
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        m_MyAudioSource = GetComponent<AudioSource>();
        m_Play = true;
    }

    
    void Update()
    {


        Debug.Log(currentAmmo);
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotateZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateZ + offset);

        if (timeShot <= 0)
        {
            if (Input.GetMouseButtonDown(0) && currentAmmo > 0)
            {
                Instantiate(ammo, shotDir.position, transform.rotation);
                timeShot = startTime;
                currentAmmo = currentAmmo - 1;
                Instantiate(effects, shotDir.position, Quaternion.identity);
                m_MyAudioSource.Play();
            }
        }
        else
        {
        timeShot -= Time.deltaTime;
        }
        ammoCount.text = currentAmmo + " / " + fullammo;

        if (currentAmmo < 1)
        {
            reloadtx.text = " RELOAD "; 
            Invoke("Reload", 4f);
            
        }
    }

    public void Reload()
    {
       reloadtx.text = "  "; 
       currentAmmo = fullammo;
    }
}
