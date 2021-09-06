
namespace VersionUpdater.Net.Helpers.Forms
{
    partial class UpdateMessageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateMessageForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonUpdateLater = new System.Windows.Forms.Button();
            this.labelUpdateMessage = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelViewUpdateNotes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // buttonUpdate
            // 
            resources.ApplyResources(this.buttonUpdate, "buttonUpdate");
            this.buttonUpdate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(105)))), ((int)(((byte)(242)))));
            this.buttonUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdate.ForeColor = System.Drawing.Color.White;
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            // 
            // buttonUpdateLater
            // 
            resources.ApplyResources(this.buttonUpdateLater, "buttonUpdateLater");
            this.buttonUpdateLater.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(75)))), ((int)(((byte)(75)))));
            this.buttonUpdateLater.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUpdateLater.ForeColor = System.Drawing.Color.White;
            this.buttonUpdateLater.Name = "buttonUpdateLater";
            this.buttonUpdateLater.UseVisualStyleBackColor = false;
            // 
            // labelUpdateMessage
            // 
            resources.ApplyResources(this.labelUpdateMessage, "labelUpdateMessage");
            this.labelUpdateMessage.Name = "labelUpdateMessage";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // labelViewUpdateNotes
            // 
            resources.ApplyResources(this.labelViewUpdateNotes, "labelViewUpdateNotes");
            this.labelViewUpdateNotes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.labelViewUpdateNotes.Name = "labelViewUpdateNotes";
            // 
            // UpdateMessageForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelViewUpdateNotes);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelUpdateMessage);
            this.Controls.Add(this.buttonUpdateLater);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.pictureBox1);
            this.Name = "UpdateMessageForm";
            this.TextAlign = System.Windows.Forms.VisualStyles.HorizontalAlign.Center;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Button buttonUpdate;
        public System.Windows.Forms.Button buttonUpdateLater;
        public System.Windows.Forms.Label labelUpdateMessage;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelViewUpdateNotes;
    }
}