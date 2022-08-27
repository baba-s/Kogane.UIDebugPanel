﻿// ReSharper disable RedundantUsingDirective
// ReSharper disable RedundantNameQualifier
// ReSharper disable UnusedMember.Local
// ReSharper disable NotAccessedField.Local

using System.Diagnostics;
using Kogane.Internal;
using UnityEngine;
using UnityEngine.UI;

#pragma warning disable 0649
#pragma warning disable 0414

namespace Kogane
{
    /// <summary>
    /// デバッグパネルの UI を管理するクラス
    /// </summary>
    [AddComponentMenu( "" )]
    [DisallowMultipleComponent]
    public sealed class DebugPanel : MonoBehaviour
    {
        //====================================================================================
        // 定数
        //====================================================================================
        private const string DISABLE_CONDITION_STRING = "GgBa4RS3NdhECfu8wiUbH3wxpiRRXPja";

        //====================================================================================
        // 変数(SerializeField)
        //====================================================================================
        [SerializeField] private GameObject       m_closeBaseUI;
        [SerializeField] private GameObject       m_openBaseUI;
        [SerializeField] private Button           m_closeButtonUI;
        [SerializeField] private Button           m_openButtonUI;
        [SerializeField] private LayoutGroup      m_layoutUI;
        [SerializeField] private DebugPanelButton m_buttonUI;
        [SerializeField] private CanvasGroup      m_canvasGroup;
        [SerializeField] private GameObject       m_root;

        //====================================================================================
        // 変数(static)
        //====================================================================================
        private static bool m_isOpen;

        //====================================================================================
        // 関数
        //====================================================================================
        /// <summary>
        /// 初期化される時に呼び出されます
        /// </summary>
        private void Awake()
        {
#if KOGANE_DISABLE_UI_DEBUG_PANEL
            Destroy( gameObject );
#else
            m_closeButtonUI.onClick.AddListener( () => SetState( false ) );
            m_openButtonUI.onClick.AddListener( () => SetState( true ) );
#endif
        }

#if KOGANE_DISABLE_UI_DEBUG_PANEL
#else
        /// <summary>
        /// 開始する時に呼び出されます
        /// </summary>
        private void Start()
        {
            m_root.SetActive( true );
            m_openBaseUI.SetActive( false );
            m_closeBaseUI.SetActive( true );

            SetState( m_isOpen );
        }
#endif

        /// <summary>
        /// ステートを設定します
        /// </summary>
#if KOGANE_DISABLE_UI_DEBUG_PANEL
        [Conditional( DISABLE_CONDITION_STRING )]
#endif
        private void SetState( bool isOpen )
        {
            m_isOpen = isOpen;
            m_openBaseUI.SetActive( isOpen );
            m_closeBaseUI.SetActive( !isOpen );
        }

        /// <summary>
        /// 表示するかどうかを設定します
        /// </summary>
#if KOGANE_DISABLE_UI_DEBUG_PANEL
        [Conditional( DISABLE_CONDITION_STRING )]
#endif
        public void SetVisible( bool isVisible )
        {
            var alpha = isVisible ? 1 : 0;
            m_canvasGroup.alpha = alpha;
        }

        /// <summary>
        /// 表示を設定します
        /// </summary>
#if KOGANE_DISABLE_UI_DEBUG_PANEL
        [Conditional( DISABLE_CONDITION_STRING )]
#endif
        public void Setup( params DebugPanelData[] list )
        {
            foreach ( Transform n in m_layoutUI.transform )
            {
                Destroy( n.gameObject );
            }

            m_buttonUI.gameObject.SetActive( true );

            for ( var i = 0; i < list.Length; i++ )
            {
                var data = list[ i ];
                var obj  = Instantiate( m_buttonUI, m_layoutUI.transform );

                obj.Setup( data );
            }

            m_buttonUI.gameObject.SetActive( false );
        }

        //====================================================================================
        // 関数(static)
        //====================================================================================
        /// <summary>
        /// ゲーム起動時に呼び出されます
        /// </summary>
#if KOGANE_DISABLE_UI_DEBUG_PANEL
#else
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.BeforeSceneLoad )]
        private static void RuntimeInitializeOnLoadMethod()
        {
            m_isOpen = false;
        }
#endif
    }
}