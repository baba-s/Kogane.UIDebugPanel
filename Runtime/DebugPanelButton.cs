using System;
using UnityEngine;
using UnityEngine.UI;

namespace Kogane.Internal
{
    /// <summary>
    /// デバッグボタンの UI を管理するクラス
    /// </summary>
    [AddComponentMenu( "" )]
    [DisallowMultipleComponent]
    internal sealed class DebugPanelButton : MonoBehaviour
    {
        //====================================================================================
        // 変数(SerializeField)
        //====================================================================================
        [SerializeField] private Button m_buttonUI;
        [SerializeField] private Text   m_textUI;

        //====================================================================================
        // 関数
        //====================================================================================
        /// <summary>
        /// 表示を設定します
        /// </summary>
        public void Setup( DebugPanelData data )
        {
            Setup( data.Text, data.OnClick );
        }

        /// <summary>
        /// 表示を設定します
        /// </summary>
        public void Setup( string text, Action onClick )
        {
            m_buttonUI.onClick.RemoveAllListeners();
            m_buttonUI.onClick.AddListener( () => onClick() );

            m_textUI.text = text;
        }
    }
}