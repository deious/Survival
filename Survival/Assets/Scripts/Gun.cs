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
        gunAudioPlayer = GetComponent<AudioSource>();
        bulletLineRenderer = GetComponent<LineRenderer>();

        bulletLineRenderer.positionCount = 2;
        bulletLineRenderer.enabled = false;
    }

    void OnEnable()
    {
        magAmmo = magCapacity;
        state = State.Ready;
        lastFireTime = 0;
    }

    public void Fire()
    {
        if(state == State.Ready && Time.time >= lastFireTime + timeBetFire)
        {
            lastFireTime = Time.time;
            Shot();
        }
    }

    void Shot()
    {
        RaycastHit hit;
        Vector3 hitPosition = Vector3.zero;

        if(Physics.Raycast(fireTransform.position, fireTransform.forward, out hit, fireDistance))
        {
            // IDamageable target = hit.collider.GetComponent<IDamageable>();   적 관련 스크립트 생성 후 추가 예정

            /*if(target != null)
            {
                target.OnDamage(damage, hit.point, hit.normal);
            }*/

            hitPosition = hit.point;
        }
        else
        {
            hitPosition = fireTransform.position + fireTransform.forward * fireDistance;
        }

        StartCoroutine(ShotEffect(hitPosition));

        magAmmo--;

        if(magAmmo <= 0)
        {
            state = State.Empty;
        }
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
