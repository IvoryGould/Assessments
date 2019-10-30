using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    Transform t;
    GameObject _camera;
    Vector3 cameraPos;

    // Use this for initialization
    void Start () {

        t = this.transform;
        _camera = GameObject.Find("Main Camera");
        Vector3 cameraPos = _camera.transform.position;


    }

    [SerializeField]
    public float moveSpeed;
    [SerializeField]
    public float rotateSpeed;
    [SerializeField]
    public float zoomSpeed;

	void Update () {

        float h = Input.GetAxis("Horizontal") * moveSpeed;
        float v = Input.GetAxis("Vertical") * moveSpeed;
        float y = Input.GetAxis("YAxis") * moveSpeed;

        this.transform.Translate(h * Time.deltaTime, y * Time.deltaTime, v * Time.deltaTime);

        t.eulerAngles = new Vector3(t.eulerAngles.x, t.eulerAngles.y, 0);

        if (Input.GetMouseButton(1)) {

            float mh = Input.GetAxis("Mouse X") * rotateSpeed;
            float mv = Input.GetAxis("Mouse Y") * rotateSpeed;

            this.transform.Rotate(mv * Time.deltaTime, mh * Time.deltaTime, 0);

        }

        float ms = Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

        _camera.transform.Translate(0, 0, ms * Time.deltaTime);

        if (_camera.transform.localPosition.z > 0)
        {

            cameraPos = transform.position;
            _camera.transform.position = cameraPos;

        }

    }

}
