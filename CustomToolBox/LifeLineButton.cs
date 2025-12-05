using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ai_la_trieu_phu.CustomToolBox
{
    internal class LifeLineButton : Button
    {
        // Biến để kiểm tra quyền trợ giúp này đã dùng chưa
        private bool _isUsed = false;
        public bool IsUsed
        {
            get { return _isUsed; }
            set { _isUsed = value; Invalidate(); } // Vẽ lại khi thay đổi trạng thái
        }

        public LifeLineButton()
        {
            this.Size = new Size(60, 60); // Kích thước mặc định
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.BackColor = Color.Transparent;
            this.ForeColor = Color.White;
            this.Cursor = Cursors.Hand; // Đổi chuột thành bàn tay khi trỏ vào
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = this.ClientRectangle;
            rect.Inflate(-2, -2); // Thu nhỏ xíu để viền không bị cắt

            // 1. VẼ HÌNH TRÒN NỀN
            using (GraphicsPath path = new GraphicsPath())
            {
                path.AddEllipse(rect);
                this.Region = new Region(path); // Cắt nút thành hình tròn (bấm ra ngoài không ăn)

                // Chọn màu nền: Nếu đã dùng thì màu Xám, chưa dùng thì màu Xanh Đậm
                Color color1 = _isUsed ? Color.Gray : Color.FromArgb(13, 58, 107);
                Color color2 = _isUsed ? Color.DimGray : Color.FromArgb(5, 28, 56);

                using (LinearGradientBrush brush = new LinearGradientBrush(rect, color1, color2, 45F))
                {
                    g.FillEllipse(brush, rect);
                }

                // 2. VẼ VIỀN VÀNG (Nếu đã dùng thì viền xám luôn)
                Color borderColor = _isUsed ? Color.DarkGray : Color.FromArgb(255, 215, 0);
                using (Pen pen = new Pen(borderColor, 3))
                {
                    g.DrawEllipse(pen, rect);
                }
            }

            // 3. VẼ HÌNH ẢNH (ICON) HOẶC CHỮ (TEXT)
            if (this.Image != null)
            {
                // Nếu có ảnh thì vẽ ảnh vào giữa (thu nhỏ ảnh lại chút cho đẹp)
                int imgSize = (int)(this.Width * 0.6);
                g.DrawImage(this.Image, (this.Width - imgSize) / 2, (this.Height - imgSize) / 2, imgSize, imgSize);
            }
            else
            {
                // Nếu không có ảnh thì vẽ Text (Dành cho nút 50:50 nếu bạn lười kiếm ảnh)
                StringFormat sf = new StringFormat();
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;
                g.DrawString(this.Text, this.Font, Brushes.White, rect, sf);
            }

            // 4. VẼ DẤU X (NẾU ĐÃ DÙNG)
            if (_isUsed)
            {
                using (Pen redPen = new Pen(Color.Red, 3))
                {
                    // Vẽ 2 đường chéo
                    g.DrawLine(redPen, rect.Left + 10, rect.Top + 10, rect.Right - 10, rect.Bottom - 10);
                    g.DrawLine(redPen, rect.Right - 10, rect.Top + 10, rect.Left + 10, rect.Bottom - 10);
                }
            }
        }
    }
}
