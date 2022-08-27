using UnityEngine;
using UnityEngine.EventSystems;

namespace Kogane.Internal
{
    /// <summary>
    /// UI をドラッグできるようにするコンポーネント
    /// </summary>
    [AddComponentMenu( "" )]
    [DisallowMultipleComponent]
    internal sealed class Draggable
        : MonoBehaviour,
          IDragHandler
    {
        //====================================================================================
        // 変数(SerializeField)
        //====================================================================================
        [SerializeField][HideInInspector] private RectTransform m_rectTransform;

        //====================================================================================
        // 変数
        //====================================================================================
        private static Vector3? m_position;

        //====================================================================================
        // 関数
        //====================================================================================
        /// <summary>
        /// リセットされる時に呼び出されます
        /// </summary>
        private void Reset()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// Awake -> OnEnable の後に呼び出されます
        /// </summary>
        private void Start()
        {
            // Awake だと位置が正しく反映されなかったので Start で反映しています
            if ( m_position == null ) return;
            m_rectTransform.position = m_position.Value;
        }

        /// <summary>
        /// ドラッグ中に呼び出されます
        /// </summary>
        public void OnDrag( PointerEventData e )
        {
            var position = m_rectTransform.position;
            position += new Vector3( e.delta.x, e.delta.y );

            m_rectTransform.position = position;
            m_position               = position;
        }

        //====================================================================================
        // 関数(static)
        //====================================================================================
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            m_position = null;
        }
    }
}