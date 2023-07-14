using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyMovement : MonoBehaviour
{
    public int randnum;
    public float speed = 50;
    [SerializeField] Transform mTransform;
    [SerializeField] float limitX1;
    [SerializeField] float limitX2;
    [SerializeField] float limitY1;
    [SerializeField] float limitY2;
    void Start()
    {
        ChangeRute();
    }

    // Update is called once per frame
    void Update()
    {
        Movement(mTransform, limitX1, limitX2, limitY1, limitY2);

    }
    public virtual void Movement(Transform mTransform, float limitX1, float limitX2, float limitY1, float limitY2)
    {
        if (mTransform.transform.position.x < limitX1 && mTransform.transform.position.x > limitX2 && mTransform.transform.position.y < limitY1 && mTransform.transform.position.y > limitY2)
        {
            switch (randnum)
            {
                case 1:
                    mTransform.transform.Translate(Vector2.up * speed * Time.deltaTime);
                    break;
                case 2:
                    mTransform.transform.Translate(Vector2.down * speed * Time.deltaTime);
                    break;
                case 3:
                    mTransform.transform.Translate(Vector2.right * speed * Time.deltaTime);
                    break;
                case 4:
                    mTransform.transform.Translate(Vector2.left * speed * Time.deltaTime);
                    break;
                case 5:
                    mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.down * ((speed * Time.deltaTime) * Time.deltaTime / 2));
                    break;
                case 6:
                    mTransform.transform.Translate(Vector2.left * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.up * ((speed * Time.deltaTime) / 2));
                    break;
                case 7:
                    mTransform.transform.Translate(Vector2.right * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.down * ((speed * Time.deltaTime) / 2));
                    break;
                case 8:
                    mTransform.transform.Translate(Vector2.right * ((speed * Time.deltaTime) / 2));
                    mTransform.transform.Translate(Vector2.up * ((speed * Time.deltaTime) / 2));
                    break;
                default:
                    mTransform.transform.Translate(Vector2.right * speed * Time.deltaTime);
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
    public virtual void ChangeRute()
    {
        randnum = Random.Range(1, 9);
        Invoke("ChangeRute", Random.Range(1f, 2f));

    }
}