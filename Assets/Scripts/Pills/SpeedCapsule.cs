using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCapsule : MonoBehaviour, Capsule
{
    public float timeout = 4f;
    public float bonus = 0.4f;
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
        this.player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(this.OnTimeout(this.timeout));
    }

    // Update is called once per frame
    void Update(){    }

    private void OnCollisionEnter(Collision c)
    {
        Debug.Log(c.gameObject.tag);
        if (c.gameObject.CompareTag("Player") && !collided)
        {
            suara.Play();
            (player.GetComponent<PlayerMovement>()).AddSpeed(bonus);
            this.collided = true;
            this.gameObject.transform.localScale = new Vector3(0, 0, 0);
            Destroy(this.gameObject, suara.clip.length);
        }

    }
}
