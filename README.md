# Kogane UI Debug Panel

デバッグ用のボタンを簡単に実装できる UI

## 使用例

![2020-07-18_094542](https://user-images.githubusercontent.com/6134875/87840633-b0556180-c8db-11ea-8e44-884177d79577.png)

「UIDebugPanel」プレハブをシーンに配置して

```cs
using Kogane;
using UnityEngine;

public class Example : MonoBehaviour
{
    public UIDebugPanel m_debugPanelUI = default;
    public GameObject   m_gameObject   = default;

    private void Start()
    {
        m_debugPanelUI.Setup
        (
            new UDPData( "表示", () => m_gameObject.SetActive( true ) ),
            new UDPData( "非表示", () => m_gameObject.SetActive( false ) )
        );
    }
}
```

上記のようなスクリプトを記述することで

![19](https://user-images.githubusercontent.com/6134875/87840636-b1868e80-c8db-11ea-92c0-078e877ad7d1.gif)

使用することができます

![2020-07-18_094756](https://user-images.githubusercontent.com/6134875/87840638-b21f2500-c8db-11ea-8fc1-522864ae5a70.png)

`KOGANE_DISABLE_UI_DEBUG_PANEL` シンボルを定義することで UniUIDebugPanel を無効化できます  
リリースビルドから UniUIDebugPanel を除外したい場合などに定義します  
