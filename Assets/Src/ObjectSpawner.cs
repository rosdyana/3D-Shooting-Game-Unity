using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    public Vector3 throwTargetForce;
    public Vector3 throwBombForce;
    public Rigidbody rbBottle;
    public Rigidbody rbDinamyte;
    public int num_of_target;
    public int freqTarget;
    public int freqBomb;

    void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, freqTarget);
        InvokeRepeating("SpawnBomb", 1.5f, freqBomb);
    }

    void SpawnTarget()
    {
        //rb = GetComponent<Rigidbody>();
        for (byte i = 0; i < num_of_target; i++)
        {
            //GameObject target = Instantiate(bottleReference, new Vector3(-5.8f, -0.248f, Random.Range(-3 , 4)), Quaternion.identity) as GameObject;
            //rb.AddForce(throwForce, ForceMode.Impulse);
            Rigidbody cloneBottle;
            cloneBottle = Instantiate(rbBottle, new Vector3(-3.8f, -0.248f, Random.Range(-4 , 5)), Quaternion.identity) as Rigidbody;
            //clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            cloneBottle.AddForce(throwTargetForce, ForceMode.Impulse);
            Destroy(cloneBottle, 2);
        }
    }

    void SpawnBomb()
    {
        //rb = GetComponent<Rigidbody>();
        for (byte i = 0; i < num_of_target; i++)
        {
            //GameObject target = Instantiate(bottleReference, new Vector3(-5.8f, -0.248f, Random.Range(-3 , 4)), Quaternion.identity) as GameObject;
            //rb.AddForce(throwForce, ForceMode.Impulse);
            Rigidbody cloneBomb;
            cloneBomb = Instantiate(rbDinamyte, new Vector3(-3.8f, -0.248f, Random.Range(-4, 5)), Quaternion.identity) as Rigidbody;
            //clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            cloneBomb.AddForce(throwBombForce, ForceMode.Impulse);
            Destroy(cloneBomb, 2);
        }
    }
}
