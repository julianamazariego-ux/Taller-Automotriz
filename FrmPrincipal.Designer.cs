namespace Taller_Automotriz
{
    partial class FrmPrincipal
    {
       
        private System.ComponentModel.IContainer components = null;

        
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            menuStrip1 = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            clientesToolStripMenuItem = new ToolStripMenuItem();
            administrarClientesToolStripMenuItem = new ToolStripMenuItem();
            vehiculosToolStripMenuItem = new ToolStripMenuItem();
            administrarVehiculosToolStripMenuItem = new ToolStripMenuItem();
            mecanicosToolStripMenuItem = new ToolStripMenuItem();
            ordenesDeTrabajoToolStripMenuItem = new ToolStripMenuItem();
            nuevaOrdenToolStripMenuItem = new ToolStripMenuItem();
            ordenesAbiertasToolStripMenuItem = new ToolStripMenuItem();
            serviciosToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            repuestosToolStripMenuItem = new ToolStripMenuItem();
            verRepuestosToolStripMenuItem = new ToolStripMenuItem();
            salirToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.ActiveCaptionText;
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, clientesToolStripMenuItem, vehiculosToolStripMenuItem, mecanicosToolStripMenuItem, ordenesDeTrabajoToolStripMenuItem, serviciosToolStripMenuItem, toolStripMenuItem1, repuestosToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1021, 32);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(59, 28);
            inicioToolStripMenuItem.Text = "Inicio";
            inicioToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarClientesToolStripMenuItem });
            clientesToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            clientesToolStripMenuItem.Image = (Image)resources.GetObject("clientesToolStripMenuItem.Image");
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(99, 28);
            clientesToolStripMenuItem.Text = "Clientes";
            clientesToolStripMenuItem.Click += clientesToolStripMenuItem_Click;
            // 
            // administrarClientesToolStripMenuItem
            // 
            administrarClientesToolStripMenuItem.Name = "administrarClientesToolStripMenuItem";
            administrarClientesToolStripMenuItem.Size = new Size(225, 26);
            administrarClientesToolStripMenuItem.Text = "Administrar Clientes";
            administrarClientesToolStripMenuItem.Click += administrarClientesToolStripMenuItem_Click_1;
            // 
            // vehiculosToolStripMenuItem
            // 
            vehiculosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarVehiculosToolStripMenuItem });
            vehiculosToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            vehiculosToolStripMenuItem.Image = (Image)resources.GetObject("vehiculosToolStripMenuItem.Image");
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(109, 28);
            vehiculosToolStripMenuItem.Text = "Vehiculos";
            // 
            // administrarVehiculosToolStripMenuItem
            // 
            administrarVehiculosToolStripMenuItem.Name = "administrarVehiculosToolStripMenuItem";
            administrarVehiculosToolStripMenuItem.Size = new Size(234, 26);
            administrarVehiculosToolStripMenuItem.Text = "Administrar vehiculos";
            administrarVehiculosToolStripMenuItem.Click += administrarVehiculosToolStripMenuItem_Click;
            // 
            // mecanicosToolStripMenuItem
            // 
            mecanicosToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            mecanicosToolStripMenuItem.Image = (Image)resources.GetObject("mecanicosToolStripMenuItem.Image");
            mecanicosToolStripMenuItem.Name = "mecanicosToolStripMenuItem";
            mecanicosToolStripMenuItem.Size = new Size(117, 28);
            mecanicosToolStripMenuItem.Text = "Mecanicos";
            mecanicosToolStripMenuItem.Click += mecanicosToolStripMenuItem_Click;
            // 
            // ordenesDeTrabajoToolStripMenuItem
            // 
            ordenesDeTrabajoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaOrdenToolStripMenuItem, ordenesAbiertasToolStripMenuItem });
            ordenesDeTrabajoToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            ordenesDeTrabajoToolStripMenuItem.Image = (Image)resources.GetObject("ordenesDeTrabajoToolStripMenuItem.Image");
            ordenesDeTrabajoToolStripMenuItem.Name = "ordenesDeTrabajoToolStripMenuItem";
            ordenesDeTrabajoToolStripMenuItem.Size = new Size(175, 28);
            ordenesDeTrabajoToolStripMenuItem.Text = "Ordenes de trabajo";
            // 
            // nuevaOrdenToolStripMenuItem
            // 
            nuevaOrdenToolStripMenuItem.Name = "nuevaOrdenToolStripMenuItem";
            nuevaOrdenToolStripMenuItem.Size = new Size(224, 26);
            nuevaOrdenToolStripMenuItem.Text = "Nueva orden";
            nuevaOrdenToolStripMenuItem.Click += nuevaOrdenToolStripMenuItem_Click;
            // 
            // ordenesAbiertasToolStripMenuItem
            // 
            ordenesAbiertasToolStripMenuItem.Name = "ordenesAbiertasToolStripMenuItem";
            ordenesAbiertasToolStripMenuItem.Size = new Size(224, 26);
            ordenesAbiertasToolStripMenuItem.Text = "Ordenes abiertas";
            ordenesAbiertasToolStripMenuItem.Click += ordenesAbiertasToolStripMenuItem_Click;
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            serviciosToolStripMenuItem.Image = (Image)resources.GetObject("serviciosToolStripMenuItem.Image");
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(105, 28);
            serviciosToolStripMenuItem.Text = "Servicios";
            serviciosToolStripMenuItem.Click += serviciosToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 28);
            // 
            // repuestosToolStripMenuItem
            // 
            repuestosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verRepuestosToolStripMenuItem });
            repuestosToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            repuestosToolStripMenuItem.Image = (Image)resources.GetObject("repuestosToolStripMenuItem.Image");
            repuestosToolStripMenuItem.Name = "repuestosToolStripMenuItem";
            repuestosToolStripMenuItem.Size = new Size(115, 28);
            repuestosToolStripMenuItem.Text = "Repuestos";
            repuestosToolStripMenuItem.Click += repuestosToolStripMenuItem_Click;
            // 
            // verRepuestosToolStripMenuItem
            // 
            verRepuestosToolStripMenuItem.Name = "verRepuestosToolStripMenuItem";
            verRepuestosToolStripMenuItem.Size = new Size(247, 26);
            verRepuestosToolStripMenuItem.Text = "Ver repuestos y precios.";
            verRepuestosToolStripMenuItem.Click += verRepuestosToolStripMenuItem_Click;
            // 
            // salirToolStripMenuItem
            // 
            salirToolStripMenuItem.ForeColor = SystemColors.ButtonFace;
            salirToolStripMenuItem.Image = (Image)resources.GetObject("salirToolStripMenuItem.Image");
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(76, 28);
            salirToolStripMenuItem.Text = "Salir";
            salirToolStripMenuItem.Click += salirToolStripMenuItem_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1021, 550);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FrmPrincipal";
            Text = "Sistema de Órdenes de Trabajo - Taller Automotriz";
            Load += FrmPrincipal_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem clientesToolStripMenuItem;
        private ToolStripMenuItem vehiculosToolStripMenuItem;
        private ToolStripMenuItem mecanicosToolStripMenuItem;
        private ToolStripMenuItem ordenesDeTrabajoToolStripMenuItem;
        private ToolStripMenuItem serviciosToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem repuestosToolStripMenuItem;
        private ToolStripMenuItem administrarClientesToolStripMenuItem;
        private ToolStripMenuItem administrarVehiculosToolStripMenuItem;
        private ToolStripMenuItem nuevaOrdenToolStripMenuItem;
        private ToolStripMenuItem ordenesAbiertasToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem verRepuestosToolStripMenuItem;
    }
}
