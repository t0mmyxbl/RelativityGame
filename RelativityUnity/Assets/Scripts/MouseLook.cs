using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.FirstPerson
{
    [Serializable]
    public class MouseLook
    {
        private Vector2 mouseLook;
        private Vector2 smoothV;
        public float XSensitivity = 2f;
        public float YSensitivity = 2f;
        public bool clampVerticalRotation = true;
        public float MinimumX = -90F;
        public float MaximumX = 90F;
        public bool smooth;
        public float smoothTime = 5f;
        public bool lockCursor = true;
        public bool isRotated = false;
        public float playerRotation = 0;
        public bool isFlipped = false;
        private float zRot;

        public Quaternion m_CharacterTargetRot;
        public Quaternion m_CameraTargetRot;
        private bool m_cursorIsLocked = true;

        public void Init(Transform character, Transform camera)
        {
            m_CharacterTargetRot = character.localRotation;
            m_CameraTargetRot = camera.localRotation;
        }


        public void LookRotation(Transform character, Transform camera)
        {
            Vector2 mouseDirection = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
            mouseDirection = Vector2.Scale(mouseDirection, new Vector2(XSensitivity * smoothTime, YSensitivity * smoothTime));
            smoothV.x = Mathf.Lerp(smoothV.x, mouseDirection.x, 1f / smoothTime);
            smoothV.y = Mathf.Lerp(smoothV.y, mouseDirection.y, 1f / smoothTime);

            mouseLook += smoothV;

            if (isFlipped)
            {


                if (zRot > 179)
                {
                    zRot = 180;

                }
                else
                {
                    zRot += 180 * (Time.deltaTime * 2);
                }

                mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 70f);
                character.transform.localRotation = Quaternion.AngleAxis(-mouseLook.x, Vector3.up);
                character.transform.localRotation *= Quaternion.AngleAxis(zRot, Vector3.forward);
                camera.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

            }
            else
            {
                if (character.transform.localRotation.z == 0)
                {
                    mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 70f);
                    character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, character.transform.up);
                    camera.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);

                }
                else
                {
                    if (zRot < 0)
                    {
                        zRot = 0;
                    }
                    else
                    {
                        zRot -= 180 * (Time.fixedDeltaTime * 2);
                    }


                    mouseLook.y = Mathf.Clamp(mouseLook.y, -70f, 70f);
                    character.transform.localRotation = Quaternion.AngleAxis(mouseLook.x, Vector3.up);
                    character.transform.localRotation *= Quaternion.AngleAxis(zRot, Vector3.forward);
                    camera.transform.localRotation = Quaternion.AngleAxis(-mouseLook.y, Vector3.right);
                }

            }

            //float yRot = CrossPlatformInputManager.GetAxis("Mouse X") * XSensitivity;
            //float xRot = CrossPlatformInputManager.GetAxis("Mouse Y") * YSensitivity;

            //m_CharacterTargetRot *= Quaternion.Euler(0f, yRot, 0f);
            //m_CameraTargetRot *= Quaternion.Euler(-xRot, 0f, 0f);



            //if (clampVerticalRotation)
            //    m_CameraTargetRot = ClampRotationAroundXAxis(m_CameraTargetRot);

            //if (smooth)
            //{
            //    character.localRotation = Quaternion.Slerp(character.localRotation, m_CharacterTargetRot,
            //        smoothTime * Time.deltaTime);
            //    camera.localRotation = Quaternion.Slerp(camera.localRotation, m_CameraTargetRot,
            //        smoothTime * Time.deltaTime);
            //}
            //else
            //{
            //    character.rotation = m_CharacterTargetRot;
            //    camera.rotation = m_CameraTargetRot;
            //}

            //if (isFlipped)
            //{
            //    if (zRot > 179)
            //    {
            //        zRot = 180;
            //    }
            //    else
            //    {
            //        zRot += 180 * (Time.deltaTime * 2);
            //    }

            //    character.localRotation *= Quaternion.AngleAxis(zRot, Vector3.forward);

            //}
            //else
            //{
            //    if (character.transform.localRotation.z < 0)
            //    {
            //        zRot = 0;
            //    }
            //    else
            //    {
            //        if (zRot < 0)
            //        {
            //            zRot = 0;
            //        }
            //        else
            //        {
            //            zRot -= 180 * (Time.deltaTime * 2);
            //        }
            //    }
            //    character.localRotation *= Quaternion.AngleAxis(zRot, Vector3.forward);
            //}


            UpdateCursorLock();
        }

        public void SetCursorLock(bool value)
        {
            lockCursor = value;
            if(!lockCursor)
            {//we force unlock the cursor if the user disable the cursor locking helper
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void UpdateCursorLock()
        {
            //if the user set "lockCursor" we check & properly lock the cursos
            if (lockCursor)
                InternalLockUpdate();
        }

        private void InternalLockUpdate()
        {
            if(Input.GetKeyUp(KeyCode.Escape))
            {
                m_cursorIsLocked = false;
            }
            else if(Input.GetMouseButtonUp(0))
            {
                m_cursorIsLocked = true;
            }

            if (m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else if (!m_cursorIsLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        Quaternion ClampRotationAroundXAxis(Quaternion q)
        {
            q.x /= q.w;
            q.y /= q.w;
            q.z /= q.w;
            q.w = 1.0f;

            float angleX = 2.0f * Mathf.Rad2Deg * Mathf.Atan(q.x);

            angleX = Mathf.Clamp(angleX, MinimumX, MaximumX);

            q.x = Mathf.Tan(0.5f * Mathf.Deg2Rad * angleX);

            return q;
        }

    }
}
