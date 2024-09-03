using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class Movement : MonoBehaviour
    {
        //octothorpe = # = Hash
        #region Variables
        //move direction that the player will be heading
        [SerializeField, Header("This is a title"), Space(16), Tooltip("Hover Description")]
        Vector3 _moveDirection = Vector3.zero;

        //the movement speeds such as walk run
        [SerializeField] float _moveSpeed, _walk = 5, _sprint = 10, _crouch = 2.5f, _jump = 8;

        //how the player is going to not float away
        [SerializeField] float _gravity = 20;

        //a way to calculate physics
        [SerializeField] CharacterController _characterController;

        #endregion
        #region Function
        private void Awake()
        {
            //assign a value to our reference by getting
            //this object that the script is attached to
            //get a component on this object called Character Controller
            _characterController = this.GetComponent<CharacterController>();
            _moveSpeed = _walk;
            this.enabled = true;
        }
        private void MovePlayer()
        {
            if( _characterController != null ) 
            {
                if(_characterController.isGrounded)
                {
                    // If shift is pressed, sprint
                    if (Input.GetKey(KeyCode.LeftShift))
                    {
                        _moveSpeed = _sprint;
                    }
                    // If control is pressed slow to crouch speed
                    else if (Input.GetKey(KeyCode.LeftControl))
                    {
                        _moveSpeed = _crouch;
                    }
                    // If neither is pressed move at walk speed
                    else
                    {
                        _moveSpeed = _walk;
                    }

                    _moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    _moveDirection = transform.TransformDirection(_moveDirection);
                    _moveDirection *= _moveSpeed;

                    if (Input.GetButton("Jump"))
                    {
                        _moveDirection.y = _jump;
                    }
                }
                _moveDirection.y -= _gravity * Time.deltaTime;
                _characterController.Move( _moveDirection * Time.deltaTime);
            }   
        }
        private void Update()
        {
            if (GameManager.instance.currentGameState == GameState.Game)
            {
                MovePlayer();
            }
        }
        #endregion
    }
}
