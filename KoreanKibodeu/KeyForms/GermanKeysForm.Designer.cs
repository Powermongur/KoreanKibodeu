
namespace KoreanKibodeu
{
    partial class GermanKeysForm
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
            this.qwertyToQwertzCheckBox = new System.Windows.Forms.CheckBox();
            this.qwertyRadioButton = new System.Windows.Forms.RadioButton();
            this.qwertzRadioButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // qwertyToQwertzCheckBox
            // 
            this.qwertyToQwertzCheckBox.AutoSize = true;
            this.qwertyToQwertzCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.qwertyToQwertzCheckBox.Location = new System.Drawing.Point(51, 173);
            this.qwertyToQwertzCheckBox.Name = "qwertyToQwertzCheckBox";
            this.qwertyToQwertzCheckBox.Size = new System.Drawing.Size(143, 24);
            this.qwertyToQwertzCheckBox.TabIndex = 1;
            this.qwertyToQwertzCheckBox.Text = "qwerty -> qwertz";
            this.qwertyToQwertzCheckBox.UseVisualStyleBackColor = true;
            this.qwertyToQwertzCheckBox.CheckStateChanged += new System.EventHandler(this.qwertyToQwertzCheckBox_CheckStateChanged);
            // 
            // qwertyRadioButton
            // 
            this.qwertyRadioButton.AutoSize = true;
            this.qwertyRadioButton.Checked = true;
            this.qwertyRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.qwertyRadioButton.Location = new System.Drawing.Point(3, 0);
            this.qwertyRadioButton.Name = "qwertyRadioButton";
            this.qwertyRadioButton.Size = new System.Drawing.Size(118, 24);
            this.qwertyRadioButton.TabIndex = 2;
            this.qwertyRadioButton.TabStop = true;
            this.qwertyRadioButton.Text = "Y is next to T";
            this.qwertyRadioButton.UseVisualStyleBackColor = true;
            this.qwertyRadioButton.CheckedChanged += new System.EventHandler(this.qwertyRadioButton_CheckedChanged);
            // 
            // qwertzRadioButton
            // 
            this.qwertzRadioButton.AutoSize = true;
            this.qwertzRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.qwertzRadioButton.Location = new System.Drawing.Point(4, 30);
            this.qwertzRadioButton.Name = "qwertzRadioButton";
            this.qwertzRadioButton.Size = new System.Drawing.Size(117, 24);
            this.qwertzRadioButton.TabIndex = 3;
            this.qwertzRadioButton.Text = "Z is next to T";
            this.qwertzRadioButton.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label1.Location = new System.Drawing.Point(43, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(236, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Is Y next to T on your keyboard?";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.qwertzRadioButton);
            this.panel1.Controls.Add(this.qwertyRadioButton);
            this.panel1.Location = new System.Drawing.Point(47, 244);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(125, 59);
            this.panel1.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.label2.Location = new System.Drawing.Point(47, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Swap Y and Z?";
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.Location = new System.Drawing.Point(934, 12);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 23);
            this.closeButton.TabIndex = 9;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // GermanKeysForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(965, 1023);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.qwertyToQwertzCheckBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "GermanKeysForm";
            this.Text = "GermanKeysForm";
            this.Load += new System.EventHandler(this.GermanKeysForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GermanKeysForm_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox qwertyToQwertzCheckBox;
        private System.Windows.Forms.RadioButton qwertyRadioButton;
        private System.Windows.Forms.RadioButton qwertzRadioButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button closeButton;
    }
}