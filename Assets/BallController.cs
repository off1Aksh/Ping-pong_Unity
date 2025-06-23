using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    GameObject panelSelesai;
    Text txPemenang; 
    public int force;
    public float rotationSpeed; // Kecepatan rotasi bola di tempat
    Rigidbody2D rigid;
    public AudioSource audio1,audio2,audio3, audio4;
    int scoreP1;
    int scoreP2;
    Text scoreUIP1;
    Text scoreUIP2;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        Vector2 arah = new Vector2(2, 0).normalized;
        rigid.AddForce(arah * force);
        scoreP1 = 0;
        scoreP2 = 0;
        scoreUIP1 = GameObject.Find("P1Score").GetComponent<Text>();
        scoreUIP2 = GameObject.Find("P2Score").GetComponent<Text>();
        panelSelesai = GameObject.Find ("panelSelesai");
        panelSelesai.SetActive (false);
        audio4 = GetComponent<AudioSource>();

    }

    void Update()
    {
        // Rotasi bola di tempat
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "tepikanan")
        {
            audio1.Play();
            scoreP1 += 1;
            TampilkanScore();
            if (scoreP1 == 4) 
            {
                ResetBall();
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
                txPemenang.text = "Sasuke Win!";
                Destroy (gameObject);
                return;
            } 
            ResetBall();
            Vector2 arah = new Vector2(2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "tepikiri")
        {
            audio1.Play();
            scoreP2 += 1;
            TampilkanScore();
            if (scoreP2 == 4) 
            {
                ResetBall();
                panelSelesai.SetActive (true);
                txPemenang = GameObject.Find ("Pemenang").GetComponent<Text> ();
                txPemenang.text = "Naruto Win!";
                Destroy (gameObject);
                return;
            } 
            ResetBall();
            Vector2 arah = new Vector2(-2, 0).normalized;
            rigid.AddForce(arah * force);
        }
        if (coll.gameObject.name == "bet1")
        {
            audio2.Play();
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
        if (coll.gameObject.name == "bet2")
        {
            audio3.Play();
            float sudut = (transform.position.y - coll.transform.position.y) * 5f;
            Vector2 arah = new Vector2(rigid.velocity.x, sudut).normalized;
            rigid.velocity = new Vector2(0, 0);
            rigid.AddForce(arah * force * 2);
        }
    }

    void ResetBall()
    {
        transform.localPosition = new Vector2(0, 0);
        rigid.velocity = new Vector2(0, 0);
    }

    void TampilkanScore()
    {
        Debug.Log("Score P1: " + scoreP1 + " Score P2: " + scoreP2);
        scoreUIP1.text = scoreP1 + "";
        scoreUIP2.text = scoreP2 + "";
    }
}