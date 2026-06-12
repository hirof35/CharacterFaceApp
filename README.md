# CharacterFaceApp (WPF キャラクター表情切り替えアプリ)

WPF (Windows Presentation Foundation) と .NET 9 を用いて開発された、ボタン操作によってキャラクターの表情（通常・笑う・怒る・泣く）を動的に切り替えるデスクトップアプリケーションです。
<img width="476" height="538" alt="スクリーンショット 2026-06-12 113306" src="https://github.com/user-attachments/assets/671bf934-d589-48b4-a600-d838204c09c9" />

構造科学的アプローチに基づき、UI定義（XAML）と制御ロジック（C#）を明確に分離し、拡張性と保守性を担保した疎結合なアーキテクチャで実装しています。

## 🚀 特徴

- **リソースの最適化管理**: 
  画像資産（PNG）をプロジェクト内の内部リソース（`Resource`）としてアセンブリに埋め込み、`pack://application:,,,/`（パックURI）スキームを用いて高速かつ安全にロードします。
- **DRY原則に基づく共通化ロジック**: 
  引数によって動的にリソースパスを生成する共通メソッド `ChangeExpression(string fileName)` を実装。コードの冗長性を徹底的に排除し、新しい表情（画像）の追加が容易な構造にしています。
- **堅牢な例外処理**: 
  IOトラブルやリソース欠損によるアプリケーションの異常終了を防ぐため、画像ロード部には `try-catch` による例外ハンドリングを配備しています。

## 🛠️ 技術スタック

- **フレームワーク**: .NET 9.0 (WPF) / SDKスタイルプロジェクト
- **開発言語**: C# 13 / XAML
- **開発環境**: Visual Studio 2022
- **ターゲットプラットフォーム**: Windows 10 / 11

## 📁 内部構造・フォルダー構成

```text
CharacterFaceApp/
├── App.xaml
├── CharacterFaceApp.csproj  # .NET 9 SDKスタイル定義
├── MainWindow.xaml          # UI・レイアウト定義（Grid / StackPanel）
├── MainWindow.xaml.cs       # 状態制御ロジック（イベントハンドラー・URIロード）
└── Images/                  # キャラクターグラフィック資産（ビルドアクション: Resource）
    ├── normal.png           # 通常
    ├── laugh.png            # 笑う
    ├── angry.png            # 怒る
    └── cry.png              # 泣く
💻 核心コードの実装特性
1. 統一リソースローダー (C#)
文字列引数を受け取り、オブジェクトの参照を動的に切り替えることで、ミリタリーシステムにおけるモードセレクターのような確実な状態遷移を実現しています。

C#
private void ChangeExpression(string fileName)
{
    try
    {
        string uriPath = $"pack://application:,,,/Images/{fileName}";
        CharacterImage.Source = new BitmapImage(new Uri(uriPath));
    }
    catch (Exception ex)
    {
        MessageBox.Show($"画像の読み込みに失敗しました: {ex.Message}");
    }
}
2. 応答性に優れたUIレイアウト (XAML)
Grid による縦方向の領域分割（スターサイズ指定 * と Auto の組み合わせ）と StackPanel による横並び配置を採用し、ウィンドウのトリミングやサイズ変更に対しても表示崩れが起きないコンポーネント配置を行っています。

XML
<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>

    <Image x:Name="CharacterImage" Grid.Row="0" Margin="20" Stretch="Uniform" />
    
    </Grid>
📦 セットアップと実行方法
リポジトリをクローンまたはダウンロードします。

Visual Studio で CharacterFaceApp.csproj を開きます。

Images フォルダー内に任意のキャラクター画像（normal.png, laugh.png, angry.png, cry.png）を配置します。

画像のプロパティから ビルドアクションを「Resource」 に設定します。

ソリューションをビルド（またはリビルド）し、F5 キーで実行します。

💡 今後の拡張展望
DispatcherTimer を用いた非同期バックグラウンド処理による「自動瞬き（まばたき）機能」の追加。

表情状態の遷移（怒り状態など）に連動して、UI全体にマトリクス的なアニメーション振動を付与する Storyboard の実装。
