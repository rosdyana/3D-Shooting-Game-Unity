using UnityEngine;

public class PlayerShoot : MonoBehaviour {

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
    public bool hitme = false;
    public bool addScore = false;
    public bool stateFinish = false;

    private void Start()
    {
        Cursor.visible = false;
        if (cam == null)
        {
            this.enabled = true;
        }
        hitme = false;
        addScore = false;
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

        RaycastHit _hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            gunShootFx.Play();
            anim.SetBool("isShooting", true);
            muzzleFlash.Play();

            // Debug.Log("WE hit " + _hit.collider.name);
            if (_hit.collider.tag == "bottle")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactBottleFx.Play();
                hitme = true;
            }
            if(_hit.collider.tag == "barrel")
            {
                Debug.Log("WE hit " + _hit.collider.tag);
                impactWoodFx.Play();
            }

            GameObject impactGO = Instantiate(impactEffect, _hit.point, Quaternion.LookRotation(_hit.normal));
            Destroy(impactGO, 2f);
            anim.SetBool("isShooting", false);
        }

    }
}
