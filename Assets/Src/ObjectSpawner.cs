using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public Vector3 throwTargetForce;
    public Vector3 throwBombForce;
    public Rigidbody rbBottle;
    public Rigidbody rbDinamyte;
    public int num_of_target;
    public int freqTarget;
    public int freqBomb;

    public PlayerShoot ps;

    void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, freqTarget);
        InvokeRepeating("SpawnBomb", 1.5f, freqBomb);
    }

    void SpawnTarget()
    {
        for (byte i = 0; i < num_of_target; i++)
        {
            if (ps.stateFinish) break;
            Rigidbody cloneBottle;
            cloneBottle = Instantiate(rbBottle, new Vector3(-6f, -0.248f, Random.Range(-4 , 5)), Quaternion.identity) as Rigidbody;
            cloneBottle.AddForce(throwTargetForce, ForceMode.Impulse);
            Destroy(cloneBottle.gameObject, 2);
        }
    }

    void SpawnBomb()
    {
        for (byte i = 0; i < num_of_target; i++)
        {
            if (ps.stateFinish) break;
            Rigidbody cloneBomb;
            cloneBomb = Instantiate(rbDinamyte, new Vector3(-6f, -0.248f, Random.Range(-4, 5)), Quaternion.identity) as Rigidbody;
            cloneBomb.AddForce(throwBombForce, ForceMode.Impulse);
            Destroy(cloneBomb.gameObject, 2);
        }
    }
}
