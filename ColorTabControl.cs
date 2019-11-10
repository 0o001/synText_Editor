using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace synText_Editor
{
    public partial class ColorTabControl : TabControl
    {
        private int _hotTabIndex = -1;

        public ColorTabControl()
            : base()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint | ControlStyles.SupportsTransparentBackColor, true);
            this.ItemSize = new Size(500, 40);
        }

        #region Properties

        private int CloseButtonHeight
        {
            get { return FontHeight; }
        }

        private int HotTabIndex
        {
            get { return _hotTabIndex; }
            set
            {
                if (_hotTabIndex != value)
                {
                    _hotTabIndex = value;
                    this.Invalidate();
                }
            }
        }

        #endregion

        #region Overridden Methods

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.OnFontChanged(EventArgs.Empty);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            base.OnFontChanged(e);
            IntPtr hFont = this.Font.ToHfont();
            SendMessage(this.Handle, WM_SETFONT, hFont, new IntPtr(-1));
            SendMessage(this.Handle, WM_FONTCHANGE, IntPtr.Zero, IntPtr.Zero);
            this.UpdateStyles();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            TCHITTESTINFO HTI = new TCHITTESTINFO(e.X, e.Y);
            HotTabIndex = SendMessage(this.Handle, TCM_HITTEST, IntPtr.Zero, ref HTI);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            HotTabIndex = -1;
            this.Cursor = Cursors.Default;
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            pevent.Graphics.Clear(Color.FromArgb(30, 30, 30));
            base.OnPaintBackground(pevent);
            for (int id = 0; id < this.TabCount; id++)
            {
                DrawTabBackground(pevent.Graphics, id);

                Rectangle lasttabrect = this.GetTabRect(this.TabPages.Count - 1);
                RectangleF emptyspacerect = new RectangleF(
                        lasttabrect.X + lasttabrect.Width + this.Left,
                        this.Top + lasttabrect.Y,
                        this.Width - (lasttabrect.X + lasttabrect.Width),
                        lasttabrect.Height);

                SolidBrush b = new SolidBrush(Color.FromArgb(255, (byte)30, (byte)30, (byte)30));
                SolidBrush b2 = new SolidBrush(Color.FromArgb(255, (byte)50, (byte)50, (byte)50));
                pevent.Graphics.FillRectangle(b, emptyspacerect);
                Graphics g = pevent.Graphics;
                Pen p = new Pen(b2, 10);
                g.DrawRectangle(p, this.TabPages[id].Bounds);
                this.TabPages[id].BackColor = Color.FromArgb(255, (byte)30, (byte)30, (byte)30); //Color.FromArgb(255, (byte)50, (byte)50, (byte)50)
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            for (int id = 0; id < this.TabCount; id++)
            {
                DrawTabContent(e.Graphics, id);
            }
        }
        protected override void WndProc(ref Message m)
        {

            if (m.Msg == TCM_SETPADDING)
                m.LParam = MAKELPARAM(this.Padding.X + CloseButtonHeight / 2, this.Padding.Y);

            if (m.Msg == WM_MOUSEDOWN && !this.DesignMode)
            {
                Point pt = this.PointToClient(Cursor.Position);

                Rectangle closeRect = GetCloseButtonRect(HotTabIndex);

                if (closeRect.Contains(pt))
                {
                    TabPages.RemoveAt(HotTabIndex);
                    m.Msg = WM_NULL;
                }
            }
            base.WndProc(ref m);

        }

        #endregion

        #region Private Methods

        private IntPtr MAKELPARAM(int lo, int hi)
        {
            return new IntPtr((hi << 16) | (lo & 0xFFFF));
        }

        private void DrawTabBackground(Graphics graphics, int id)
        {


            if (id == SelectedIndex)
            {
                SolidBrush renk = new SolidBrush(Color.FromArgb(50, 50, 50));
                graphics.FillRectangle(renk, GetTabRect(id));
            }
            else if (id == HotTabIndex)
            {
                Rectangle rc = GetTabRect(id);
                rc.Width--;
                rc.Height--;
                graphics.DrawRectangle(Pens.DarkGray, rc);
                SolidBrush renk = new SolidBrush(Color.FromArgb(60, 60, 60));
                graphics.FillRectangle(renk, GetTabRect(id));
            }
            else
            {
                SolidBrush renk = new SolidBrush(Color.FromArgb(30, 30, 30));
                graphics.FillRectangle(renk, GetTabRect(id));
            }
        }

        private void DrawTabContent(Graphics graphics, int id)
        {
            bool selectedOrHot = id == this.SelectedIndex || id == this.HotTabIndex;
            bool vertical = this.Alignment >= TabAlignment.Left;

            Image tabImage = null;

            if (this.ImageList != null)
            {
                TabPage page = this.TabPages[id];
                if (page.ImageIndex > -1 && page.ImageIndex < this.ImageList.Images.Count)
                    tabImage = this.ImageList.Images[page.ImageIndex];

                if (page.ImageKey.Length > 0 && this.ImageList.Images.ContainsKey(page.ImageKey))
                    tabImage = this.ImageList.Images[page.ImageKey];
            }

            Rectangle tabRect = GetTabRect(id);
            Rectangle contentRect = vertical ? new Rectangle(0, 0, tabRect.Height, tabRect.Width) : new Rectangle(Point.Empty, tabRect.Size);

            Rectangle textrect = contentRect;
            textrect.Width -= FontHeight;
            if (tabImage != null)
            {
                textrect.Width -= tabImage.Width;
                textrect.X += tabImage.Width;
            }
            Color frColor = id == SelectedIndex ? Color.White : Color.White;
            Color bkColor = id == SelectedIndex ? Color.FromArgb(50, 50, 50) : Color.FromArgb(30, 30, 30);

            using (Bitmap bm = new Bitmap(contentRect.Width, contentRect.Height))
            {
                using (Graphics bmGraphics = Graphics.FromImage(bm))
                {
                    TextRenderer.DrawText(bmGraphics, this.TabPages[id].Text, this.Font, textrect, frColor, bkColor);
                    if (selectedOrHot)
                    {
                        if (this.HotTabIndex == id && this.HotTabIndex != this.SelectedIndex)
                        {
                            TextRenderer.DrawText(bmGraphics, this.TabPages[id].Text, this.Font, textrect, frColor, Color.FromArgb(60, 60, 60));
                        }
                        /*burası*/
                        Rectangle closeRect = new Rectangle(contentRect.Right - CloseButtonHeight - 1, 0, CloseButtonHeight - 2, CloseButtonHeight - 2);
                        closeRect.Offset(-2, (contentRect.Height - closeRect.Height) / 2);
                        DrawCloseButton(bmGraphics, closeRect);

                    }
                    if (tabImage != null)
                    {
                        Rectangle imageRect = new Rectangle(Padding.X, 0, tabImage.Width, tabImage.Height);
                        // TextRenderer.DrawText(bmGraphics, this.TabPages[id].Text, this.Font, textrect, frColor, Color.FromArgb(60, 60, 60));
                        imageRect.Offset(0, (contentRect.Height - imageRect.Height) / 2);
                        bmGraphics.DrawImage(tabImage, imageRect);
                    }
                }

                if (vertical)
                {
                    if (this.Alignment == TabAlignment.Left)
                        bm.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    else
                        bm.RotateFlip(RotateFlipType.Rotate90FlipNone);
                }
                graphics.DrawImage(bm, tabRect);

            }
        }

        private void DrawCloseButton(Graphics graphics, Rectangle bounds)
        {
            graphics.FillEllipse(Brushes.IndianRed, bounds);
            Rectangle den = bounds;
            den.Size = new Size(20, 12);
            den.Location = new Point(den.Location.X, den.Location.Y + 2);
            using (Font closeFont = new Font("Symbol", Font.Size, FontStyle.Bold))
                TextRenderer.DrawText(graphics, "´", closeFont, den, Color.White, Color.IndianRed, TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding | TextFormatFlags.SingleLine | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis | TextFormatFlags.Top);
        }

        private Rectangle GetCloseButtonRect(int id)
        {
            Rectangle tabRect = GetTabRect(id);
            Rectangle closeRect = new Rectangle(tabRect.Left, tabRect.Top, CloseButtonHeight, CloseButtonHeight);
            switch (Alignment)
            {
                case TabAlignment.Left:
                    closeRect.Offset((tabRect.Width - closeRect.Width) / 2, 0);
                    break;
                case TabAlignment.Right:
                    closeRect.Offset((tabRect.Width - closeRect.Width) / 2, tabRect.Height - closeRect.Height);
                    break;
                default:
                    closeRect.Offset(tabRect.Width - closeRect.Width, (tabRect.Height - closeRect.Height) / 2);
                    break;
            }

            return closeRect;
        }

        #endregion

        #region Interop

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int msg, IntPtr wParam, ref TCHITTESTINFO lParam);

        [StructLayout(LayoutKind.Sequential)]
        private struct TCHITTESTINFO
        {
            public Point pt;
            public TCHITTESTFLAGS flags;
            public TCHITTESTINFO(int x, int y)
            {
                pt = new Point(x, y);
                flags = TCHITTESTFLAGS.TCHT_NOWHERE;
            }
        }

        [Flags()]
        private enum TCHITTESTFLAGS
        {
            TCHT_NOWHERE = 1,
            TCHT_ONITEMICON = 2,
            TCHT_ONITEMLABEL = 4,
            TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
        }

        private const int WM_NULL = 0x0;
        private const int WM_SETFONT = 0x30;
        private const int WM_FONTCHANGE = 0x1D;
        private const int WM_MOUSEDOWN = 0x201;

        private const int TCM_FIRST = 0x1300;
        private const int TCM_HITTEST = TCM_FIRST + 13;
        private const int TCM_SETPADDING = TCM_FIRST + 43;

        #endregion
    }
}
