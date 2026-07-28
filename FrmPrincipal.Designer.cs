namespace Taller_Automotriz
{
    partial class FrmPrincipal
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
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
            historialDeOrdenesToolStripMenuItem = new ToolStripMenuItem();
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
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, clientesToolStripMenuItem, vehiculosToolStripMenuItem, mecanicosToolStripMenuItem, ordenesDeTrabajoToolStripMenuItem, serviciosToolStripMenuItem, toolStripMenuItem1, repuestosToolStripMenuItem, salirToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(7, 2, 0, 2);
            menuStrip1.RenderMode = ToolStripRenderMode.System;
            menuStrip1.Size = new Size(1021, 28);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            menuStrip1.ItemClicked += menuStrip1_ItemClicked;
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(59, 24);
            inicioToolStripMenuItem.Text = "Inicio";
            inicioToolStripMenuItem.Click += inicioToolStripMenuItem_Click;
            // 
            // clientesToolStripMenuItem
            // 
            clientesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { administrarClientesToolStripMenuItem });
            clientesToolStripMenuItem.Name = "clientesToolStripMenuItem";
            clientesToolStripMenuItem.Size = new Size(75, 24);
            clientesToolStripMenuItem.Text = "Clientes";
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
            vehiculosToolStripMenuItem.Name = "vehiculosToolStripMenuItem";
            vehiculosToolStripMenuItem.Size = new Size(85, 24);
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
            mecanicosToolStripMenuItem.Name = "mecanicosToolStripMenuItem";
            mecanicosToolStripMenuItem.Size = new Size(93, 24);
            mecanicosToolStripMenuItem.Text = "Mecanicos";
            mecanicosToolStripMenuItem.Click += mecanicosToolStripMenuItem_Click;
            // 
            // ordenesDeTrabajoToolStripMenuItem
            // 
            ordenesDeTrabajoToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { nuevaOrdenToolStripMenuItem, ordenesAbiertasToolStripMenuItem, historialDeOrdenesToolStripMenuItem });
            ordenesDeTrabajoToolStripMenuItem.Name = "ordenesDeTrabajoToolStripMenuItem";
            ordenesDeTrabajoToolStripMenuItem.Size = new Size(151, 24);
            ordenesDeTrabajoToolStripMenuItem.Text = "Ordenes de trabajo";
            // 
            // nuevaOrdenToolStripMenuItem
            // 
            nuevaOrdenToolStripMenuItem.Name = "nuevaOrdenToolStripMenuItem";
            nuevaOrdenToolStripMenuItem.Size = new Size(226, 26);
            nuevaOrdenToolStripMenuItem.Text = "Nueva orden";
            nuevaOrdenToolStripMenuItem.Click += nuevaOrdenToolStripMenuItem_Click;
            // 
            // ordenesAbiertasToolStripMenuItem
            // 
            ordenesAbiertasToolStripMenuItem.Name = "ordenesAbiertasToolStripMenuItem";
            ordenesAbiertasToolStripMenuItem.Size = new Size(226, 26);
            ordenesAbiertasToolStripMenuItem.Text = "Ordenes abiertas";
            // 
            // historialDeOrdenesToolStripMenuItem
            // 
            historialDeOrdenesToolStripMenuItem.Name = "historialDeOrdenesToolStripMenuItem";
            historialDeOrdenesToolStripMenuItem.Size = new Size(226, 26);
            historialDeOrdenesToolStripMenuItem.Text = "Historial de ordenes";
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(81, 24);
            serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(14, 24);
            // 
            // repuestosToolStripMenuItem
            // 
            repuestosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { verRepuestosToolStripMenuItem });
            repuestosToolStripMenuItem.Name = "repuestosToolStripMenuItem";
            repuestosToolStripMenuItem.Size = new Size(91, 24);
            repuestosToolStripMenuItem.Text = "Repuestos";
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
            salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            salirToolStripMenuItem.Size = new Size(52, 24);
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
        private ToolStripMenuItem historialDeOrdenesToolStripMenuItem;
        private ToolStripMenuItem salirToolStripMenuItem;
        private ToolStripMenuItem verRepuestosToolStripMenuItem;
    }
}
