using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform jugador;
    public Vector3 offset = new Vector3(0, 2, -10);

    private Vector3 velocidad = Vector3.zero;

    void LateUpdate()
    {
        Vector3 objetivo = jugador.position + offset;

        transform.position = Vector3.SmoothDamp(
            transform.position,
            objetivo,
            ref velocidad,
            0.15f
        );
    }
}