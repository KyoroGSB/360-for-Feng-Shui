using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Accesstophone : MonoBehaviour
{
    Gyroscope m_Gyro;
    public GameObject cam_container;
    public GameObject world_sphere;
    public bool Ishold = false;

    public GameObject Node_ring;
    public GameObject Viewer_ring;
    public GameObject man;
    //UI
    public Button btn;
    public Image cooldown;
    public Text t;
    void Start()
    {
       m_Gyro = Input.gyro;
       m_Gyro.enabled  = true ;
    }
    
    void Update()
    {
        if (Ishold)
        {
            StartCoroutine(Cooldown_plus());
            
        }
        else {
            StartCoroutine(Cooldown_minus());
            
        }

        t.text = " Gyro : " + m_Gyro.attitude;
        StartGyro();
        var camY = Viewer_ring.transform.rotation;

        camY.y = -cam_container.transform.rotation.y;

        Viewer_ring.transform.rotation = camY;

    }


    public void PressedDown() {
        Ishold = true;
        
    }
    public void PressedUp()
    {
        Ishold = false;
     
    }
    //void OnGUI()
    //{
    //    GUI.Label(new Rect(0, 50, 200, 40), "Gyro rotation rate " + m_Gyro.rotationRate);
    //    GUI.Label(new Rect(0, 100, 200, 40), "Gyro attitude" + m_Gyro.attitude);
    //    GUI.Label(new Rect(0, 150, 200, 40), "Gyro enabled : " + m_Gyro.enabled);
    //}


    IEnumerator Cooldown_plus() {

       if(cooldown.fillAmount <= 1)
        {
            cooldown.fillAmount += 1f * Time.deltaTime;
        }
         yield return new WaitForSeconds(0.1f);
    }
    IEnumerator Cooldown_minus()
    {

        if (cooldown.fillAmount >= 0)
        {
            cooldown.fillAmount -= 1f * Time.deltaTime;
        }
        yield return new WaitForSeconds(0.1f);
    }
    void StartGyro() {


        var tmp = world_sphere.transform.rotation;
        tmp.y = -m_Gyro.attitude.y;
        if (cooldown.fillAmount < 1) {
           
            world_sphere.transform.rotation = tmp;

        }

        Node_ring.transform.rotation = tmp;
        man.transform.rotation = tmp;

    }

    
}
