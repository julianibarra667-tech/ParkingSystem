using System;
using ParkingSystem.core.Services;
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

            // Initialize parking lot: Capacity of 5 vehicles, $3.50 hourly rate
            _parkingService = new ParkingService(5, 3.50m);

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
                // UI Input Validation (Required field & blank space)
                string licensePlate = txtLicensePlate.Text.Trim();

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("License plate is required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLicensePlate.Focus();
                    return;
                }

                DateTime entryTime = dtpEntryTime.Value;

                // Call Business Logic
                _parkingService.RegisterEntry(licensePlate, entryTime);

                MessageBox.Show("Vehicle entry registered successfully!", "Success",
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
                MessageBox.Show(ex.Message, "Business Rule Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                // UI Input Validation
                string licensePlate = txtLicensePlate.Text.Trim();

                if (string.IsNullOrWhiteSpace(licensePlate))
                {
                    MessageBox.Show("License plate is required to process exit.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLicensePlate.Focus();
                    return;
                }

                // Check if vehicle is parked
                if (!_parkingService.IsVehicleParked(licensePlate))
                {
                    MessageBox.Show("This vehicle is not currently parked in the lot.", "Vehicle Not Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLicensePlate.Focus();
                    return;
                }

                DateTime exitTime = dtpExitTime.Value;

                // Call Business Logic
                decimal totalFee = _parkingService.RegisterExit(licensePlate, exitTime);

                MessageBox.Show($"Vehicle exit registered successfully!\n\nTotal Fee to Pay: ${totalFee:F2}",
                    "Exit Processed", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
            // Refresh Grid Data
            dgvParkedVehicles.DataSource = null;
            dgvParkedVehicles.DataSource = _parkingService.GetCurrentlyParkedVehicles();

            // Update Capacity Status
            bool available = _parkingService.HasAvailableSpace();
            lblStatus.Text = available ? "Status: AVAILABLE" : "Status: FULL";
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