namespace Ransom
{
    public class GameManager : Singleton<GameManager>
    {
        #region Unity Callbacks
        private void OnEnable()
        {
            UpdateManager.OnUpdate      += OnUpdate;
            UpdateManager.OnFixedUpdate += OnFixedUpdate;
        }

        private void OnDisable()
        {
            UpdateManager.OnUpdate      -= OnUpdate;
            UpdateManager.OnFixedUpdate -= OnFixedUpdate;
        }

        private void OnFixedUpdate()
        {
            StaticTime.OnFixedUpdate();
            // Time.Instance.OnFixedUpdate();
        }

        private void OnUpdate()
        {
            StaticTime.OnUpdate();
            // Time.Instance.OnUpdate();
        }
        #endregion Unity Callbacks
    }
}
