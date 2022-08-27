using System;

namespace Kogane
{
    /// <summary>
    /// デバッグパネルのデータを管理するクラス
    /// </summary>
    public sealed class DebugPanelData
    {
        //====================================================================================
        // プロパティ
        //====================================================================================
        public string Text    { get; }
        public Action OnClick { get; }

        //====================================================================================
        // 関数
        //====================================================================================
        public DebugPanelData
        (
            string text,
            Action onClick
        )
        {
            Text    = text;
            OnClick = onClick;
        }
    }
}