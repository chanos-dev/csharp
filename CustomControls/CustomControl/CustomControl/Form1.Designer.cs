namespace CustomControl
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchBox1 = new CustomControlLibrary.Controls.SearchBox();
            this.toggleButton2 = new CustomControlLibrary.Controls.ToggleButton();
            this.toggleButton1 = new CustomControlLibrary.Controls.ToggleButton();
            this.SuspendLayout();
            // 
            // searchBox1
            // 
            this.searchBox1.Data = ((System.Collections.Generic.List<string>)(resources.GetObject("searchBox1.Data")));
            this.searchBox1.DisplayLimitCount = 10;
            this.searchBox1.Location = new System.Drawing.Point(44, 110);
            this.searchBox1.Name = "searchBox1";
            this.searchBox1.Size = new System.Drawing.Size(279, 21);
            this.searchBox1.TabIndex = 2;
            // 
            // toggleButton2
            // 
            this.toggleButton2.AutoSize = true;
            this.toggleButton2.Location = new System.Drawing.Point(112, 40);
            this.toggleButton2.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton2.Name = "toggleButton2";
            this.toggleButton2.OffBackGroundColor = System.Drawing.Color.Gray;
            this.toggleButton2.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton2.OnBackGroundColor = System.Drawing.Color.MediumPurple;
            this.toggleButton2.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton2.Size = new System.Drawing.Size(45, 22);
            this.toggleButton2.SoildStyle = true;
            this.toggleButton2.TabIndex = 1;
            this.toggleButton2.UseVisualStyleBackColor = true;
            // 
            // toggleButton1
            // 
            this.toggleButton1.AutoSize = true;
            this.toggleButton1.Location = new System.Drawing.Point(44, 40);
            this.toggleButton1.MinimumSize = new System.Drawing.Size(45, 22);
            this.toggleButton1.Name = "toggleButton1";
            this.toggleButton1.OffBackGroundColor = System.Drawing.Color.Gray;
            this.toggleButton1.OffToggleColor = System.Drawing.Color.Gainsboro;
            this.toggleButton1.OnBackGroundColor = System.Drawing.Color.MediumPurple;
            this.toggleButton1.OnToggleColor = System.Drawing.Color.WhiteSmoke;
            this.toggleButton1.Size = new System.Drawing.Size(45, 22);
            this.toggleButton1.SoildStyle = true;
            this.toggleButton1.TabIndex = 0;
            this.toggleButton1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchBox1);
            this.Controls.Add(this.toggleButton2);
            this.Controls.Add(this.toggleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControlLibrary.Controls.ToggleButton toggleButton1;
        private CustomControlLibrary.Controls.ToggleButton toggleButton2;
        private CustomControlLibrary.Controls.SearchBox searchBox1;
    }
}

