using UnityEngine;
using UnityEngine.UI;

public class PlayerShoot : MonoBehaviour {

    public PlayerWeapon weapon;
    public ParticleSystem muzzleFlash;
    public Animator anim;
    public GameObject impactEffect;
    public GameObject bottleImpact;
    private GameObject player;
    public AudioSource gunShootFx;
    public AudioSource impactBottleFx;
    public AudioSource impactWoodFx;
    public AudioSource impactBombFx;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
    [SerializeField]
    private GameObject pnlResult;
    public bool hitBottle = false;
    public bool hitBomb = false;
    public bool addScore = false;
    public bool reduceScore = false;
    public bool stateFinish = false;

    private void Start()
    {
        Cursor.visible = false;
        if (cam == null)
        {
            this.enabled = true;
        }
    }

    private void Update()
    {
        if (!stateFinish)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        else
        {
            gameObject.GetComponent<PlayerController>().enabled = false;
            gameObject.GetComponent<PlayerMotor>().enabled = false;
        }

    }

    void Shoot()
    {

        gunShootFx.Play();
        anim.SetBool("isShooting", true);
        muzzleFlash.Play();

        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {


            // Debug.Log("WE hit " + _hit.collider.name);
            if (_hit.collider.tag == "bottle")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactBottleFx.Play();
                addScore = true;
                GameObject impactBottleGO = Instantiate(bottleImpact, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(impactBottleGO, 2f);
            }
            else if(_hit.collider.tag == "bomb")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactBombFx.Play();
                reduceScore = true;

            }
            else if (_hit.collider.tag == "bottle_2")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactBottleFx.Play();
                hitBottle = true;

            }
            else if (_hit.collider.tag == "fake_bottle")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactBombFx.Play();
                GameObject impactBottleGO = Instantiate(bottleImpact, _hit.point, Quaternion.LookRotation(_hit.normal));
                Destroy(impactBottleGO, 2f);
                stateFinish = true;
                Cursor.visible = true;
                showResult(pnlResult);
            }
            else
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactWoodFx.Play();
            }

        }

        GameObject impactGO = Instantiate(impactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
        Destroy(impactGO, 2f);
        anim.SetBool("isShooting", false);

    }

    public void showResult(GameObject panel)
    {
        panel.SetActive(true);
        gameObject.GetComponent<PlayerController>().enabled = false;
    }
}
