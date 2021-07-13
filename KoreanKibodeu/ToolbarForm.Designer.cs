
namespace KoreanKibodeu
{
    partial class ToolbarForm
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
            this.focusButton = new System.Windows.Forms.Button();
            this.blackWhitebutton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.moveLocationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // focusButton
            // 
            this.focusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.focusButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.focusButton.FlatAppearance.BorderSize = 0;
            this.focusButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.focusButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.focusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.focusButton.ForeColor = System.Drawing.Color.White;
            this.focusButton.Location = new System.Drawing.Point(12, 4);
            this.focusButton.Name = "focusButton";
            this.focusButton.Size = new System.Drawing.Size(19, 23);
            this.focusButton.TabIndex = 5;
            this.focusButton.Text = "👁️";
            this.focusButton.UseVisualStyleBackColor = false;
            this.focusButton.Click += new System.EventHandler(this.focusButton_Click);
            // 
            // blackWhitebutton
            // 
            this.blackWhitebutton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.blackWhitebutton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.blackWhitebutton.FlatAppearance.BorderSize = 0;
            this.blackWhitebutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.blackWhitebutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.blackWhitebutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackWhitebutton.ForeColor = System.Drawing.Color.White;
            this.blackWhitebutton.Location = new System.Drawing.Point(37, 4);
            this.blackWhitebutton.Name = "blackWhitebutton";
            this.blackWhitebutton.Size = new System.Drawing.Size(19, 23);
            this.blackWhitebutton.TabIndex = 6;
            this.blackWhitebutton.Text = "☯️";
            this.blackWhitebutton.UseVisualStyleBackColor = false;
            this.blackWhitebutton.Click += new System.EventHandler(this.blackWhitebutton_Click);
            // 
            // closeButton
            // 
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.closeButton.FlatAppearance.BorderSize = 0;
            this.closeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.closeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Maroon;
            this.closeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeButton.ForeColor = System.Drawing.Color.White;
            this.closeButton.Location = new System.Drawing.Point(83, 4);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(19, 23);
            this.closeButton.TabIndex = 7;
            this.closeButton.Text = "X";
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // moveLocationButton
            // 
            this.moveLocationButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveLocationButton.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.moveLocationButton.FlatAppearance.BorderSize = 0;
            this.moveLocationButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Teal;
            this.moveLocationButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.moveLocationButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.moveLocationButton.ForeColor = System.Drawing.Color.White;
            this.moveLocationButton.Location = new System.Drawing.Point(58, 4);
            this.moveLocationButton.Name = "moveLocationButton";
            this.moveLocationButton.Size = new System.Drawing.Size(19, 23);
            this.moveLocationButton.TabIndex = 6;
            this.moveLocationButton.Text = "🎯";
            this.moveLocationButton.UseVisualStyleBackColor = false;
            this.moveLocationButton.Click += new System.EventHandler(this.moveLocationButton_Click);
            // 
            // ToolbarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(114, 30);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.moveLocationButton);
            this.Controls.Add(this.blackWhitebutton);
            this.Controls.Add(this.focusButton);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "ToolbarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Toolbar";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ToolbarForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ToolbarForm_MouseDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button focusButton;
        private System.Windows.Forms.Button blackWhitebutton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button moveLocationButton;
    }
}