using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SuperMallManagerMVC
{
    public partial class PaymentForm : Form
    {
        private AddUpdateBillForm _objectAddUpdateBillForm;
        public PaymentForm()
        {
            InitializeComponent();
            CenterToParent();
        }

        public PaymentForm(AddUpdateBillForm objectAddUpdateBillForm) : this()
        {
            _objectAddUpdateBillForm = objectAddUpdateBillForm;
            ShowDataBill();
        }

        private void ShowDataBill()
        {
            textBoxBillId.Text = _objectAddUpdateBillForm?._billDetails?.IdBill.ToString();
            textBoxNameCustomerPayment.Text = _objectAddUpdateBillForm?._billDetails?.CartBill?.CustomerCart?.FullNamePerson.ToString();
            textBoxNameStaffPayment.Text = _objectAddUpdateBillForm?._billDetails?.StaffNameBillDetails?.ToString();
            textBoxTimeCreateBillPayment.Text = _objectAddUpdateBillForm?._billDetails?.CreateTimeBill.ToString("dd/MM/yyyy HH:mm:ss");
            textBoxTotalItemPayment.Text = $"{_objectAddUpdateBillForm._billDetails.TotalItemBill:N0}sp";
            textBoxTotaDiscountPayment.Text = $"{_objectAddUpdateBillForm._billDetails.TotalDiscountBill:N0}đ";
            textBoxTotaAmountPayment.Text = $"{_objectAddUpdateBillForm._billDetails.TotalAmountBill:N0}đ";

            textBoxBillId.Enabled = false;
            textBoxNameCustomerPayment.Enabled = false;
            textBoxNameStaffPayment.Enabled = false;
            textBoxTimeCreateBillPayment.Enabled = false;
            textBoxTotalItemPayment.Enabled = false;
            textBoxTotaDiscountPayment.Enabled = false;
            textBoxTotaAmountPayment.Enabled = false;
        }


        public void ViewDetail()
        {
            this.buttonCompletedPayment.Click -= new System.EventHandler(this.btnCompletedPaymentEventHandler);
            this.buttonCompletedPayment.Click += new System.EventHandler(this.btnUpdatePaymentEventHandler);
        }

        private void btnUpdatePaymentEventHandler(object sender, EventArgs e)
        {
            if (comboBoxPaymentsType.SelectedIndex == -1)
            {
                string title = "Warning: ";
                string content = "Please choose a payment method!";
                MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _objectAddUpdateBillForm._billDetails.PaymentMethodBillDetails = comboBoxPaymentsType.Text;
                _objectAddUpdateBillForm._billDetails.StatusBill = "Finish payment";
                Dispose();  
                _objectAddUpdateBillForm.UpdateBill(_objectAddUpdateBillForm._billDetails);
            }
        }

        private void btnCancelPaymentClickEventHandle(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to close the payment?", "Question:",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void btnCompletedPaymentEventHandler(object sender, EventArgs e)
        {
            if(comboBoxPaymentsType.SelectedIndex == -1)
            {
                string title = "Warning: ";
                string content = "Please choose a payment method!";
                MessageBox.Show(content,title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                _objectAddUpdateBillForm._billDetails.PaymentMethodBillDetails = comboBoxPaymentsType.Text;
                _objectAddUpdateBillForm._billDetails.StatusBill = "Finish payment";
                Dispose();
                _objectAddUpdateBillForm.CreateBill(_objectAddUpdateBillForm._billDetails);
            }
        }
    }
}
