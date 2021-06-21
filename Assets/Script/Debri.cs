using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debri : MonoBehaviour
{
    int rotateDir;
    void SetRotate() { rotateDir = (Random.Range(0, 2) * 2 - 1) * 60; }

    void SetPosition()
    {
        Vector2 debriPosition;
        Vector2 playerPosition = GameManager.Instance().player.transform.position;
        float widthRange = GameManager.Width / 2 - 1;
        float heightRange = GameManager.Height / 2 - 1;
        while (true)
        {
            debriPosition.x = Random.Range(-widthRange, widthRange);
            debriPosition.y = Random.Range(-heightRange, heightRange);

            if (Vector2.Distance(debriPosition, playerPosition) > 7)
            {
                break;
            }
        }
        transform.position = debriPosition;
    }

    void OnEnable()
    {
        SetRotate();
        SetPosition();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * rotateDir));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            SetRotate();
            SetPosition();
        }
    }
}
