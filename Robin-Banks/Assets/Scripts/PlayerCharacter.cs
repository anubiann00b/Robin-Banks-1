using UnityEngine;
using System.Collections;

public class PlayerCharacter : MonoBehaviour
{
    public Camera cam;
    private CharacterController cc;

    void Start()
    {
        cc = (CharacterController)this.GetComponent("CharacterController");
    }

    void Update()
    {
        Vector3 m = Vector3.zero;
        if (Input.GetKey(KeyCode.S))
        {
            m.z += 1;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            m.z -= 1;
        }
        if (Input.GetKey(KeyCode.Space) && cc.isGrounded)
        {
            m.y += 10;
        }
        m.Normalize();
        m *= 100f;
        cc.SimpleMove(m * Time.deltaTime);

        GameObject go = new GameObject();
        Transform t = go.transform;
        t.position = this.transform.position;
        t.Translate(new Vector3(0, .2f, 1.5f), this.transform);
        cam.transform.position = Vector3.Lerp(cam.transform.position, t.position, .1f);
        cam.transform.LookAt(this.transform.position + new Vector3(0, .2f, 0));
        Destroy(go);
    }
}
