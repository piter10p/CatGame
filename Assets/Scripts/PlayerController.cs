using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float MoveSpeed = 1f;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private float _moveHorizontal = 0f;
    private bool _isCharacterRightSided = true;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _moveHorizontal = Input.GetAxisRaw("Horizontal");
        _animator.SetFloat("Speed", Mathf.Abs(_moveHorizontal));

        UpdateFlip();
    }

    private void FixedUpdate()
    {
        if (_moveHorizontal > 0.1f || _moveHorizontal < -0.1f)
        {
            _rigidbody.AddForce(new Vector2(_moveHorizontal * MoveSpeed, 0f), ForceMode2D.Impulse);
        }
    }

    private void UpdateFlip()
    {
        if(_isCharacterRightSided && _moveHorizontal < -0.1f ||
            !_isCharacterRightSided && _moveHorizontal > 0.1f)
        {
            _isCharacterRightSided = !_isCharacterRightSided;
            var scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
        }
    }
}
