using UnityEngine;

namespace Ransom
{
    [CreateAssetMenu(
        fileName = Folder.NAME_TIME + Folder.NAME_MANAGER, 
        menuName = Folder.SO + Folder.BASE_MANAGER + Folder.NAME_TIME, 
        order    = 0
    )]
    /// <summary>
    /// A ScriptableObject wrapper for Unity's Time class.
    /// </summary>
    public class SO_Time : Manager
    {
        #region Fields
        [Header("TIME")]
        [ReadOnly][SerializeField] private float _timeScale;
        [ReadOnly][SerializeField] private int   _frameCount;
        [ReadOnly][SerializeField] private float _timeSinceLevelLoad;
        [ReadOnly][SerializeField] private float _realtimeSinceStartup;

        [Header("SCALED")]
        [ReadOnly][SerializeField] private float _time;
        [ReadOnly][SerializeField] private float _deltaTime;
        [ReadOnly][SerializeField] private float _smoothDeltaTime;
        [ReadOnly][SerializeField] private float _maximumDeltaTime;
        [ReadOnly][SerializeField] private float _maximumParticleDeltaTime;
        [Space]
        [ReadOnly][SerializeField] private float _fixedTime;
        [ReadOnly][SerializeField] private float _fixedDeltaTime;


        [Header("UNSCALED")]
        [ReadOnly][SerializeField] private float _unscaledTime;
        [ReadOnly][SerializeField] private float _unscaledDeltaTime;
        [Space]
        [ReadOnly][SerializeField] private float _fixedUnscaledTime;
        [ReadOnly][SerializeField] private float _fixedUnscaledDeltaTime;
        #endregion Fields

        #region Properties
        /// <summary>
        /// The scale at which time passes.
        /// </summary>
        public float TimeScale { get => _timeScale; set => _timeScale = value; }

        /// <summary>
        /// The total number of frames since the start of the game (Read Only).
        /// </summary>
        public int   FrameCount { get => _frameCount; private set => _frameCount = value; }

        /// <summary>
        /// The time since this frame started (Read Only). This is the time in seconds since the last non-additive scene has finished loading.
        /// </summary>
        public float TimeSinceLevelLoad { get => _timeSinceLevelLoad; private set => _timeSinceLevelLoad = value; }

        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// </summary>
        public float RealtimeSinceStartup { get => _realtimeSinceStartup; private set => _realtimeSinceStartup = value; }

        /// <summary>
        /// The time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float ScaledTime { get => _time; private set => _time = value; }

        /// <summary>
        /// The completion time in seconds since the last frame (Read Only).
        /// </summary>
        public float DeltaTime { get => _deltaTime; private set => _deltaTime = value; }

        /// <summary>
        /// A smoothed out Time.deltaTime (Read Only).
        /// </summary>
        public float SmoothDeltaTime { get => _smoothDeltaTime; private set => _smoothDeltaTime = value; }

        /// <summary>
        /// The maximum value of Time.deltaTime in any given frame. This is a time in seconds that limits the increase of Time.time between two frames.
        /// </summary>
        public float MaximumDeltaTime { get => _maximumDeltaTime; set => _maximumDeltaTime = value; }

        /// <summary>
        /// The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.
        /// </summary>
        public float MaximumParticleDeltaTime { get => _maximumParticleDeltaTime; set => _maximumParticleDeltaTime = value; }

        /// <summary>
        /// The time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedTime { get => _fixedTime; private set => _fixedTime = value; }

        /// <summary>
        /// The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's FixedUpdate) are performed.
        /// </summary>
        public float FixedDeltaTime { get => _fixedDeltaTime; set => _fixedDeltaTime = value; }

        /// <summary>
        /// The timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float UnscaledTime { get => _unscaledTime; private set => _unscaledTime = value; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public float UnscaledDeltaTime { get => _unscaledDeltaTime; private set => _unscaledDeltaTime = value; }

        /// <summary>
        /// The TimeScale-independent time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public float FixedUnscaledTime { get => _fixedUnscaledTime; private set => _fixedUnscaledTime = value; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last fixed frame to the current one (Read Only).
        /// </summary>
        public float FixedUnscaledDeltaTime { get => _fixedUnscaledDeltaTime; private set => _fixedUnscaledDeltaTime = value; }
        #endregion Properties

        #region Unity Callbacks
        private void Reset()
        {
            _timeScale = 0;
            _frameCount = 0;
            _timeSinceLevelLoad = 0;
            _realtimeSinceStartup = 0;

            _time = 0;
            _deltaTime = 0;
            _smoothDeltaTime = 0;
            _maximumDeltaTime = 0;
            _maximumParticleDeltaTime = 0;

            _fixedTime = 0;
            _fixedDeltaTime = 0;

            _unscaledTime = 0;
            _unscaledDeltaTime = 0;
            
            _fixedUnscaledTime = 0;
            _fixedUnscaledDeltaTime = 0;
        }

        public override void OnFixedUpdate()
        {
            FixedTime              = UnityEngine.Time.fixedTime;
            FixedDeltaTime         = UnityEngine.Time.fixedDeltaTime;
            FixedUnscaledTime      = UnityEngine.Time.fixedUnscaledTime;
            FixedUnscaledDeltaTime = UnityEngine.Time.fixedUnscaledDeltaTime;
        }

        public override void OnUpdate()
        {
            TimeScale                = UnityEngine.Time.timeScale;
            FrameCount               = UnityEngine.Time.frameCount;
            TimeSinceLevelLoad       = UnityEngine.Time.timeSinceLevelLoad;
            RealtimeSinceStartup     = UnityEngine.Time.realtimeSinceStartup;

            ScaledTime               = UnityEngine.Time.time;
            DeltaTime                = UnityEngine.Time.deltaTime;
            SmoothDeltaTime          = UnityEngine.Time.smoothDeltaTime;
            MaximumDeltaTime         = UnityEngine.Time.maximumDeltaTime;
            MaximumParticleDeltaTime = UnityEngine.Time.maximumParticleDeltaTime;
            
            UnscaledTime             = UnityEngine.Time.unscaledTime;
            UnscaledDeltaTime        = UnityEngine.Time.unscaledDeltaTime;
        }

        public override void OnDestroy()
        {
            Reset();
        }
        #endregion Unity Callbacks
    }
}
