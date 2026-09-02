using ParkingSystem.core.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ParkingSystem.UI
{
    public partial class MainForm : Form
    {
        private readonly ParkingService _parkingService;

        public MainForm()
        {
            InitializeComponent();

            _parkingService = new ParkingService(5, 1500m);

            InitializeCustomComponents();
            UpdateDashboard();
        }

        private void InitializeCustomComponents()
        {
            dtpEntryTime.Value = DateTime.Now;
            dtpExitTime.Value = DateTime.Now;
        }

        private void btnRegisterEntry_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar espacios en blanco y otros errores de entrada
                string licensePlate = txtLicensePlate.Text.Trim();

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("Matricula Requerida.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLicensePlate.Focus();
                    return;
                }

                DateTime entryTime = dtpEntryTime.Value;

                // logica de parq
                _parkingService.RegisterEntry(licensePlate, entryTime);

                MessageBox.Show("El vehiculo se registr exitosamente", "Excelente",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                UpdateDashboard();
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Erorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegisterExit_Click(object sender, EventArgs e)
        {
            try
            {
                // validacion
                string licensePlate = txtLicensePlate.Text.Trim();

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("Es necesaria la matricula para la salida", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLicensePlate.Focus();
                    return;
                }

                DateTime exitTime = dtpExitTime.Value;

                // logica de negocio
                decimal totalFee = _parkingService.RegisterExit(licensePlate, exitTime);

                MessageBox.Show($"El vehiculo se registr exitosamente!\n\nTotal: ${totalFee:F2}",
                    "Fin del proceso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearInputs();
                UpdateDashboard();
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show(ex.Message, "Not Found Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message, "Business Rule Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateDashboard()
        {
            // Refrescar lainformación de los vehículos estacionados
            dgvParkedVehicles.DataSource = null;
            dgvParkedVehicles.DataSource = _parkingService.GetCurrentlyParkedVehicles();

            // Actualizar capacidad
            bool available = _parkingService.HasAvailableSpace();
            lblStatus.Text = available ? "Disponible" : "Lleno";
            lblStatus.ForeColor = available ? Color.Green : Color.Red;
        }

        private void ClearInputs()
        {
            txtLicensePlate.Clear();
            dtpEntryTime.Value = DateTime.Now;
            dtpExitTime.Value = DateTime.Now;
        }
    }
}
