using UnityEngine;

namespace Kogane.Internal
{
    /// <summary>
    /// セーフエリアに対応した uGUI のパネル
    /// </summary>
    [AddComponentMenu( "" )]
    [DisallowMultipleComponent]
    internal sealed class DebugPanelSafeArea : MonoBehaviour
    {
        //==============================================================================
        // 変数(SerializeField)
        //==============================================================================
        [SerializeField] private RectTransform m_rectTransform;

        //==============================================================================
        // 変数
        //==============================================================================
        private Rect m_currentArea;

        //==============================================================================
        // 関数
        //==============================================================================
        /// <summary>
        /// リセットされる時に呼び出されます
        /// </summary>
        private void Reset()
        {
            m_rectTransform = GetComponent<RectTransform>();
        }

        /// <summary>
        /// 有効になった時に呼び出されます
        /// </summary>
        private void OnEnable()
        {
            Apply( Screen.safeArea );
        }

        /// <summary>
        /// 適用します
        /// </summary>
        private void Apply( Rect area )
        {
            if ( m_rectTransform == null ) return;
            if ( m_currentArea == area ) return;

            m_rectTransform.anchoredPosition = Vector2.zero;
            m_rectTransform.sizeDelta        = Vector2.zero;

            var anchorMin = area.position;
            var anchorMax = area.position + area.size;
            anchorMin.x               /= Screen.width;
            anchorMin.y               /= Screen.height;
            anchorMax.x               /= Screen.width;
            anchorMax.y               /= Screen.height;
            m_rectTransform.anchorMin =  anchorMin;
            m_rectTransform.anchorMax =  anchorMax;

            m_currentArea = area;
        }
    }
}