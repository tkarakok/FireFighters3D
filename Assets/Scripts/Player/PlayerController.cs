using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject player, hose;
    public float force;
    public GameObject waterEffect;


    private void Update()
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
