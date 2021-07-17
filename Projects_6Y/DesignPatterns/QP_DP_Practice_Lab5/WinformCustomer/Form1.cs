using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using InterfaceCustomer;
using FactoryCustomer;
using IDal;
using FactoryDAL;

namespace WinformCustomer
{
    public partial class frmCustomer : Form
    {
        private CustomerBase custBase = null;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void SetCustomer()
        {
            custBase.CustomerName = txtCustomerName.Text;
            custBase.Address = addressTxtBox.Text;
            decimal billAmt = 0;
            bool result = decimal.TryParse(txtBoxBillAmt.Text, out billAmt);
            custBase.BillDate = DateTime.Now;
            custBase.BillAmount = billAmt;
            custBase.PhoneNumber = phoneNoTxtBox.Text;
            custBase.CustomerType = cmbCustomerType.Text;

        }


        private void validateButton_Click(object sender, EventArgs e)
        {
            SetCustomer();
            custBase.Validate();
        }

        private void OnIndexChange(object sender, EventArgs e)
        {
            custBase = Factory<CustomerBase>.CreateObject(cmbCustomerType.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            SetCustomer();
            IRepository<CustomerBase> dal = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject(cmbDALList.Text);
            dal.Add(custBase);
            dal.Save();

            MessageBox.Show("database updated");
            LoadGrid();


        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            if (cmbDALList.Text.ToString() != string.Empty)
            {
                IRepository<CustomerBase> dal = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject(cmbDALList.Text);
                List<CustomerBase> custList = dal.Search();
                dtgGridCustomer.DataSource = custList;
            }

        }

        private void OnDalLayerChange(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void dtgGridCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnUOW_Click(object sender, EventArgs e)
        {

            IUow uow = null;
            try
            {
                uow = FactoryDALLayer<IUow>.CreateObject("AdoUOW");
                CustomerBase cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "cust1";
                cust1.PhoneNumber = "9090";
                cust1.Address = "ddddchennai";
                cust1.BillAmount = 111;


                IRepository<CustomerBase> dal = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject("ADODal");
                dal.SetUnitWork(uow);
                dal.Add(cust1);
                dal.Save();
                IRepository<CustomerBase> dal1 = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject("ADODal");

                CustomerBase cust2 = new CustomerBase();
                cust2.CustomerType = "Customer";
                cust2.CustomerName = "dummyName";
                cust2.Address = "addres";
                cust2.PhoneNumber = "9090";
                cust2.BillAmount = 111;

                dal1.SetUnitWork(uow);
                dal1.Add(cust2);
                dal1.Save();

                uow.Committ();


            }
            catch (Exception ex)
            {
                uow.RollBack();
                MessageBox.Show(ex.Message);
            }

        }

        private void btnETUOW_Click(object sender, EventArgs e)
        {
            IUow uow = null;
            try
            {
                uow = FactoryDALLayer<IUow>.CreateObject("EfUOW");
                CustomerBase cust1 = new CustomerBase();
                cust1.CustomerType = "Lead";
                cust1.CustomerName = "cust1";
                cust1.PhoneNumber = "9090";
                cust1.Address = "ddddchennai";
                cust1.BillAmount = 111;


                IRepository<CustomerBase> dal = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject("EfDal");
                dal.SetUnitWork(uow);
                dal.Add(cust1);
                dal.Save();
                IRepository<CustomerBase> dal1 = FactoryDALLayer<IRepository<CustomerBase>>.CreateObject("EfDal");

                CustomerBase cust2 = new CustomerBase();
                cust2.CustomerType = "Customer";
                cust2.CustomerName = "dummyName";
                cust2.Address = "addres";
                cust2.PhoneNumber = "9090";
                cust2.BillAmount = 111;

                dal1.SetUnitWork(uow);
                dal1.Add(cust2);
                dal1.Save();

                uow.Committ();


            }
            catch (Exception ex)
            {
                uow.RollBack();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
