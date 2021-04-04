namespace DartClassCreator
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonGenerateCode = new System.Windows.Forms.Button();
            this.richTextBoxGeneratedCode = new System.Windows.Forms.RichTextBox();
            this.richTextBoxFields = new System.Windows.Forms.RichTextBox();
            this.textBoxClassName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonGenerateCode
            // 
            this.buttonGenerateCode.Location = new System.Drawing.Point(139, 37);
            this.buttonGenerateCode.Name = "buttonGenerateCode";
            this.buttonGenerateCode.Size = new System.Drawing.Size(115, 38);
            this.buttonGenerateCode.TabIndex = 0;
            this.buttonGenerateCode.Text = "Generate code";
            this.buttonGenerateCode.UseVisualStyleBackColor = true;
            this.buttonGenerateCode.Click += new System.EventHandler(this.buttonGenerateCode_Click);
            // 
            // richTextBoxGeneratedCode
            // 
            this.richTextBoxGeneratedCode.Location = new System.Drawing.Point(366, 81);
            this.richTextBoxGeneratedCode.Name = "richTextBoxGeneratedCode";
            this.richTextBoxGeneratedCode.Size = new System.Drawing.Size(410, 583);
            this.richTextBoxGeneratedCode.TabIndex = 1;
            this.richTextBoxGeneratedCode.Text = "";
            // 
            // richTextBoxFields
            // 
            this.richTextBoxFields.Location = new System.Drawing.Point(71, 139);
            this.richTextBoxFields.Name = "richTextBoxFields";
            this.richTextBoxFields.Size = new System.Drawing.Size(267, 273);
            this.richTextBoxFields.TabIndex = 2;
            this.richTextBoxFields.Text = "";
            // 
            // textBoxClassName
            // 
            this.textBoxClassName.Location = new System.Drawing.Point(139, 95);
            this.textBoxClassName.Name = "textBoxClassName";
            this.textBoxClassName.Size = new System.Drawing.Size(128, 22);
            this.textBoxClassName.TabIndex = 3;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 689);
            this.Controls.Add(this.textBoxClassName);
            this.Controls.Add(this.richTextBoxFields);
            this.Controls.Add(this.richTextBoxGeneratedCode);
            this.Controls.Add(this.buttonGenerateCode);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "Class Creator";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.TextBox textBoxClassName;

        private System.Windows.Forms.RichTextBox richTextBoxFields;

        private System.Windows.Forms.RichTextBox richTextBoxGeneratedCode;

        private System.Windows.Forms.Button buttonGenerateCode;

        #endregion
    }
}