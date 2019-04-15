using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OyunKontrol : MonoBehaviour {

    public GameObject Asteroid;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;
    public Text text;
    public Text OyunBittiText;
    public Text yenidenBaslaText;
    bool oyunBittiKontrol = false;
    bool yenidenBaslaKontrol = false;
    

    int score;
	void Start ()
    {
       
        score = 0;
        text.text = "score = " + score;
        StartCoroutine(olustur());
	
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)&& yenidenBaslaKontrol)
        {

            SceneManager.LoadScene("spaceshooter");

        }
    }

    IEnumerator olustur()
    {
        yield return new WaitForSeconds(baslangicBekleme);
        while (true)
        {
            for (int i = 0; i < 10; i++)
            {

                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Asteroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            if (oyunBittiKontrol)
            {

                yenidenBaslaText.text = "YENİDEN BAŞLAMAK İÇİN R'YE BASIN";
                yenidenBaslaKontrol = true;
                break;
            }
            yield return new WaitForSeconds(donguBekleme);

            
        }
       
       
        
    }
    public void ScoreArttir(int gelenScore)
    {
        score += gelenScore;
        text.text = "score = " + score;
        Debug.Log(score);
    }

    public void oyunBitti()
    {
        OyunBittiText.text = "OYUN BİTTİ";
        oyunBittiKontrol = true;

    }

}
