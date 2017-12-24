namespace GeoWriter
{
    partial class Form1
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
            this.WriteGeoFile = new System.Windows.Forms.Button();
            this.clearInput = new System.Windows.Forms.Button();
            this.inputBox = new System.Windows.Forms.RichTextBox();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WriteGeoFile
            // 
            this.WriteGeoFile.Location = new System.Drawing.Point(433, 636);
            this.WriteGeoFile.Name = "WriteGeoFile";
            this.WriteGeoFile.Size = new System.Drawing.Size(137, 23);
            this.WriteGeoFile.TabIndex = 1;
            this.WriteGeoFile.Text = "Parse And Save GEO File";
            this.WriteGeoFile.UseVisualStyleBackColor = true;
            this.WriteGeoFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // clearInput
            // 
            this.clearInput.Location = new System.Drawing.Point(352, 635);
            this.clearInput.Name = "clearInput";
            this.clearInput.Size = new System.Drawing.Size(75, 23);
            this.clearInput.TabIndex = 2;
            this.clearInput.Text = "Clear Input";
            this.clearInput.UseVisualStyleBackColor = true;
            this.clearInput.Click += new System.EventHandler(this.clearInput_Click);
            // 
            // inputBox
            // 
            this.inputBox.DetectUrls = false;
            this.inputBox.Font = new System.Drawing.Font("Linux Libertine Display G", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputBox.Location = new System.Drawing.Point(12, 12);
            this.inputBox.Name = "inputBox";
            this.inputBox.Size = new System.Drawing.Size(970, 618);
            this.inputBox.TabIndex = 3;
            this.inputBox.Text = "";
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(576, 636);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(75, 23);
            this.exit.TabIndex = 4;
            this.exit.Text = "Quit";
            this.exit.UseVisualStyleBackColor = true;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 670);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.inputBox);
            this.Controls.Add(this.clearInput);
            this.Controls.Add(this.WriteGeoFile);
            this.Name = "Form1";
            this.Text = "GeoWriter";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button WriteGeoFile;
        private System.Windows.Forms.Button clearInput;
        private System.Windows.Forms.RichTextBox inputBox;
        private System.Windows.Forms.Button exit;
    }
}

