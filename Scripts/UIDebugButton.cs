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
	internal sealed class UIDebugButton : MonoBehaviour
	{
		//====================================================================================
		// 変数(SerializeField)
		//====================================================================================
		[SerializeField] private Button m_buttonUI = default;
		[SerializeField] private Text   m_textUI   = default;

		//====================================================================================
		// 関数
		//====================================================================================
		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( UDPData data )
		{
			SetDisp( data.Text, data.OnClick );
		}

		/// <summary>
		/// 表示を設定します
		/// </summary>
		public void SetDisp( string text, Action onClick )
		{
			m_buttonUI.onClick.RemoveAllListeners();
			m_buttonUI.onClick.AddListener( () => onClick() );

			m_textUI.text = text;
		}
	}
}