namespace ConfigureWrite
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.NameInput = new System.Windows.Forms.TextBox();
            this.PasswordInput = new System.Windows.Forms.TextBox();
            this.SaveChanges = new System.Windows.Forms.Button();
            this.Exit = new System.Windows.Forms.Button();
            this.InformationDisplay = new System.Windows.Forms.TextBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.Update = new System.Windows.Forms.Button();
            this.Website = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameInput
            // 
            this.NameInput.Location = new System.Drawing.Point(12, 207);
            this.NameInput.Name = "NameInput";
            this.NameInput.Size = new System.Drawing.Size(1119, 38);
            this.NameInput.TabIndex = 0;
            this.NameInput.Text = "Enter A Name";
            // 
            // PasswordInput
            // 
            this.PasswordInput.Location = new System.Drawing.Point(12, 273);
            this.PasswordInput.Name = "PasswordInput";
            this.PasswordInput.Size = new System.Drawing.Size(1119, 38);
            this.PasswordInput.TabIndex = 1;
            this.PasswordInput.Text = "Enter A Password";
            // 
            // SaveChanges
            // 
            this.SaveChanges.Location = new System.Drawing.Point(884, 329);
            this.SaveChanges.Name = "SaveChanges";
            this.SaveChanges.Size = new System.Drawing.Size(247, 52);
            this.SaveChanges.TabIndex = 2;
            this.SaveChanges.Text = "Save Changes";
            this.SaveChanges.UseVisualStyleBackColor = true;
            this.SaveChanges.Click += new System.EventHandler(this.SaveChanges_Click);
            // 
            // Exit
            // 
            this.Exit.Location = new System.Drawing.Point(618, 329);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(247, 52);
            this.Exit.TabIndex = 3;
            this.Exit.Text = "Cancel";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // InformationDisplay
            // 
            this.InformationDisplay.Location = new System.Drawing.Point(13, 13);
            this.InformationDisplay.Multiline = true;
            this.InformationDisplay.Name = "InformationDisplay";
            this.InformationDisplay.Size = new System.Drawing.Size(1118, 177);
            this.InformationDisplay.TabIndex = 4;
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // Update
            // 
            this.Update.Location = new System.Drawing.Point(12, 329);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(247, 52);
            this.Update.TabIndex = 5;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // Website
            // 
            this.Website.Location = new System.Drawing.Point(274, 329);
            this.Website.Name = "Website";
            this.Website.Size = new System.Drawing.Size(247, 52);
            this.Website.TabIndex = 6;
            this.Website.Text = "Write.com";
            this.Website.UseVisualStyleBackColor = true;
            this.Website.Click += new System.EventHandler(this.Website_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1143, 393);
            this.Controls.Add(this.Website);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.InformationDisplay);
            this.Controls.Add(this.Exit);
            this.Controls.Add(this.SaveChanges);
            this.Controls.Add(this.PasswordInput);
            this.Controls.Add(this.NameInput);
            this.Name = "Main";
            this.Text = "ConfigureWrite";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox NameInput;
        private System.Windows.Forms.TextBox PasswordInput;
        private System.Windows.Forms.Button SaveChanges;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.TextBox InformationDisplay;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button Website;
    }
}

