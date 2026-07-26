namespace Taller_Automotriz
{
    partial class FrmMecanicos
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Britannic Bold", 18F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(371, 59);
            label1.Name = "label1";
            label1.Size = new Size(403, 40);
            label1.TabIndex = 0;
            label1.Text = "GESTIÓN DE MECANICOS";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(124, 173);
            label2.Name = "label2";
            label2.Size = new Size(143, 25);
            label2.TabIndex = 1;
            label2.Text = "Buscar mecánico";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(273, 173);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(586, 31);
            textBox1.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 48);
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 122, 204);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.Location = new Point(115, 229);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(889, 267);
            dataGridView1.TabIndex = 3;
            // 
            // button1
            // 
            button1.BackColor = Color.Gray;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = Color.White;
            button1.Location = new Point(880, 560);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 4;
            button1.Text = "Eliminar";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.Gray;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.White;
            button2.Location = new Point(712, 560);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 5;
            button2.Text = "Editar";
            button2.UseVisualStyleBackColor = false;
            // 
            // button3
            // 
            button3.BackColor = Color.Blue;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.ForeColor = Color.White;
            button3.Location = new Point(115, 560);
            button3.Name = "button3";
            button3.Size = new Size(178, 34);
            button3.TabIndex = 6;
            button3.Text = "Agregar Mecanico";
            button3.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.Location = new Point(892, 173);
            button4.Name = "button4";
            button4.Size = new Size(112, 34);
            button4.TabIndex = 7;
            button4.Text = "Buscar";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // FrmMecanicos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(30, 30, 30);
            ClientSize = new Size(1148, 670);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FrmMecanicos";
            Text = "FrmMecanicos";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
    }
}