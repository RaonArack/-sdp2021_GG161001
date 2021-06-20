using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bul_Player : MonoBehaviour
{
    int dir;
    float speed;
    // Start is called before the first frame update
    private void OnEnable()
    {
        transform.position = GameManager.Instance().player.transform.position;
        dir = GameManager.Instance().player.faceDir;
        speed = 25f;
    }

    // Update is called once per frame
    void Update()
    {
        speed += Time.deltaTime * 30;
        transform.Translate(dir * speed * Time.deltaTime, 0, 0);
        if (Mathf.Abs(transform.position.x) > 16) { gameObject.SetActive(false); }
    }
}