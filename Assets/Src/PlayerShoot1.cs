using UnityEngine;

public class PlayerShoot1 : MonoBehaviour {

    public PlayerWeapon weapon;
    public ParticleSystem muzzleFlash;
    public Animator anim;
    public GameObject impactEffect;
    public AudioSource gunShootFx;
    public AudioSource impactBottleFx;
    public AudioSource impactWoodFx;

    [SerializeField]
    private Camera cam;
    [SerializeField]
    private LayerMask mask;
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
        hitBottle = false;
        hitBomb = false;
        addScore = false;
        reduceScore = false;
        stateFinish = false;
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
                hitBottle = true;
                //GameObject impactBottleGO = Instantiate(bottleImpact, _hit.point, Quaternion.LookRotation(_hit.normal));
                //Destroy(impactBottleGO, 2f);
            }
            else if(_hit.collider.tag == "bomb")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactWoodFx.Play();
                reduceScore = true;

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
}
