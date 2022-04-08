using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCapsule : MonoBehaviour, Capsule
{
    PlayerHealth ph;
    public float timeout = 4f;
    public int bonus = 25;
    private bool collided = false;
    public AudioClip audioClip;
    GameObject player;
    AudioSource suara;

    public IEnumerator OnTimeout(float to)
    {
        yield return new WaitForSeconds(to);
        if (!collided)
        {
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        this.timeout = 4f;
        suara = GetComponent<AudioSource>();
        //suara.clip = audioClip;
        this.player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(this.OnTimeout(this.timeout));
    }

    // Update is called once per frame
    void Update(){}


    private void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.tag);
        if (c.gameObject.CompareTag("Player") && !collided)
        {
            Debug.Log("Menarik gan");
            suara.Play();
            PlayerHealth ph = this.player.GetComponent<PlayerHealth>();
            ph.AddHealth(bonus);
            this.collided = true;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(this.gameObject, suara.clip.length);
        }
        
    }
}
