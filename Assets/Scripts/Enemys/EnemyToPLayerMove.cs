using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyToPLayerMove : EnemyMovement
{
     public override void Movement(Transform mTransform, float limitX1, float limitX2, float limitY1, float limitY2)
    {
        if (mTransform.transform.position.x < limitX1 && mTransform.transform.position.x > limitX2 && mTransform.transform.position.y < limitY1 && mTransform.transform.position.y > limitY2)
        {
            switch (randnum)
            {
                case 1:
                    mTransform.transform.Translate(Vector2.up * speed * Time.deltaTime);
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 2:
                    mTransform.transform.Translate(Vector2.down * speed * Time.deltaTime);
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 3:
                    mTransform.transform.Translate(Vector2.right * speed * Time.deltaTime);
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 4:
                    mTransform.transform.Translate(Vector2.left * speed * Time.deltaTime);
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 5:
                    mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.down * ((speed * Time.deltaTime) * Time.deltaTime / 2));
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 6:
                    mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.up * ((speed * Time.deltaTime) / 2));
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 7:
                    mTransform.transform.Translate(Vector2.right * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.down * ((speed * Time.deltaTime) / 2));
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                case 8:
                    mTransform.transform.Translate(Vector2.right * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.up * ((speed * Time.deltaTime) / 2));
                    mTransform.GetComponent<SpriteRenderer>().color = Color.white;

                    break;
                default:
                    //se mueve hacia el jugador y cambia de color
                    mTransform.transform.position = Vector2.MoveTowards(mTransform.transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, speed * Time.deltaTime * 2);
                    mTransform.GetComponent<SpriteRenderer>().color = Color.red;
                    break;
            }
        }
        else
        {
            if (mTransform.transform.position.x >= limitX1)
            {
                mTransform.transform.Translate(Vector2.left * speed * Time.deltaTime);
                randnum = Random.Range(5, 7);
            }
            if (mTransform.transform.position.x <= limitX2)
            {
                mTransform.transform.Translate(Vector2.right * speed * Time.deltaTime);
                randnum = Random.Range(7, 9);
            }
            if (mTransform.transform.position.y >= limitY1)
            {
                mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                mTransform.transform.Translate(Vector2.down * ((speed * Time.deltaTime) / 2));
                randnum = 7;
            }
            if (mTransform.transform.position.y <= limitY2)
            {
                mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                mTransform.transform.Translate(Vector2.up * ((speed * Time.deltaTime) / 2));
                randnum = 8;
            }
        }
    }
    public override void ChangeRute()
    {
        randnum = Random.Range(1, 25);
        Invoke("ChangeRute", Random.Range(1f, 2f));

    }
}
