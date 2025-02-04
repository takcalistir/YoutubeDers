using UnityEngine;

public class KarakterKontrol : MonoBehaviour
{
    public float hiz = 5;
    public float fareHassasiyet = 2;
    public float fareBakisLimit = 80;

    Rigidbody karakter;
    float xBakis = 0.0f;

    void Start()
    {
        karakter = GetComponent<Rigidbody>();

        // Mouse imlecini gizler.
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Hareket();
        FareYon();
    }

    void Hareket()
    {
        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");

        Vector3 hareketYonu = new Vector3(yatay, 0.0f, dikey).normalized;

        if(hareketYonu.magnitude > 0.1f)
        {
            float kosma = Input.GetKey(KeyCode.LeftShift) ? 2.0f : 1.0f;

            Vector3 yeniPozisyon = hareketYonu * kosma * hiz * Time.deltaTime;
            karakter.MovePosition(karakter.position + transform.TransformDirection(yeniPozisyon));
        }
    }

    void FareYon()
    {
        float fareX = Input.GetAxis("Mouse X");
        float fareY = Input.GetAxis("Mouse Y");

        xBakis -= fareY;

        xBakis = Mathf.Clamp(xBakis, -fareBakisLimit, fareBakisLimit);

        Camera.main.transform.localRotation = Quaternion.Euler(xBakis, 0.0f, 0.0f);

        transform.Rotate(Vector3.up * fareX);
    }
}
