using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {
    public float health = 100f;
    public float resetAfterDeathtTime = 5f;
    public AudioClip deathClip;

    private AudioSource audio;
    private Animator anim;
    private PlayerMovement playerMoveMent;
    private HashIDs hash;
    private ScreenFadeInOut screenFadeInOut;
    private LastPlayerSighting lastPlayerSighting;
    private float timer;
    private bool playerDead;

    private void Awake()
    {
        audio = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerMoveMent = GetComponent<PlayerMovement>();
        hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();
        screenFadeInOut = GameObject.FindGameObjectWithTag(Tags.fader).GetComponent<ScreenFadeInOut>();
        lastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
    }

    void PlayerDying()
    {
        playerDead = true;
        anim.SetBool(hash.deadBool, true);
        AudioSource.PlayClipAtPoint(deathClip, transform.position);
    }

    void PlayerDead()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).nameHash == hash.dyingState)
        {
            anim.SetBool(hash.deadBool, false);
        }
        anim.SetFloat(hash.speedFloat, 0f);
        playerMoveMent.enabled = false;
        lastPlayerSighting.position = lastPlayerSighting.resetPosition;
        audio.Stop();
    }

    void LevelReset()
    {
        timer += Time.deltaTime;
        if (timer >= resetAfterDeathtTime)
        {
            screenFadeInOut.EndScene();
        }
    }

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        if (health <= 0f)
        {
            if (!playerDead)
            {
                PlayerDying();
            }
            else
            {
                PlayerDead();
                LevelReset();
            }
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
    }
}
