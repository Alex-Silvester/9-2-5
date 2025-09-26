using System.Security.Cryptography;
using UnityEngine;

public class ClipFollow : MonoBehaviour
{
    public static int Position = Shader.PropertyToID("_Position");
    public static int Size = Shader.PropertyToID("_Size");

    public Material ClippingMat;
    public Camera main_camera;
    public Transform player;
    public LayerMask Mask;
    Ray ray;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        ray = new Ray(main_camera.transform.position, (player.transform.position - main_camera.transform.position).normalized);
        Debug.DrawLine(main_camera.transform.position, player.transform.position, Color.green);

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, Mask))
        {
            if (hit.collider.tag == "wall")
            {
                Debug.Log("Wall Hit");
                ClippingMat.SetFloat(Size, 1.5f);
            }

            else
            {
                Debug.Log("Nothing");
                ClippingMat.SetFloat(Size, 0);
            }
        }
        var view = main_camera.WorldToViewportPoint(transform.position);
        ClippingMat.SetVector(Position, view);
    }
}

