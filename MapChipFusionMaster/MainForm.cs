using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapChipFusionMaster
{
    public partial class MainForm : Form
    {

        // ファイル名を保持するリスト
        List<string> selectedFiles = new List<string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "PNG files (*.png)|*.png", // pngファイルのみ選択できるようにフィルタを設定
                Multiselect = true // 複数のファイルを選択できるようにする
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 重複がないとき
                if(!checkBoxhasDuplicates.Checked)
                {
                    // 選択された各ファイルパスについて、すでにリストに存在しない場合のみ追加
                    foreach (string filePath in openFileDialog.FileNames)
                    {
                        if (!selectedFiles.Contains(filePath))
                        {
                            selectedFiles.Add(filePath);
                        }
                    }
                }
                else
                {
                    // 選択されたすべてのファイルパスをリストに追加
                    selectedFiles.AddRange(openFileDialog.FileNames);

                }

                // ListBoxの内容を更新
                UpdateImageListBox();
            }
        }

        private void UpdateImageListBox()
        {
            listBoxImages.Items.Clear(); // ListBoxをクリア

            foreach (string filePath in selectedFiles)
            {
                string fileName = Path.GetFileName(filePath); // ファイルパスからファイル名を取得
                listBoxImages.Items.Add(fileName); // ListBoxにファイル名を追加
            }

            if (selectedFiles.Count > 0)
            {
                // 最初の画像を読み込む
                using (Bitmap firstImage = new Bitmap(selectedFiles[0]))
                {
                    // 画像の横幅を取得し、それを文字列に変換してラベルに設定
                    string mismatchedImageFileWidth = CheckIfAllImagesHaveSameWidth(selectedFiles);
                    string mismatchedImageFileDpi = CheckIfAllImagesHaveSameDpi(selectedFiles);

                    if (mismatchedImageFileWidth != null)
                    {
                        labelImageWidth.Text = $"横幅：{firstImage.Width}＊横幅不一致";
                        labelImageWidth.ForeColor = Color.Red;
                    }
                    else
                    {
                        labelImageWidth.ForeColor = Color.Black;
                        labelImageWidth.Text = $"横幅：{firstImage.Width} 縦幅{firstImage.Height}";
                    }

                    if (mismatchedImageFileDpi != null)
                    {
                        labelImageDpi.Text = $"解像度：{firstImage.HorizontalResolution} x {firstImage.VerticalResolution}＊解像度不一致";
                        labelImageDpi.ForeColor = Color.Red;
                    }
                    else
                    {
                        labelImageDpi.ForeColor = Color.Black;
                        labelImageDpi.Text = $"解像度：{firstImage.HorizontalResolution} x {firstImage.VerticalResolution}";
                    }
                }
            }
            else
            {
                labelImageWidth.ForeColor = Color.Black;
                labelImageWidth.Text = $"横幅：";
                labelImageDpi.ForeColor = Color.Black;
                labelImageDpi.Text = $"解像度：";
            }

            // プレビューを更新
            listBoxImages_SelectedIndexChanged(listBoxImages, EventArgs.Empty);
        }

        // 重複削除
        private void checkBoxhasDuplicates_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBoxhasDuplicates.Checked) // チェックボックスがチェックされているか確認
            {
                List<string> newList = new List<string>(); // 重複がない新しいリストを作成

                foreach (string item in selectedFiles)
                {
                    if (!newList.Contains(item)) // 既にリストに存在するかどうかを確認
                    {
                        newList.Add(item); // まだリストに存在しなければ追加
                    }
                }

                selectedFiles = newList; // 既存のリストを新しいリストで置換

                // ListBoxの内容を更新
                UpdateImageListBox();
            }
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            // リストボックスで選択されているアイテムのインデックスを取得
            int selectedIndex = listBoxImages.SelectedIndex;

            if (selectedIndex != -1) // アイテムが選択されている場合
            {
                // リストボックスから選択されているアイテムを削除
                listBoxImages.Items.RemoveAt(selectedIndex);

                // 同じインデックスのアイテムをselectedFilesリストからも削除
                selectedFiles.RemoveAt(selectedIndex);

                UpdateImageListBox();
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            // selectedFilesリストをクリア
            selectedFiles.Clear();

            UpdateImageListBox();
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            // 選択されているアイテムのインデックスを取得
            int selectedIndex = listBoxImages.SelectedIndex;

            // 選択されているアイテムが存在し、かつ最初のアイテムではない場合
            if (selectedIndex > 0)
            {
                // 選択されているアイテムとその前のアイテムを入れ替える
                string selectedFile = selectedFiles[selectedIndex];
                selectedFiles[selectedIndex] = selectedFiles[selectedIndex - 1];
                selectedFiles[selectedIndex - 1] = selectedFile;

                // ListBoxの表示を更新
                UpdateImageListBox();

                // 同じアイテムを選択したままにする（位置が上に移動する）
                listBoxImages.SelectedIndex = selectedIndex - 1;
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            // 選択されているアイテムのインデックスを取得
            int selectedIndex = listBoxImages.SelectedIndex;

            // 選択されているアイテムが存在し、かつ最後のアイテムではない場合
            if (selectedIndex < listBoxImages.Items.Count - 1 && selectedIndex >= 0)
            {
                // 選択されているアイテムとその次のアイテムを入れ替える
                string selectedFile = selectedFiles[selectedIndex];
                selectedFiles[selectedIndex] = selectedFiles[selectedIndex + 1];
                selectedFiles[selectedIndex + 1] = selectedFile;

                // ListBoxの表示を更新
                UpdateImageListBox();

                // 同じアイテムを選択したままにする（位置が下に移動する）
                listBoxImages.SelectedIndex = selectedIndex + 1;
            }
        }

        private void listBoxImages_DragEnter(object sender, DragEventArgs e)
        {
            // ドラッグされたデータがファイルであれば、ドロップを許可
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
        }

        private void listBoxImages_DragDrop(object sender, DragEventArgs e)
        {
            // ドロップされたファイルのパスを取得
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // 重複がないとき
            if (!checkBoxhasDuplicates.Checked)
            {
                // ファイルがPNGで、かつまだリストに存在しなければ追加
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".png" && !selectedFiles.Contains(file))
                    {
                        selectedFiles.Add(file);
                    }
                }
            }
            else
            {
                // ファイルがPNGならばすべて追加
                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".png")
                    {
                        selectedFiles.Add(file);
                    }
                }
            }

            // ListBoxの内容を更新
            UpdateImageListBox();
        }

        private void listBoxImages_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (selectedFiles.Count <= 0)
            {
                pictureBoxPreview.Image = null;
                return;
            }

            // 選択されているアイテムのインデックスを取得
            int selectedIndex = listBoxImages.SelectedIndex;

            // インデックスが有効な範囲内であれば、そのアイテムのファイルを読み込み、pictureBoxPreviewに表示
            if (selectedIndex >= 0 && selectedIndex < selectedFiles.Count)
            {
                pictureBoxPreview.Image = Image.FromFile(selectedFiles[selectedIndex]);
            }
            else
            {
                // インデックスが無効な場合は、pictureBoxPreviewをクリア
                pictureBoxPreview.Image = null;
            }
        }

        private void buttonOutput_Click(object sender, EventArgs e)
        {
            if (selectedFiles.Count <= 0)
            {
                return;
            }
            string diffWidthImage = CheckIfAllImagesHaveSameWidth(selectedFiles);

            if (diffWidthImage != null)
            {
                MessageBox.Show($"幅が異なる画像があります。ファイル名: {diffWidthImage}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mismatchedImageFileDpi = CheckIfAllImagesHaveSameDpi(selectedFiles);

            if (mismatchedImageFileDpi != null)
            {
                MessageBox.Show($"解像度が異なる画像があります。ファイル名: {mismatchedImageFileDpi}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ConcatenateImagesAndSave(selectedFiles);

        }

        private void ConcatenateImagesAndSave(List<string> filePaths)
        {
            // 画像を連結
            Bitmap result = ConcatenateImages(filePaths);

            // ファイル保存ダイアログを表示し、ユーザーに保存場所とファイル名を指定させる
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PNG files (*.png)|*.png", // PNGファイルのみ保存できるようにフィルタを設定
                DefaultExt = "png", // デフォルトの拡張子を指定
                AddExtension = true // 拡張子がない場合に自動的に追加
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // 結果を保存する
                result.Save(saveFileDialog.FileName, ImageFormat.Png);
            }
            // 使用したBitmapをDisposeする
            result.Dispose();
        }

        private Bitmap ConcatenateImages(List<string> filePaths)
        {
            if (filePaths.Count <= 0)
            {
                return null;
            }
            Bitmap firstBitmap = new Bitmap(filePaths[0]);

            int totalWidth = firstBitmap.Width;
            int totalHeight = 0;

            foreach (string filePath in filePaths)
            {
                using (Bitmap bitmap = new Bitmap(filePath))
                {
                    totalWidth = Math.Max(totalWidth, bitmap.Width);
                    totalHeight += bitmap.Height;
                }
            }

            Bitmap result = new Bitmap(totalWidth, totalHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(result))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.Half;

                int offset = 0;

                foreach (string filePath in filePaths)
                {
                    using (Bitmap bitmap = new Bitmap(filePath))
                    {
                        // 各画像の位置とサイズを指定
                        Rectangle destRect = new Rectangle(0, offset, bitmap.Width, bitmap.Height);
                        g.DrawImage(bitmap, destRect);
                        offset += bitmap.Height;
                    }
                }
            }

            return result;
        }

        private string CheckIfAllImagesHaveSameWidth(List<string> filePaths)
        {
            if(filePaths.Count <= 0)
            {
                return null;
            }

            // 最初の画像の幅を取得
            using (Bitmap firstBitmap = new Bitmap(filePaths[0]))
            {
                int firstImageWidth = firstBitmap.Width;

                // 他のすべての画像が同じ幅を持つか確認
                foreach (string filePath in filePaths.Skip(1))
                {
                    using (Bitmap bitmap = new Bitmap(filePath))
                    {
                        if (bitmap.Width != firstImageWidth)
                        {
                            // 幅が異なる画像が見つかった場合は、そのファイル名を返す
                            return filePath;
                        }
                    }
                }
            }

            // すべての画像が同じ幅を持つ場合は、nullを返す
            return null;
        }

        private string CheckIfAllImagesHaveSameDpi(List<string> filePaths)
        {
            if (filePaths.Count <= 0)
            {
                return null;
            }

            // 最初の画像のDPIを取得して四捨五入
            using (Bitmap firstBitmap = new Bitmap(filePaths[0]))
            {
                int firstImageHorizontalDpi = (int)Math.Round(firstBitmap.HorizontalResolution);
                int firstImageVerticalDpi = (int)Math.Round(firstBitmap.VerticalResolution);

                // 他のすべての画像が同じDPI（四捨五入後の整数部分）を持つか確認
                foreach (string filePath in filePaths.Skip(1))
                {
                    using (Bitmap bitmap = new Bitmap(filePath))
                    {
                        if ((int)Math.Round(bitmap.HorizontalResolution) != firstImageHorizontalDpi ||
                            (int)Math.Round(bitmap.VerticalResolution) != firstImageVerticalDpi)
                        {
                            // DPI（四捨五入後の整数部分）が異なる画像が見つかった場合は、そのファイル名を返す
                            return filePath;
                        }
                    }
                }
            }

            // すべての画像が同じDPI（四捨五入後の整数部分）を持つ場合は、nullを返す
            return null;
        }

        private void radioButtonPrevColor1_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewBackgroundColor();
        }

        private void radioButtonPrevColor2_CheckedChanged(object sender, EventArgs e)
        {
            ChangePreviewBackgroundColor();
        }

        private void ChangePreviewBackgroundColor()
        {
            if (radioButtonPrevColor1.Checked)
            {
                panelImagePreview.BackColor = Color.Black;
            }
            else
            {
                panelImagePreview.BackColor = SystemColors.Control;
            }
        }

        private void buttonPreviewOutput_Click(object sender, EventArgs e)
        {
            listBoxImages.SelectedIndex = -1;

            if (selectedFiles.Count <= 0)
            {
                return;
            }
            string diffWidthImage = CheckIfAllImagesHaveSameWidth(selectedFiles);
            if (diffWidthImage != null)
            {
                MessageBox.Show($"幅が異なる画像があります。ファイル名: {diffWidthImage}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string mismatchedImageFileDpi = CheckIfAllImagesHaveSameDpi(selectedFiles);

            if (mismatchedImageFileDpi != null)
            {
                MessageBox.Show($"解像度が異なる画像があります。ファイル名: {mismatchedImageFileDpi}", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 画像を連結
            Bitmap result = ConcatenateImages(selectedFiles);

            // PictureBoxに表示する
            pictureBoxPreview.Image = new Bitmap(result);

            // 使用したBitmapをDisposeする
            result.Dispose();
        }


    }
}
