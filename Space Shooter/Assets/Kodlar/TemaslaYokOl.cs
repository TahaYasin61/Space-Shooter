using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemaslaYokOl : MonoBehaviour {

    public GameObject patlama;
    public GameObject playerpatlama;
    GameObject OyunKontrol;
    OyunKontrol kontrol;

    private void Start()
    {
        OyunKontrol = GameObject.FindGameObjectWithTag("oyunkontrol");
        kontrol = OyunKontrol.GetComponent<OyunKontrol>();
        
    }


    private void OnTriggerEnter(Collider col)
    {
        
        if (col.tag!="sinir")
        {

            Destroy(col.gameObject);
            Destroy(gameObject);

            Instantiate(patlama,transform.position,transform.rotation);
            kontrol.ScoreArttir(10);
        }

        if (col.tag=="Player")
        {

            Instantiate(playerpatlama, col.transform.position,col.transform.rotation);
            kontrol.oyunBitti();
        }
       

        

        

    }



}
