using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

public class PlyaerCtl : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float tweenDuration = 0.3f;
    public bool a;

    private Rigidbody2D rb;
    private Collider2D touchCol;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        touchCol = GameObject.Find("Touch").GetComponent<Collider2D>();

    }

    private void Update()
    {

        // Touch
        if (Input.GetKeyDown(KeyCode.J) || (Input.GetKeyDown(KeyCode.Space)))
        {
            Debug.Log("����Touch");
            Bounds bounds = touchCol.bounds;

            // ����ײ���ڴ���һ����״����
            Collider2D[] colliders = Physics2D.OverlapBoxAll(bounds.center, bounds.size, 0f);

            // ������⵽����ײ��
            foreach (Collider2D collider in colliders)
            {
                if (collider.gameObject.tag == "Danmu")
                {
                    Debug.Log(collider.gameObject.name);

                    Danmu danmu = collider.gameObject.GetComponent<Danmu>();
                    if (danmu != null && danmu.gainEnergy)
                    {
                        Debug.Log("��ȡ����");
                    }

                    Destroy(collider.gameObject);

                }
            }
        }

        // ��ȡ����
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // �����ƶ�������ٶ�
        Vector2 movement = new Vector2(moveHorizontal, moveVertical).normalized * moveSpeed;

        // Ӧ���ƶ�
        rb.velocity = movement;

        // ���³���
        if (movement != Vector2.zero)
        {
            transform.up = movement;
        }

        // Tween �ƶ�
        if (movement.magnitude > 0)
        {
            transform.DOMove((Vector2)transform.position + movement, tweenDuration);
        }


    }
}
