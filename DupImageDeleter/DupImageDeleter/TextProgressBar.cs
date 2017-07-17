using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace DupImageDeleter
{
    public class TextProgressBar : ProgressBar
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams result = base.CreateParams;
                if (Environment.OSVersion.Platform == PlatformID.Win32NT
                    && Environment.OSVersion.Version.Major >= 6)
                {
                    result.ExStyle |= 0x02000000; // WS_EX_COMPOSITED 
                }

                return result;
            }
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0x000F)
            {
                using (Graphics graphics = this.CreateGraphics())
                using (SolidBrush brush = new SolidBrush(this.ForeColor))
                {
                    SizeF textSize = graphics.MeasureString(this.Text, this.Font);
                    graphics.DrawString(this.Text, this.Font, brush, 5, (this.Height - textSize.Height) / 2);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                this.Refresh();
            }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;
                this.Refresh();
            }
        }
    }
}
