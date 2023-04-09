namespace Blue_Software
{
    partial class Quest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textAnswer = new System.Windows.Forms.TextBox();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // textAnswer
            // 
            this.textAnswer.Location = new System.Drawing.Point(28, 135);
            this.textAnswer.Name = "textAnswer";
            this.textAnswer.Size = new System.Drawing.Size(125, 27);
            this.textAnswer.TabIndex = 1;
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(28, 185);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(139, 29);
            this.btnAnswer.TabIndex = 2;
            this.btnAnswer.Text = "Send Answer";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // Quest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.textAnswer);
            this.Controls.Add(this.label1);
            this.Name = "Quest";
            this.Text = "Quest";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox textAnswer;
        private Button btnAnswer;
    }
}