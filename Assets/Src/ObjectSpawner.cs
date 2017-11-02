using UnityEngine;

public class ObjectSpawner : MonoBehaviour {

    [SerializeField]
    private GameObject bottleReference;
    private Vector3 throwForce = new Vector3(0, 18, 0);
    public Rigidbody rb;

    void Start()
    {
        InvokeRepeating("SpawnTarget", 0.5f, 6);
    }

    void SpawnTarget()
    {
        rb = GetComponent<Rigidbody>();
        for (byte i = 0; i < 4; i++)
        {
            GameObject target = Instantiate(bottleReference, new Vector3(Random.Range(10, 30), Random.Range(-25, -35), -32), Quaternion.identity) as GameObject;
            rb.AddForce(throwForce, ForceMode.Impulse);
        }
    }
}
