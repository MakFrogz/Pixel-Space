using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerScriptableObject _playerScriptableObject;
    [SerializeField] private AudioClip _dodgeSound;

    private Animator _animator;
    private Rigidbody2D _shipRigidbody2D;
    private SpriteRenderer _spriteRenderer;
    private TrailRenderer _trailRenderer;

    private float _speed;
    private Vector3 _direction;
    private bool _canDodge;

    private PlayerShootController _playerShootController;
    private PlayerHealthController _playerHealthController;
    private PlayerEnergyController _playerEnergyController;

    void Awake()
    {

        _trailRenderer = GetComponentInChildren<TrailRenderer>();
        _shipRigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();

        _playerShootController = GetComponent<PlayerShootController>();
        _playerHealthController = GetComponent<PlayerHealthController>();
        _playerEnergyController = GetComponent<PlayerEnergyController>();

        _speed = _playerScriptableObject.Speed;
        _canDodge = true;

        _trailRenderer.emitting = false;
        
    }

    void Update()
    {
        MovementInput();
    }



    private void FixedUpdate()
    {
        Move();
        FlipShip();
    }

    public void OnMove(InputAction.CallbackContext callbackContext)
    {
        _direction = callbackContext.ReadValue<Vector2>();
    }

    private void MovementInput()
    {
        float yBounds = Background.Instance.GetBackgroundHeigth() - (_spriteRenderer.bounds.size.y / 2);
        float xBounds = Background.Instance.GetBackgroundWidth() - (_spriteRenderer.bounds.size.x / 2);
        if (transform.position.y >= yBounds)
        {
            transform.position = new Vector3(transform.position.x, yBounds, 0f);
        }else if(transform.position.y <= -yBounds)
        {
            transform.position = new Vector3(transform.position.x, -yBounds, 0f);
        }

        float xClamp = Mathf.Clamp(transform.position.x ,-xBounds, xBounds);
        transform.position = new Vector3(xClamp, transform.position.y, 0f);
    }

    private void Move()
    {
        _shipRigidbody2D.velocity = (_direction.normalized * _speed);
        bool hasHorizontalVelocity = Mathf.Abs(_shipRigidbody2D.velocity.x) > Mathf.Epsilon;
        _animator.SetBool("isTurn", hasHorizontalVelocity);
    }

    private void FlipShip()
    {
        _spriteRenderer.flipX = !(Mathf.Sign(_shipRigidbody2D.velocity.x) >= Mathf.Epsilon);
    }

   
    public void SpeedBoostActive(float speedUp)
    {
        if(_speed < _playerScriptableObject.MaxSpeed)
        {
            _speed += speedUp;

        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (!context.performed)
        {
            return;
        }
        if (_playerEnergyController.CurrentEnergy >= _playerScriptableObject.DodgeCost && _canDodge)
        {
            AudioManager.Instance.PlaySFX(_dodgeSound);
            _canDodge = false;
            _playerEnergyController.CurrentEnergy -= _playerScriptableObject.DodgeCost;
            _playerHealthController.IsInvulnerable = true;
            _trailRenderer.emitting = true;
            _speed *= _playerScriptableObject.DodgeMultiplySpeed;
            StartCoroutine("DodgeRoutine");
            _playerEnergyController.StartEnergyRestore();
        }
    }

    private IEnumerator DodgeRoutine()
    {
        yield return new WaitForSeconds(0.15f);
        _speed /= _playerScriptableObject.DodgeMultiplySpeed;
        _trailRenderer.emitting = false;
        _playerHealthController.IsInvulnerable = false;
        yield return new WaitForSeconds(0.2f);
        _canDodge = true;
    }

}
