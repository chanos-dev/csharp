using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.ComponentModel;


namespace CustomControlLibrary.Controls
{
    /// <summary>
    /// Windows ToggleButton.
    /// </summary>
    public class ToggleButton : CheckBox
    {
        #region Fields
        private Color _onBackGroundColor = Color.MediumPurple;
        private Color _onToggleColor = Color.WhiteSmoke;
        private Color _offBackGroundColor = Color.Gray;
        private Color _offToggleColor = Color.Gainsboro;

        private bool _soildStyle = true;
        #endregion

        #region Properties
        /// <summary>
        /// Checked BackGroundColor.
        /// </summary>
        [Category("ToggleButton Properties")]
        public Color OnBackGroundColor
        {
            get => _onBackGroundColor;
            set
            {
                _onBackGroundColor = value;
                this.Refresh();
            } 
        }

        /// <summary>
        /// Checked ToggleColor.
        /// </summary>
        [Category("ToggleButton Properties")]
        public Color OnToggleColor
        {
            get => _onToggleColor;
            set
            {
                _onToggleColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Unchecked BackGroundColor.
        /// </summary>
        [Category("ToggleButton Properties")]
        public Color OffBackGroundColor
        {
            get => _offBackGroundColor;
            set
            {
                _offBackGroundColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Unchecked ToggleColor.
        /// </summary>
        [Category("ToggleButton Properties")]
        public Color OffToggleColor
        {
            get => _offToggleColor;
            set
            {
                _offToggleColor = value;
                this.Refresh();
            }
        }

        /// <summary>
        /// Don't use it.
        /// </summary>
        [Browsable(false)]
        public override string Text
        {
            get => base.Text;
            set { }
        }

        /// <summary>
        /// Fill BackGroundColor.
        /// </summary>
        [Category("ToggleButton Properties")]
        public bool SoildStyle
        {
            get => _soildStyle;
            set
            {
                _soildStyle = value;
                this.Refresh();
            }
        }
        #endregion

        #region Constroctur
        /// <summary>
        /// Constroctur
        /// </summary>
        public ToggleButton()
        {
            this.MinimumSize = new Size(45, 22);
        }
        #endregion

        #region Methods
        internal GraphicsPath GetGraphicsPath()
        {
            int arcSize = this.Height - 1;

            var leftArc = new Rectangle(0, 0, arcSize, arcSize);
            var rightArc = new Rectangle(this.Width - arcSize - 2, 0, arcSize, arcSize);

            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(leftArc, 90, 180);
            path.AddArc(rightArc, 270, 180);
            path.CloseFigure();

            return path;
        }
        #endregion

        #region Events
        /// <summary>
        /// Windows Toggle Button OnPaint Event.
        /// </summary>
        /// <param name="pevent">this Control.</param>
        protected override void OnPaint(PaintEventArgs pevent)
        {
            int toggleSize = this.Height - 5;

            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            pevent.Graphics.Clear(this.Parent.BackColor);

            if (this.Checked)
            {
                if (SoildStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OnBackGroundColor), GetGraphicsPath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OnBackGroundColor, 2), GetGraphicsPath());
                }

                pevent.Graphics.FillEllipse(new SolidBrush(OnToggleColor), new Rectangle(this.Width - this.Height + 1, 2, toggleSize, toggleSize));
            }
            else
            {
                if (SoildStyle)
                {
                    pevent.Graphics.FillPath(new SolidBrush(OffBackGroundColor), GetGraphicsPath());
                }
                else
                {
                    pevent.Graphics.DrawPath(new Pen(OffBackGroundColor, 2), GetGraphicsPath());
                }

                pevent.Graphics.FillEllipse(new SolidBrush(OffToggleColor), new Rectangle(2, 2, toggleSize, toggleSize));
            }
        }
        #endregion
    }
}
