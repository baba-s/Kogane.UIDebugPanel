using Kogane.Internal;
using System.Diagnostics;
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
	public sealed class UIDebugPanel : MonoBehaviour
	{
		//====================================================================================
		// 定数
		//====================================================================================
		private const string DISABLE_CONDITION_STRING = "GgBa4RS3NdhECfu8wiUbH3wxpiRRXPja";

		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private GameObject    m_closeBaseUI   = default;
		[SerializeField] private GameObject    m_openBaseUI    = default;
		[SerializeField] private Button        m_closeButtonUI = default;
		[SerializeField] private Button        m_openButtonUI  = default;
		[SerializeField] private LayoutGroup   m_layoutUI      = default;
		[SerializeField] private UIDebugButton m_buttonUI      = default;
		[SerializeField] private CanvasGroup   m_canvasGroup   = default;
		[SerializeField] private GameObject    m_root          = default;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 初期化される時に呼び出されます
		/// </summary>
		private void Awake()
		{
#if DISABLE_UNI_UI_DEBUG_PANEL
			Destroy( gameObject );
#else
			m_closeButtonUI.onClick.AddListener( () => SetState( false ) );
			m_openButtonUI.onClick.AddListener( () => SetState( true ) );
#endif
		}

#if DISABLE_UNI_UI_DEBUG_PANEL
#else
		/// <summary>
		/// 開始する時に呼び出されます
		/// </summary>
		private void Start()
		{
			m_root.SetActive( true );
			m_openBaseUI.SetActive( false );
			m_closeBaseUI.SetActive( true );

			SetState( false );
		}
#endif

		/// <summary>
		/// ステートを設定します
		/// </summary>
#if DISABLE_UNI_UI_DEBUG_PANEL
		[Conditional( DISABLE_CONDITION_STRING )]
#endif
		private void SetState( bool isOpen )
		{
			m_openBaseUI.SetActive( isOpen );
			m_closeBaseUI.SetActive( !isOpen );
		}

		/// <summary>
		/// 表示するかどうかを設定します
		/// </summary>
#if DISABLE_UNI_UI_DEBUG_PANEL
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
#if DISABLE_UNI_UI_DEBUG_PANEL
		[Conditional( DISABLE_CONDITION_STRING )]
#endif
		public void SetDisp( params UDPData[] list )
		{
			foreach ( Transform n in m_layoutUI.transform )
			{
				Destroy( n.gameObject );
			}

			m_buttonUI.gameObject.SetActive( true );

			for ( int i = 0; i < list.Length; i++ )
			{
				var data = list[ i ];
				var obj  = Instantiate( m_buttonUI, m_layoutUI.transform );

				obj.SetDisp( data );
			}

			m_buttonUI.gameObject.SetActive( false );
		}
	}
}