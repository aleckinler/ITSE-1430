
namespace MovieLib.WinHost
{
    partial class MovieForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
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
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this._txtTitle = new System.Windows.Forms.TextBox();
            this._txtGenre = new System.Windows.Forms.TextBox();
            this._txtDescription = new System.Windows.Forms.TextBox();
            this._chIsClassic = new System.Windows.Forms.CheckBox();
            this._ddlRating = new System.Windows.Forms.ComboBox();
            this._txtReleaseYear = new System.Windows.Forms.TextBox();
            this._txtDuration = new System.Windows.Forms.TextBox();
            this._btSave = new System.Windows.Forms.Button();
            this._btCancel = new System.Windows.Forms.Button();
            this._lblRating = new System.Windows.Forms.Label();
            this._lblTitle = new System.Windows.Forms.Label();
            this._lblGenre = new System.Windows.Forms.Label();
            this._lblDuration = new System.Windows.Forms.Label();
            this._lblReleaseYear = new System.Windows.Forms.Label();
            this._lblDescription = new System.Windows.Forms.Label();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // _txtTitle
            // 
            this._txtTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtTitle.Location = new System.Drawing.Point(125, 35);
            this._txtTitle.Name = "_txtTitle";
            this._txtTitle.Size = new System.Drawing.Size(468, 23);
            this._txtTitle.TabIndex = 1;
            this._txtTitle.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateTitle);
            // 
            // _txtGenre
            // 
            this._txtGenre.Location = new System.Drawing.Point(125, 124);
            this._txtGenre.Name = "_txtGenre";
            this._txtGenre.Size = new System.Drawing.Size(100, 23);
            this._txtGenre.TabIndex = 4;
            this._txtGenre.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateGenre);
            // 
            // _txtDescription
            // 
            this._txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._txtDescription.Location = new System.Drawing.Point(125, 182);
            this._txtDescription.Multiline = true;
            this._txtDescription.Name = "_txtDescription";
            this._txtDescription.Size = new System.Drawing.Size(468, 104);
            this._txtDescription.TabIndex = 7;
            // 
            // _chIsClassic
            // 
            this._chIsClassic.AutoSize = true;
            this._chIsClassic.Location = new System.Drawing.Point(455, 66);
            this._chIsClassic.Name = "_chIsClassic";
            this._chIsClassic.Size = new System.Drawing.Size(138, 19);
            this._chIsClassic.TabIndex = 6;
            this._chIsClassic.Text = "Is This Movie Classic?";
            this._chIsClassic.UseVisualStyleBackColor = true;
            // 
            // _ddlRating
            // 
            this._ddlRating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ddlRating.FormattingEnabled = true;
            this._ddlRating.Items.AddRange(new object[] {
            "G",
            "PG",
            "PG-13",
            "R",
            "NASTAYYY"});
            this._ddlRating.Location = new System.Drawing.Point(125, 153);
            this._ddlRating.Name = "_ddlRating";
            this._ddlRating.Size = new System.Drawing.Size(100, 23);
            this._ddlRating.TabIndex = 5;
            this._ddlRating.SelectedIndexChanged += new System.EventHandler(this._ddlRating_SelectedIndexChanged);
            // 
            // _txtReleaseYear
            // 
            this._txtReleaseYear.Location = new System.Drawing.Point(125, 64);
            this._txtReleaseYear.Name = "_txtReleaseYear";
            this._txtReleaseYear.Size = new System.Drawing.Size(100, 23);
            this._txtReleaseYear.TabIndex = 2;
            this._txtReleaseYear.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateReleaseYear);
            // 
            // _txtDuration
            // 
            this._txtDuration.Location = new System.Drawing.Point(125, 95);
            this._txtDuration.Name = "_txtDuration";
            this._txtDuration.Size = new System.Drawing.Size(100, 23);
            this._txtDuration.TabIndex = 3;
            this._txtDuration.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateDuration);
            // 
            // _btSave
            // 
            this._btSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btSave.Location = new System.Drawing.Point(437, 330);
            this._btSave.Name = "_btSave";
            this._btSave.Size = new System.Drawing.Size(75, 23);
            this._btSave.TabIndex = 8;
            this._btSave.Text = "Save";
            this._btSave.UseVisualStyleBackColor = true;
            this._btSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btCancel
            // 
            this._btCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._btCancel.CausesValidation = false;
            this._btCancel.Location = new System.Drawing.Point(518, 330);
            this._btCancel.Name = "_btCancel";
            this._btCancel.Size = new System.Drawing.Size(75, 23);
            this._btCancel.TabIndex = 9;
            this._btCancel.Text = "Cancel";
            this._btCancel.UseVisualStyleBackColor = true;
            this._btCancel.Click += new System.EventHandler(this.OnCancel);
            // 
            // _lblRating
            // 
            this._lblRating.AutoSize = true;
            this._lblRating.Location = new System.Drawing.Point(78, 156);
            this._lblRating.Name = "_lblRating";
            this._lblRating.Size = new System.Drawing.Size(41, 15);
            this._lblRating.TabIndex = 9;
            this._lblRating.Text = "Rating";
            // 
            // _lblTitle
            // 
            this._lblTitle.AutoSize = true;
            this._lblTitle.Location = new System.Drawing.Point(54, 38);
            this._lblTitle.Name = "_lblTitle";
            this._lblTitle.Size = new System.Drawing.Size(65, 15);
            this._lblTitle.TabIndex = 10;
            this._lblTitle.Text = "Movie Title";
            // 
            // _lblGenre
            // 
            this._lblGenre.AutoSize = true;
            this._lblGenre.Location = new System.Drawing.Point(81, 127);
            this._lblGenre.Name = "_lblGenre";
            this._lblGenre.Size = new System.Drawing.Size(38, 15);
            this._lblGenre.TabIndex = 11;
            this._lblGenre.Text = "Genre";
            // 
            // _lblDuration
            // 
            this._lblDuration.AutoSize = true;
            this._lblDuration.Location = new System.Drawing.Point(12, 98);
            this._lblDuration.Name = "_lblDuration";
            this._lblDuration.Size = new System.Drawing.Size(107, 15);
            this._lblDuration.TabIndex = 12;
            this._lblDuration.Text = "Duration (minutes)";
            // 
            // _lblReleaseYear
            // 
            this._lblReleaseYear.AutoSize = true;
            this._lblReleaseYear.Location = new System.Drawing.Point(48, 67);
            this._lblReleaseYear.Name = "_lblReleaseYear";
            this._lblReleaseYear.Size = new System.Drawing.Size(71, 15);
            this._lblReleaseYear.TabIndex = 13;
            this._lblReleaseYear.Text = "Release Year";
            // 
            // _lblDescription
            // 
            this._lblDescription.AutoSize = true;
            this._lblDescription.Location = new System.Drawing.Point(54, 185);
            this._lblDescription.Name = "_lblDescription";
            this._lblDescription.Size = new System.Drawing.Size(67, 15);
            this._lblDescription.TabIndex = 14;
            this._lblDescription.Text = "Description";
            // 
            // _errors
            // 
            this._errors.ContainerControl = this;
            // 
            // MovieForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 365);
            this.Controls.Add(this._lblDescription);
            this.Controls.Add(this._lblReleaseYear);
            this.Controls.Add(this._lblDuration);
            this.Controls.Add(this._lblGenre);
            this.Controls.Add(this._lblTitle);
            this.Controls.Add(this._lblRating);
            this.Controls.Add(this._btCancel);
            this.Controls.Add(this._btSave);
            this.Controls.Add(this._txtDuration);
            this.Controls.Add(this._txtReleaseYear);
            this.Controls.Add(this._ddlRating);
            this.Controls.Add(this._chIsClassic);
            this.Controls.Add(this._txtDescription);
            this.Controls.Add(this._txtGenre);
            this.Controls.Add(this._txtTitle);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.Name = "MovieForm";
            this.Text = "Add Movie";
            this.Click += new System.EventHandler(this._ddlRating_SelectedIndexChanged);
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox _txtTitle;
        private System.Windows.Forms.TextBox _txtGenre;
        private System.Windows.Forms.TextBox _txtDescription;
        private System.Windows.Forms.CheckBox _chIsClassic;
        private System.Windows.Forms.ComboBox _ddlRating;
        private System.Windows.Forms.TextBox _txtReleaseYear;
        private System.Windows.Forms.TextBox _txtDuration;
        private System.Windows.Forms.Button _btSave;
        private System.Windows.Forms.Button _btCancel;
        private System.Windows.Forms.Label _lblRating;
        private System.Windows.Forms.Label _lblTitle;
        private System.Windows.Forms.Label _lblGenre;
        private System.Windows.Forms.Label _lblDuration;
        private System.Windows.Forms.Label _lblReleaseYear;
        private System.Windows.Forms.Label _lblDescription;
        private System.Windows.Forms.ErrorProvider _errors;
    }
}