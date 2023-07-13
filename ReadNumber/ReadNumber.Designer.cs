using System.Windows.Forms;

namespace ReadNumber
{
    partial class ReadNumber
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
            this.input_Num = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label_Result = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // input_Num
            // 
            this.input_Num.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.input_Num.Location = new System.Drawing.Point(39, 574);
            this.input_Num.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.input_Num.Name = "input_Num";
            this.input_Num.Size = new System.Drawing.Size(299, 32);
            this.input_Num.TabIndex = 0;
            this.input_Num.TextChanged += new System.EventHandler(this.input_Num_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.label_Result);
            this.panel2.Location = new System.Drawing.Point(39, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 532);
            this.panel2.TabIndex = 2;
            // 
            // label_Result
            // 
            this.label_Result.Font = new System.Drawing.Font("맑은 고딕", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label_Result.Location = new System.Drawing.Point(0, 0);
            this.label_Result.Name = "label_Result";
            this.label_Result.Size = new System.Drawing.Size(299, 532);
            this.label_Result.TabIndex = 3;
            this.label_Result.Text = "일";
            // 
            // ReadNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 630);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.input_Num);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "ReadNumber";
            this.Text = "ReadNumber";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox input_Num;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label_Result;
    }
}

