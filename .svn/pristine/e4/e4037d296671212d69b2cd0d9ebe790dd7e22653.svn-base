using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MODEL;
using SERVICE.IService;
using SERVICE.Service;

namespace HNSSApplication
{
    public partial class FrmProductEntry : Form
    {
        private readonly IBrandService _brandService;
        private readonly IFlavourService _flavourService;
        private readonly IUnitService _unitService;
        private readonly IProductionMaterialService _productionMaterialService;
        private readonly IProductService _productService;
        public FrmProductEntry()
        {
            InitializeComponent();
            _brandService = new BrandService();
            _flavourService = new FlavourService();
            _unitService = new UnitService();
            _productionMaterialService = new ProductionMaterialService();
            _productService = new ProductService();
            LoadCombos();
        }

        private void LoadCombos()
        {
            var dtBrand = _brandService.GetAllBrands();
            cmbBrand.DataSource = dtBrand;
            cmbBrand.ValueMember = "BrandId";
            cmbBrand.DisplayMember = "BrandName";
            cmbBrand.Refresh();

            var dtFlavour = _flavourService.GetAllFlavours();
            cmbFlavour.DataSource = dtFlavour;
            cmbFlavour.ValueMember = "FlavourId";
            cmbFlavour.DisplayMember = "FlavourName";
            cmbFlavour.Refresh();

            var dtUnit = _unitService.GetAllData();
            cmbUnit.DataSource = dtUnit;
            cmbUnit.ValueMember = "UnitofMeasurementId";
            cmbUnit.DisplayMember = "UnitName";
            cmbUnit.Refresh();

            var dtProductionMaterial = _productionMaterialService.GetProductionMaterial();
            cmbMaterial.DataSource = dtProductionMaterial;
            cmbMaterial.ValueMember = "ProductionMaterialId";
            cmbMaterial.DisplayMember = "MaterialName";
            cmbMaterial.Refresh();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grdData.Rows.Add(0, cmbMaterial.SelectedValue, cmbMaterial.Text, txtBatchQty.Value, txtCartoonQty.Value);
        }

        private void FrmProductEntry_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var listNormDetails = grdData.Rows.Select(t => new ProductNormTemplateDetailModel()
            {
                ProductionMaterialId =Convert.ToInt32(t.Cells["MaterialId"].Value),
                BatchQuantity = Convert.ToDecimal(t.Cells["BatchQty"].Value),
                CartoonQuantity = Convert.ToDecimal(t.Cells["CartoonQty"].Value)
            }).ToList();

            var normtemplateModel = new ProductNormTemplateModel()
            {
                OutputQuantity = txtOutputQty.Value,
                WasteQuantity = txtWasteQty.Value,
                PreparedBy = 1,
                PreparedDate = DateTime.Now.Date
            };
            var proModel = new ProductModel()
            {
                BrandId = (int)cmbBrand.SelectedValue,
                ExerciseDuty = Convert.ToByte(chkExerciseDuty.Checked),
                IsVat = Convert.ToByte(chkVAT.Checked),
                FlavourId = (int)cmbFlavour.SelectedValue,
                ProductName = txtProductName.Text,
                SKUCode = txtProductName.Text,
                weight = float.Parse(txtWeight.Text),
                UnitOfMeasureId = (int)cmbUnit.SelectedValue,
                PacketPerCartoon = (int)txtPacketsPerCartoon.Value,
                PerCartoonRate = txtRatePerCartoon.Value,
                ProductNormTemplateModel = normtemplateModel,
                ProductNormTemplateDetailModels = listNormDetails,
                CreatedBy = 1,
                CreatedDate = DateTime.Now.Date,
            };
            _productService.SaveProductAndNormTempalte(proModel);
        }
    }
}
