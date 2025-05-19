using UnityEngine;

public class playermoved : MonoBehaviour
{
    public float velocidad = 5f;

    void Update()
    {
        float moverHorizontal = Input.GetAxis("Horizontal");
        float moverVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(moverHorizontal, 0, moverVertical);
        transform.Translate(direccion * velocidad * Time.deltaTime, Space.World);
    }
}
