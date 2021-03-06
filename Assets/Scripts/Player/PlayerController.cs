using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    public GameObject player, hose;
    public float force;
    public GameObject waterEffect;
    public Vector3 waveScaleForHose;


    private void Update()
    {
        if (StateManager.Instance.state == State.InGame)
        {
            if (Input.GetKey(KeyCode.W))
            {
                AnimationManager.Instance.Walk();
                waterEffect.SetActive(false);
                gameObject.transform.localPosition += new Vector3(0, 0, 1 * (force / 4) * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                AnimationManager.Instance.Idle();
                waterEffect.SetActive(true);
                waterEffect.GetComponent<ParticleSystem>().Play();
            }
            else if (Input.GetKey(KeyCode.S))
            {
                AnimationManager.Instance.Walk();
                waterEffect.SetActive(false);
                gameObject.transform.localPosition -= new Vector3(0, 0, 1 * (force / 4) * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.S))
            {
                AnimationManager.Instance.Idle();
                waterEffect.SetActive(true);
                waterEffect.GetComponent<ParticleSystem>().Play();
            }
            else if (Input.GetKey(KeyCode.A))
            {
                player.transform.Rotate(0, -2 * force * Time.deltaTime, 0);
                hose.transform.Rotate(0, -2 * force * Time.deltaTime, 0);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                player.transform.Rotate(0, 2 * force * Time.deltaTime, 0);
                hose.transform.Rotate(0, 2 * force * Time.deltaTime, 0);
            }
        }

    }

    public void StartWaveForHose(){
        StartCoroutine(WaveForHose());
    }

    IEnumerator WaveForHose(){
        while (true)
        {
            for (int i = 0; i < hose.transform.childCount; i++)
            {
                hose.transform.GetChild(i).localScale += waveScaleForHose;
                yield return new WaitForSeconds(.01f);
                hose.transform.GetChild(i).localScale -= waveScaleForHose;
            }
            
        }
    }

    public void StartForceWater(){
        waterEffect.SetActive(true);
    }
    public void EndForceWater(){
        waterEffect.SetActive(false);
    }
}
