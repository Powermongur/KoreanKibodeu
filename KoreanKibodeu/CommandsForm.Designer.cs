
namespace KoreanKibodeu
{
    partial class CommandsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommandsForm));
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.panel10 = new System.Windows.Forms.Panel();
            this.keyMenuSelectlabel = new System.Windows.Forms.Label();
            this.optionsMenuSelectlabel = new System.Windows.Forms.Label();
            this.commandMenuSelectlabel = new System.Windows.Forms.Label();
            this.commandsButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.keysButton = new System.Windows.Forms.Button();
            this.panel10.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.richTextBox1.ForeColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(12, 145);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(941, 610);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // closeButton
            // 
            this.closeButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.closeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(235)))));
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
            this.closeButton.UseVisualStyleBackColor = false;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(235)))));
            this.panel10.Controls.Add(this.keyMenuSelectlabel);
            this.panel10.Controls.Add(this.optionsMenuSelectlabel);
            this.panel10.Controls.Add(this.commandMenuSelectlabel);
            this.panel10.Controls.Add(this.commandsButton);
            this.panel10.Controls.Add(this.optionsButton);
            this.panel10.Controls.Add(this.keysButton);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(965, 47);
            this.panel10.TabIndex = 1023;
            // 
            // keyMenuSelectlabel
            // 
            this.keyMenuSelectlabel.BackColor = System.Drawing.Color.White;
            this.keyMenuSelectlabel.Location = new System.Drawing.Point(0, 42);
            this.keyMenuSelectlabel.Name = "keyMenuSelectlabel";
            this.keyMenuSelectlabel.Size = new System.Drawing.Size(98, 5);
            this.keyMenuSelectlabel.TabIndex = 1023;
            // 
            // optionsMenuSelectlabel
            // 
            this.optionsMenuSelectlabel.BackColor = System.Drawing.Color.White;
            this.optionsMenuSelectlabel.Location = new System.Drawing.Point(98, 42);
            this.optionsMenuSelectlabel.Name = "optionsMenuSelectlabel";
            this.optionsMenuSelectlabel.Size = new System.Drawing.Size(121, 5);
            this.optionsMenuSelectlabel.TabIndex = 1023;
            // 
            // commandMenuSelectlabel
            // 
            this.commandMenuSelectlabel.BackColor = System.Drawing.Color.White;
            this.commandMenuSelectlabel.Location = new System.Drawing.Point(219, 42);
            this.commandMenuSelectlabel.Name = "commandMenuSelectlabel";
            this.commandMenuSelectlabel.Size = new System.Drawing.Size(145, 5);
            this.commandMenuSelectlabel.TabIndex = 1023;
            // 
            // commandsButton
            // 
            this.commandsButton.FlatAppearance.BorderSize = 0;
            this.commandsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.commandsButton.Location = new System.Drawing.Point(213, 0);
            this.commandsButton.Name = "commandsButton";
            this.commandsButton.Size = new System.Drawing.Size(145, 41);
            this.commandsButton.TabIndex = 20;
            this.commandsButton.Text = "Commands";
            this.commandsButton.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            this.optionsButton.FlatAppearance.BorderSize = 0;
            this.optionsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.optionsButton.Location = new System.Drawing.Point(98, 0);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(121, 41);
            this.optionsButton.TabIndex = 20;
            this.optionsButton.Text = "Options";
            this.optionsButton.UseVisualStyleBackColor = true;
            this.optionsButton.Click += new System.EventHandler(this.optionsButton_Click);
            // 
            // keysButton
            // 
            this.keysButton.FlatAppearance.BorderSize = 0;
            this.keysButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.keysButton.Location = new System.Drawing.Point(0, 0);
            this.keysButton.Name = "keysButton";
            this.keysButton.Size = new System.Drawing.Size(98, 41);
            this.keysButton.TabIndex = 20;
            this.keysButton.Text = "Keys";
            this.keysButton.UseVisualStyleBackColor = true;
            this.keysButton.Click += new System.EventHandler(this.keysButton_Click);
            // 
            // CommandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(19F, 37F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.ClientSize = new System.Drawing.Size(965, 1023);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.panel10);
            this.Controls.Add(this.richTextBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(10, 9, 10, 9);
            this.Name = "CommandsForm";
            this.Text = "CommandsForm";
            this.Load += new System.EventHandler(this.CommandsForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CommandsForm_MouseDown);
            this.panel10.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Label keyMenuSelectlabel;
        private System.Windows.Forms.Label optionsMenuSelectlabel;
        private System.Windows.Forms.Label commandMenuSelectlabel;
        private System.Windows.Forms.Button commandsButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button keysButton;
    }
}