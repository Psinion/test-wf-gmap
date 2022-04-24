namespace GmapImplementation
{
    partial class MainWindow
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
            this.MainMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.SuspendLayout();
            // 
            // MainMapControl
            // 
            this.MainMapControl.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.MainMapControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainMapControl.Bearing = 0F;
            this.MainMapControl.CanDragMap = true;
            this.MainMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.MainMapControl.GrayScaleMode = false;
            this.MainMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.MainMapControl.LevelsKeepInMemmory = 5;
            this.MainMapControl.Location = new System.Drawing.Point(12, 12);
            this.MainMapControl.MarkersEnabled = true;
            this.MainMapControl.MaxZoom = 2;
            this.MainMapControl.MinZoom = 2;
            this.MainMapControl.MouseWheelZoomEnabled = true;
            this.MainMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.MainMapControl.Name = "MainMapControl";
            this.MainMapControl.NegativeMode = false;
            this.MainMapControl.PolygonsEnabled = true;
            this.MainMapControl.RetryLoadTile = 0;
            this.MainMapControl.RoutesEnabled = true;
            this.MainMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.MainMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.MainMapControl.ShowTileGridLines = false;
            this.MainMapControl.Size = new System.Drawing.Size(772, 430);
            this.MainMapControl.TabIndex = 0;
            this.MainMapControl.Zoom = 0D;
            this.MainMapControl.OnMarkerEnter += new GMap.NET.WindowsForms.MarkerEnter(this.MainMapControl_OnMarkerEnter);
            this.MainMapControl.Load += new System.EventHandler(this.MainMapControl_Load);
            this.MainMapControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MainMapControl_MouseMove);
            this.MainMapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MainMapControl_MouseUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 454);
            this.Controls.Add(this.MainMapControl);
            this.Name = "MainWindow";
            this.Text = "GmapImplementation";
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl MainMapControl;
    }
}

