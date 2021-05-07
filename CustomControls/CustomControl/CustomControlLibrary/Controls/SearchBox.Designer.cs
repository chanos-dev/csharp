namespace CustomControlLibrary.Controls
{
    partial class SearchBox
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tb_Text = new System.Windows.Forms.TextBox();
            this.lb_Search = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // tb_Text
            // 
            this.tb_Text.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_Text.Location = new System.Drawing.Point(0, 0);
            this.tb_Text.Name = "tb_Text";
            this.tb_Text.Size = new System.Drawing.Size(125, 21);
            this.tb_Text.TabIndex = 0;
            this.tb_Text.TabStop = false;
            this.tb_Text.TextChanged += new System.EventHandler(this.tb_Text_TextChanged);
            // 
            // lb_Search
            // 
            this.lb_Search.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lb_Search.FormattingEnabled = true;
            this.lb_Search.ItemHeight = 12;
            this.lb_Search.Location = new System.Drawing.Point(0, 21);
            this.lb_Search.Name = "lb_Search";
            this.lb_Search.ScrollAlwaysVisible = true;
            this.lb_Search.Size = new System.Drawing.Size(125, 239);
            this.lb_Search.TabIndex = 1;
            this.lb_Search.TabStop = false;
            // 
            // SearchBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lb_Search);
            this.Controls.Add(this.tb_Text);
            this.Name = "SearchBox";
            this.Size = new System.Drawing.Size(125, 260);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_Text;
        private System.Windows.Forms.ListBox lb_Search;
    }
}