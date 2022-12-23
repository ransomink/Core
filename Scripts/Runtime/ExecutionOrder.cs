namespace Ransom
{
    public class ExecutionOrder : Singleton<ExecutionOrder>
    {
        #region Unity Callbacks
        protected virtual void OnEnable()
        {
            UpdateDispatcher.OnFixedUpdate += OnFixedUpdate;
            UpdateDispatcher.OnUpdate      += OnUpdate;
        }

        protected virtual void OnDisable()
        {
            UpdateDispatcher.OnFixedUpdate -= OnFixedUpdate;
            UpdateDispatcher.OnUpdate      -= OnUpdate;
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

        protected virtual void OnDestroy()
        {
            StaticTime.OnDestroy();
        }
        #endregion Unity Callbacks
    }
}
