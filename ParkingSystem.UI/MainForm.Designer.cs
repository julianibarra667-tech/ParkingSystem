namespace ParkingSystem.UI
{
    partial class MainForm
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
            gbRegister = new GroupBox();
            lblLicensePlate = new Label();
            txtLicensePlate = new TextBox();
            lblEntryTime = new Label();
            dtpEntryTime = new DateTimePicker();
            lblExitTime = new Label();
            dtpExitTime = new DateTimePicker();
            btnRegisterEntry = new Button();
            btnRegisterExit = new Button();
            lblStatus = new Label();
            dgvParkedVehicles = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvParkedVehicles).BeginInit();
            gbRegister.SuspendLayout();
            SuspendLayout();
            // 
            // gbRegister
            // 
            gbRegister.Controls.Add(dtpExitTime);
            gbRegister.Controls.Add(lblExitTime);
            gbRegister.Controls.Add(dtpEntryTime);
            gbRegister.Controls.Add(lblEntryTime);
            gbRegister.Controls.Add(txtLicensePlate);
            gbRegister.Controls.Add(lblLicensePlate);
            gbRegister.Location = new Point(36, 22);
            gbRegister.Name = "gbRegister";
            gbRegister.Size = new Size(553, 159);
            gbRegister.TabIndex = 0;
            gbRegister.TabStop = false;
            gbRegister.Text = "Registrar Vehículo";
            // 
            // lblLicensePlate
            // 
            lblLicensePlate.AutoSize = true;
            lblLicensePlate.Location = new Point(20, 30);
            lblLicensePlate.Name = "lblLicensePlate";
            lblLicensePlate.Size = new Size(57, 15);
            lblLicensePlate.TabIndex = 1;
            lblLicensePlate.Text = "Matrícula";
            // 
            // txtLicensePlate
            // 
            txtLicensePlate.Location = new Point(130, 27);
            txtLicensePlate.Name = "txtLicensePlate";
            txtLicensePlate.Size = new Size(150, 23);
            txtLicensePlate.TabIndex = 2;
            // 
            // lblEntryTime
            // 
            lblEntryTime.AutoSize = true;
            lblEntryTime.Location = new Point(20, 60);
            lblEntryTime.Name = "lblEntryTime";
            lblEntryTime.Size = new Size(92, 15);
            lblEntryTime.TabIndex = 3;
            lblEntryTime.Text = "Hora de entrada";
            // 
            // dtpEntryTime
            // 
            dtpEntryTime.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpEntryTime.Format = DateTimePickerFormat.Custom;
            dtpEntryTime.Location = new Point(130, 57);
            dtpEntryTime.Name = "dtpEntryTime";
            dtpEntryTime.Size = new Size(200, 23);
            dtpEntryTime.TabIndex = 4;
            // 
            // lblExitTime
            // 
            lblExitTime.AutoSize = true;
            lblExitTime.Location = new Point(20, 90);
            lblExitTime.Name = "lblExitTime";
            lblExitTime.Size = new Size(82, 15);
            lblExitTime.TabIndex = 5;
            lblExitTime.Text = "Hora de salida";
            // 
            // dtpExitTime
            // 
            dtpExitTime.CustomFormat = "yyyy-MM-dd HH:mm";
            dtpExitTime.Format = DateTimePickerFormat.Custom;
            dtpExitTime.Location = new Point(130, 87);
            dtpExitTime.Name = "dtpExitTime";
            dtpExitTime.Size = new Size(200, 23);
            dtpExitTime.TabIndex = 6;
            // 
            // btnRegisterEntry
            // 
            btnRegisterEntry.Location = new Point(36, 190);
            btnRegisterEntry.Name = "btnRegisterEntry";
            btnRegisterEntry.Size = new Size(130, 35);
            btnRegisterEntry.TabIndex = 7;
            btnRegisterEntry.Text = "Registrar Entrada";
            btnRegisterEntry.UseVisualStyleBackColor = true;
            btnRegisterEntry.Click += btnRegisterEntry_Click;
            // 
            // btnRegisterExit
            // 
            btnRegisterExit.Location = new Point(182, 190);
            btnRegisterExit.Name = "btnRegisterExit";
            btnRegisterExit.Size = new Size(130, 35);
            btnRegisterExit.TabIndex = 8;
            btnRegisterExit.Text = "Registrar Salida";
            btnRegisterExit.UseVisualStyleBackColor = true;
            btnRegisterExit.Click += btnRegisterExit_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(36, 240);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(112, 15);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Estado: DISPONIBLE";
            // 
            // dgvParkedVehicles
            // 
            dgvParkedVehicles.AllowUserToOrderColumns = true;
            dgvParkedVehicles.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvParkedVehicles.Location = new Point(36, 265);
            dgvParkedVehicles.Name = "dgvParkedVehicles";
            dgvParkedVehicles.ReadOnly = true;
            dgvParkedVehicles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvParkedVehicles.Size = new Size(728, 165);
            dgvParkedVehicles.TabIndex = 10;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvParkedVehicles);
            Controls.Add(lblStatus);
            Controls.Add(btnRegisterExit);
            Controls.Add(btnRegisterEntry);
            Controls.Add(gbRegister);
            Name = "MainForm";
            Text = "Parking System";
            ((System.ComponentModel.ISupportInitialize)dgvParkedVehicles).EndInit();
            gbRegister.ResumeLayout(false);
            gbRegister.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox gbRegister;
        private Label lblLicensePlate;
        private TextBox txtLicensePlate;
        private Label lblEntryTime;
        private DateTimePicker dtpEntryTime;
        private Button btnRegisterEntry;
        private Button btnRegisterExit;
        private Label lblStatus;
        private DataGridView dgvParkedVehicles;
        private Label lblExitTime;
        private DateTimePicker dtpExitTime;
    }
}
