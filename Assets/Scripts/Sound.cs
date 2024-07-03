using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sound : MonoBehaviour
{
    // Start is called before the first frame update
    
    static Sound instance;
    // Player sound
    public AudioClip jump;
    public AudioSource source;
    public AudioClip playerRun;
    public AudioClip playerHurt;
    public AudioClip playerHit;
   

    // Game sound
    public AudioClip backGroundMusic1;
    public AudioClip backGroundMusic2;
    public AudioClip backGroundMusic3;
    public AudioClip backGroundMusic4;


    // VFXSound
    public AudioClip bulletExplode;
    public AudioClip enemyDeath;
    public AudioClip bearDead;
    public AudioClip tremor;
    public AudioClip bear;
    public AudioClip fireball;
    public AudioClip rockDoor;
    public AudioClip fireBallHit;
    public AudioClip keyPickUp;
    public AudioClip keyUse;

    public static Sound getInstance()
    {
        return instance;
    }
    
    
    void Start()
    {
        instance = this;
        PlaySenceSound();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PlayJump() 
    {
        source.PlayOneShot(jump);
    }


    public void PlayPlayerRun() 
    {   
        source.PlayOneShot(playerRun);
    
    }


    public void PlayPlayerHit() 
    {
        source.PlayOneShot(playerHit);
    }

    public void PlaySenceSound()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        
        int sceneIndex = currentScene.buildIndex;
        

        source.loop = true;
        switch (sceneIndex)
        {
            case 1:
                source.PlayOneShot(backGroundMusic1);
                break;
            case 2:
                return;
                
            case 3:
                source.PlayOneShot(backGroundMusic3);
                return;
            default:
                source.PlayOneShot(backGroundMusic4);
                break;
        }
        source.loop = false;

    }

    public void PlayShoot()
    {
        source.PlayOneShot(playerHit);
    }

    public void PlayExplode()
    {
        source.PlayOneShot(bulletExplode);
    }

    public void PlayeEnemyDeath()
    {
        source.PlayOneShot(enemyDeath);
    }

    public void PlayHurt()
    {
        source.PlayOneShot(playerHurt);
    }

    public void PlayBearDead()
    {
        source.PlayOneShot(bearDead);
    }


    public void PlayTremor()
    {
        source.PlayOneShot(tremor);
    }

    public void PlayFireBall()
    {
        source.PlayOneShot(fireball);
    }


    public void PlayRockDoor()
    {
        source.PlayOneShot(rockDoor);
    }

    public void PlayerFireBallHit()
    {
        source.PlayOneShot(fireBallHit);
    }

    public void PlayKeyPickUp()
    {
        source.PlayOneShot(keyPickUp);
    }

    public void PlayKeyUse() 
    {
        source.PlayOneShot(keyUse);
    }
   
}
