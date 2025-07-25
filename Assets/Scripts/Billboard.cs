using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private Transform parent;
    [SerializeField] private SpriteRenderer spriteRenderer;


    public Sprite front;
    public Sprite back;
    public Sprite side;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        cam = Camera.main.transform;
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        LookAtCamera();
        ChangeSpriteFace();
    }

    private void LookAtCamera()
    {
        transform.forward = -cam.forward;
    }

    private void ChangeSpriteFace()
    {
        var rotY = parent.eulerAngles.y;
        

        if (rotY < 45 || rotY > 315)
        {
            spriteRenderer.sprite = back;
            spriteRenderer.flipX = false;
        }
        else if (rotY < 135)
        {
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = false;
        } 
        else if (rotY < 225)
        {
            spriteRenderer.sprite = front;
            spriteRenderer.flipX = false;
        }
        else if(rotY <= 315)
        {
            spriteRenderer.sprite = side;
            spriteRenderer.flipX = true;
        }

    }
}
