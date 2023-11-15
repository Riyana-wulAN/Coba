using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gerak1 : MonoBehaviour
{
    public int kecepatan, kekuatanLompat;
    public bool balik;
    public int pindah;

    Rigidbody2D lompat;

    public bool tanah;
    public LayerMask targetlayer;
    public Transform deteksitanah;
    public float jangkauan;

    Animator anim;
    void Start()
    {
        lompat = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (tanah == true)
        {
            anim.SetBool("lompat", false);
        } else 
        {
            anim.SetBool("lompat", true);
        }
        tanah = Physics2D.OverlapCircle(deteksitanah.position, jangkauan, targetlayer);

        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * kecepatan * Time.deltaTime);
            pindah = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("lari", true);
            transform.Translate(Vector2.right * -kecepatan * Time.deltaTime);
            pindah = -1;
        }else
        {
            anim.SetBool("lari", false);
        }
        if (tanah == true && (Input.GetKey(KeyCode.Mouse0))) 
        {
            lompat.AddForce(new Vector2(0, kekuatanLompat));
        }
        if (pindah > 0 && !balik)
        {
            balikbadan();
        }
        else if (pindah < 0 && balik)
        {
            balikbadan();
        }
        void balikbadan()
        {
            balik = !balik;
            Vector3 karakter = transform.localScale;
            karakter.x *= -1;
            transform.localScale = karakter;
        }
    }
}