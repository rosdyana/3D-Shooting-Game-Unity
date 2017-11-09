using UnityEngine;

public class ObjectSpawner : MonoBehaviour {


    //private GameObject bottleReference;
    [SerializeField]
    private Vector3 throwForce;
    public Rigidbody rb;
    public int num_of_target;

    void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, 2);
    }

    void SpawnTarget()
    {
        //rb = GetComponent<Rigidbody>();
        for (byte i = 0; i < num_of_target; i++)
        {
            //GameObject target = Instantiate(bottleReference, new Vector3(-5.8f, -0.248f, Random.Range(-3 , 4)), Quaternion.identity) as GameObject;
            //rb.AddForce(throwForce, ForceMode.Impulse);
            Rigidbody clone;
            clone = Instantiate(rb, new Vector3(-3.8f, -0.248f, Random.Range(-4 , 5)), Quaternion.identity) as Rigidbody;
            //clone.velocity = transform.TransformDirection(Vector3.forward * 10);
            clone.AddForce(throwForce, ForceMode.Impulse);
        }
    }
}
