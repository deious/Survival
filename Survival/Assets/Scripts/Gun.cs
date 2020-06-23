using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum State
    {
        Ready,
        Empty,
        Reloading
    }

    public State state { get; set; }

    public Transform fireTransform;

    public ParticleSystem muzzleFlashEffect;
    public ParticleSystem shellEjectEffect;

    LineRenderer bulletLineRenderer;

    AudioSource gunAudioPlayer;
    public AudioClip shotClip;
    public AudioClip reloadClip;

    public float damage = 25;
    float fireDistance = 50f;

    public int ammoRemain = 100;
    public int magCapacity = 25;
    public int magAmmo;

    public float timeBetFire = 0.12f;
    public float reloadTime = 1.8f;
    float lastFireTime;

    void Awake()
    {

    }

    void OnEnable()
    {
        
    }

    public void Fire()
    {

    }

    void Shot()
    {

    }

    IEnumerator ShotEffect(Vector3 hitPosition)
    {
        bulletLineRenderer.enabled = true;

        yield return new WaitForSeconds(0.03f);

        bulletLineRenderer.enabled = false;
    }

    public bool Reload()
    {
        return false;
    }

    IEnumerator ReloadRoutine()
    {
        state = State.Reloading;

        yield return new WaitForSeconds(reloadTime);

        state = State.Ready;
    }
}
