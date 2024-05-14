using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuturePresentSwitcher : MonoBehaviour
{
    public bool inFuture = false;
    [Header("Toggling Gameobjects Method")]
    [SerializeField] GameObject present;
    [SerializeField] GameObject future;
    

    //teleporting test//
    [Header("Teleporting method")]
    public bool useTeleportMethod = false;
    [SerializeField] GameObject playerCam;

    //Effects
    public AudioSource timeSwapSFX;
    public ParticleSystem timeSwapVFX;


    // Update is called once per frame
    void Update()
    {
        //Teleporting player and camera method
        if (useTeleportMethod)
        {
            //Teleport to present (left click)
            if (Input.GetMouseButtonDown(0) && (inFuture))
            {
                timeSwapSFX.Play();
                timeSwapVFX.Play();
                inFuture = !inFuture;
                transform.position = new Vector3(transform.position.x, transform.position.y - 300, transform.position.z);
                playerCam.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y - 300, playerCam.transform.position.z);
            }
            //Teleport to future (right click)
            if (Input.GetMouseButtonDown(1) && (!inFuture))
            {
                timeSwapSFX.Play();
                timeSwapVFX.Play();
                inFuture = !inFuture;
                transform.position = new Vector3(transform.position.x, transform.position.y + 300, transform.position.z);
                playerCam.transform.position = new Vector3(playerCam.transform.position.x, playerCam.transform.position.y + 300, playerCam.transform.position.z);
            }
        }
        //Old (laggy) method
        else
        {
            //Teleport to present (left click)
            if (Input.GetMouseButtonDown(0) && (inFuture))
            {
                future.SetActive(false);
                present.SetActive(true);
                inFuture = !inFuture;
            }
            //Teleport to future (right click)
            if (Input.GetMouseButtonDown(1) && (!inFuture))
            {
                future.SetActive(true);
                present.SetActive(false);
                inFuture = !inFuture;
            }
        }
    }


}

