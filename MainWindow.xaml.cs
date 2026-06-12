using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace CharacterFaceApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 起動時は通常の表情を表示
            ChangeExpression("normal.png");
        }

        // 通常ボタン
        private void BtnNormal_Click(object sender, RoutedEventArgs e)
        {
            ChangeExpression("normal.png");
        }

        // 笑うボタン
        private void BtnLaugh_Click(object sender, RoutedEventArgs e)
        {
            ChangeExpression("laugh.png");
        }

        // 怒るボタン
        private void BtnAngry_Click(object sender, RoutedEventArgs e)
        {
            ChangeExpression("angry.png");
        }
        // 泣くボタン
        private void BtnCry_Click(object sender, RoutedEventArgs e)
        {
            ChangeExpression("cry.png");
        }

        // 画像を切り替える共通メソッド
        private void ChangeExpression(string fileName)
        {
            try
            {
                // WPFの内部リソース（Imagesフォルダ）から画像を読み込むURIを指定
                string uriPath = $"pack://application:,,,/Images/{fileName}";
                CharacterImage.Source = new BitmapImage(new Uri(uriPath));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"画像の読み込みに失敗しました: {ex.Message}");
            }
        }
    }
}
