namespace Ransom
{
    /// <summary>
    /// A static wrapper for Unity's Time class.
    /// </summary>
    public static class StaticTime
    {
        #region Properties
        /// <summary>
        /// The scale at which time passes.
        /// </summary>
        public static float TimeScale { get; set; }

        /// <summary>
        /// The total number of frames since the start of the game (Read Only).
        /// </summary>
        public static int   FrameCount { get; private set; }

        /// <summary>
        /// The time since this frame started (Read Only). This is the time in seconds since the last non-additive scene has finished loading.
        /// </summary>
        public static float TimeSinceLevelLoad { get; private set; }

        /// <summary>
        /// The real time in seconds since the game started (Read Only).
        /// </summary>
        public static float RealtimeSinceStartup { get; private set; }

        /// <summary>
        /// The time at the beginning of this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public static float ScaledTime { get; private set; }

        /// <summary>
        /// The completion time in seconds since the last frame (Read Only).
        /// </summary>
        public static float DeltaTime { get; private set; }

        /// <summary>
        /// A smoothed out Time.deltaTime (Read Only).
        /// </summary>
        public static float SmoothDeltaTime { get; private set; }

        /// <summary>
        /// The maximum value of Time.deltaTime in any given frame. This is a time in seconds that limits the increase of Time.time between two frames.
        /// </summary>
        public static float MaximumDeltaTime { get; set; }

        /// <summary>
        /// The maximum time a frame can spend on particle updates. If the frame takes longer than this, then updates are split into multiple smaller updates.
        /// </summary>
        public static float MaximumParticleDeltaTime { get; set; }

        /// <summary>
        /// The time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public static float FixedTime { get; private set; }

        /// <summary>
        /// The interval in seconds at which physics and other fixed frame rate updates (like MonoBehaviour's FixedUpdate) are performed.
        /// </summary>
        public static float FixedDeltaTime { get; set; }

        /// <summary>
        /// The timeScale-independent time for this frame (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public static float UnscaledTime { get; private set; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last frame to the current one (Read Only).
        /// </summary>
        public static float UnscaledDeltaTime { get; private set; }

        /// <summary>
        /// The TimeScale-independent time the latest FixedUpdate has started (Read Only). This is the time in seconds since the start of the game.
        /// </summary>
        public static float FixedUnscaledTime { get; private set; }

        /// <summary>
        /// The timeScale-independent interval in seconds from the last fixed frame to the current one (Read Only).
        /// </summary>
        public static float FixedUnscaledDeltaTime { get; private set; }
        #endregion Properties

        #region Unity Callbacks
        public static void Reset()
        {
            TimeScale = 0;
            FrameCount = 0;
            TimeSinceLevelLoad = 0;
            RealtimeSinceStartup = 0;

            ScaledTime = 0;
            DeltaTime = 0;
            SmoothDeltaTime = 0;
            MaximumDeltaTime = 0;
            MaximumParticleDeltaTime = 0;

            FixedTime = 0;
            FixedDeltaTime = 0;

            UnscaledTime = 0;
            UnscaledDeltaTime = 0;
            
            FixedUnscaledTime = 0;
            FixedUnscaledDeltaTime = 0;
        }

        public static void OnFixedUpdate()
        {
            FixedTime              = UnityEngine.Time.fixedTime;
            FixedDeltaTime         = UnityEngine.Time.fixedDeltaTime;
            FixedUnscaledTime      = UnityEngine.Time.fixedUnscaledTime;
            FixedUnscaledDeltaTime = UnityEngine.Time.fixedUnscaledDeltaTime;
        }
        
        public static void OnUpdate()
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

        public static void OnDestroy()
        {
            Reset();
        }
        #endregion Unity Callbacks
    }
}
