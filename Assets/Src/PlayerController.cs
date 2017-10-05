using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour {
    [SerializeField]
    private float speed = 20f;
    [SerializeField]
    private float lookSensitifity = 3f;
    [SerializeField]
    private float fowardForce = 200f;
    private PlayerMotor motor;

    void Start()
    {
        motor = GetComponent<PlayerMotor>();
    }

    void Update()
    {
        float _xMov = Input.GetAxisRaw("Horizontal");
        float _zMov = Input.GetAxisRaw("Vertical");

        Vector3 _movHorizontal = transform.right * _xMov; // (1, 0, 0) ? (-1, 0, 0) 
        Vector3 _movVertical = transform.forward * _zMov; // (0, 0, 1)

        // final movement vector
        Vector3 _velocity = (_movHorizontal + _movVertical).normalized * speed;

        // apply movement
        motor.Move(_velocity, fowardForce);

        // calculate rotation
        float _yRot = Input.GetAxisRaw("Mouse X");
        Vector3 _rotation = new Vector3(0f, _yRot, 0f) * lookSensitifity;

        // apply rotation
        motor.Rotate(_rotation);

        // calculate camera rotation
        float _xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _CameraRotation = new Vector3(_xRot, 0f, 0f) * lookSensitifity;

        // apply camera rotation
        motor.CameraRotate(_CameraRotation);
    }
}
