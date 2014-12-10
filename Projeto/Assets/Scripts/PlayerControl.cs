using UnityEngine;
using System.Collections;

/// <summary>
/// Player Control Version 1.0
/// </summary>
public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    private Vector3 position = new Vector3(0, 0, 0);
    public GameObject ActiveCamera;
    public Transform PosiCamera;

    void Start()
    { position = new Vector3(0, 0, 0); }

    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            //Locate where the player clicked on the terrain
            locatePosition();
        }

        //Move the player to the position
        moveToPosition();
        ControleCamera();
    }

    void locatePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 1000))
        { position = new Vector3(hit.point.x, hit.point.y, hit.point.z); }
    }

    void moveToPosition()
    {

        if (Vector3.Distance(transform.position, position) > 1 && position != new Vector3(0,0,0))
        {
            Quaternion newRotation = Quaternion.LookRotation(position - transform.position, Vector3.forward);

            newRotation.x = 0f;
            newRotation.z = 0f;

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, Time.deltaTime * 10);
            transform.Translate(0, 0, 5 * Time.deltaTime);
        }
    }

    void ControleCamera()
    {
        ActiveCamera.transform.position = Vector3.Lerp(ActiveCamera.transform.position, PosiCamera.position, 3 * Time.deltaTime);
        ActiveCamera.transform.rotation = Quaternion.LookRotation(transform.position - ActiveCamera.transform.position);
    }

}