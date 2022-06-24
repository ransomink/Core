namespace Ransom
{
    public class GameManager : Singleton<GameManager>
    {
        #region Unity Callbacks
        protected virtual void OnEnable()
        {
            UpdateManager.OnFixedUpdate += OnFixedUpdate;
            UpdateManager.OnUpdate      += OnUpdate;
        }

        protected virtual void OnDisable()
        {
            UpdateManager.OnFixedUpdate -= OnFixedUpdate;
            UpdateManager.OnUpdate      -= OnUpdate;
        }

        protected virtual void OnFixedUpdate()
        {
            // Time.Instance.OnFixedUpdate();
            StaticTime.OnFixedUpdate();
        }

        protected virtual void OnUpdate()
        {
            // Time.Instance.OnUpdate();
            StaticTime.OnUpdate();
        }
        #endregion Unity Callbacks
    }
}
