﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DarrenLee.Media;

namespace UI.UserControls
{
    public partial class CameraControl : UserControl
    {
        
        int count = 0;
        Camera cam = new Camera();
        public CameraControl()
        {
            
            InitializeComponent();
            GetInfo();
            cam.OnFrameArrived += MyCamera_OnFrameArrived;

        }
        private void GetInfo()
        {
            var cameraDevices = cam.GetCameraSources();
            var cameraResolutions = cam.GetSupportedResolutions();
            foreach (var d in cameraDevices)
            {
                cmbCameraDevices.Items.Add(d);
            }
            foreach (var d in cameraResolutions)
            {
                cmdCameraResolutions.Items.Add(d);
            }
            cmbCameraDevices.SelectedIndex = 0;
            cmdCameraResolutions.SelectedIndex = 0;
        }
        
        private void MyCamera_OnFrameArrived(object source, FrameArrivedEventArgs e)
        {
            Image img = e.GetFrame();
            pictureBox1.Image = img;
        }
        private void cmdCameraResolutions_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cam.Start(cmdCameraResolutions.SelectedIndex);
        }

        private void cmbCameraDevices_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            cam.ChangeCamera(cmbCameraDevices.SelectedIndex);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string filename = Application.StartupPath + @"\" + "Image" + count.ToString();
            cam.Capture(filename);
            count++;
        }

        private void CameraControl_VisibleChanged(object sender, EventArgs e)
        {
                if(!this.Visible)
                {
                    cam.Stop();
                    pictureBox1.Image = null;
                }
            else { cam.Start(cmdCameraResolutions.SelectedIndex); }
        }
        public void CloseCamera()
        {
            cam.Stop();
        }
        
    }
}
