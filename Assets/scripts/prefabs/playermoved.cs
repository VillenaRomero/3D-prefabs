using UnityEngine;

public class playermoved : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private int currentLife = 20;

    public float rotationSpeed = 5f;

    public GameObject bulletPrefab;      
    public Transform firePoint;          
    public float bulletForce = 20f;
    void Start()
    {

    }
    void Update()
    {
        Moved();
        PlayerRotation();
        if (Input.GetKeyDown(KeyCode.R))
        {
            Fire();
        }
    }

    public void Moved() {
        /*float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");
        float xspeed = moverHorizontal * velocidad - Time.deltaTime;
        float yspeed = moverVertical * velocidad - Time.deltaTime;

        transform.position += new Vector3(xspeed, 0, yspeed);*/

        if(Input.GetKey(KeyCode.W))
            transform.position += transform.forward * speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.S))
            transform.position -= transform.forward * speed * Time.deltaTime; //  lo correcto          transform.position += -transform.forward * velocidad * Time.deltaTime;
        if (Input.GetKey(KeyCode.A))
            transform.position -= transform.right * speed * Time.deltaTime; // lo mismo 
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.right * speed * Time.deltaTime;
    }
    public void PlayerRotation()
    {
        /*Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            Vector3 lookPos = new Vector3(hit.point.x, transform.position.y, hit.point.z);
            transform.root.LookAt(lookPos);
        }*/
        float mouseX = Input.GetAxis("Mouse X");

        // Rotar solo en el eje Y
        Vector3 rotation = new Vector3(0f, mouseX * rotationSpeed, 0f);
        transform.Rotate(rotation, Space.World);
    }
    private void Fire()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletForce;
    }
    public void TakeDamage()
    {
        currentLife--;
    }
    public void TakeDamage(int damage)
    {
        currentLife -= damage;
    }
}
