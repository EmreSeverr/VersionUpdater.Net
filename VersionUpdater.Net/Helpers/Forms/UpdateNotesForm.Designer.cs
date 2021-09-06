
namespace VersionUpdater.Net.Helpers.Forms
{
    partial class UpdateNotesForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateNotesForm));
            this.richTextBoxUpdateNotes = new System.Windows.Forms.RichTextBox();
            this.labelUpdateMessage = new System.Windows.Forms.Label();
            this.buttonClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxUpdateNotes
            // 
            this.richTextBoxUpdateNotes.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.richTextBoxUpdateNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.richTextBoxUpdateNotes, "richTextBoxUpdateNotes");
            this.richTextBoxUpdateNotes.Name = "richTextBoxUpdateNotes";
            this.richTextBoxUpdateNotes.ReadOnly = true;
            // 
            // labelUpdateMessage
            // 
            resources.ApplyResources(this.labelUpdateMessage, "labelUpdateMessage");
            this.labelUpdateMessage.Name = "labelUpdateMessage";
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.DarkRed;
            this.buttonClose.ForeColor = System.Drawing.Color.White;
            resources.ApplyResources(this.buttonClose, "buttonClose");
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // UpdateNotesForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.labelUpdateMessage);
            this.Controls.Add(this.richTextBoxUpdateNotes);
            this.Name = "UpdateNotesForm";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox richTextBoxUpdateNotes;
        public System.Windows.Forms.Label labelUpdateMessage;
        private System.Windows.Forms.Button buttonClose;
    }
}