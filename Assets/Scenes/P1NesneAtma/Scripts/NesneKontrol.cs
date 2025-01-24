using UnityEngine;
using UnityEngine.UI;

public class NesneKontrol : MonoBehaviour
{
    public Image nisangah;
    Color renkVarsayilan = Color.green;
    Color renkBulma = Color.white;

    public Transform tutusNokta;
    public float atisHizi;

    Rigidbody nesne;
    Camera kamera;
    void Start()
    {
        kamera = transform.Find("Main Camera").GetComponent<Camera>();
    }

    void Update()
    {
        NesneTara();

        if(nesne != null)
        {
            NesneTut();

            if(Input.GetMouseButtonUp(0))
            {
                NesneAt();
            }

            if (Input.GetMouseButtonDown(1))
            {
                NesneAt(false);
            }
        }
    }

    void NesneTara()
    {
        Ray ray = kamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Kup"))
                {
                    if (Input.GetMouseButton(0) && nesne == null)
                    {
                        nesne = hit.collider.GetComponent<Rigidbody>();
                        nesne.useGravity = false;
                        nesne.constraints = RigidbodyConstraints.FreezeRotation;
                    }

                    nisangah.color = renkBulma;
                    return;
                }
            }
        }

        nisangah.color = renkVarsayilan;
    }

    void NesneTut()
    {
        if(tutusNokta != null)
        {
            nesne.linearVelocity = (tutusNokta.position - nesne.position) * 10f;
        }
    }

    void NesneAt(bool nesneAt = true)
    {
        nesne.useGravity = true;
        nesne.constraints = RigidbodyConstraints.None;

        if(nesneAt)
            nesne.AddForce(kamera.transform.forward * atisHizi, ForceMode.Impulse);

        nesne = null;
    }
}
