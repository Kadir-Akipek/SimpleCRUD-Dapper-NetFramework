using CSharpEgitimKampi501.DTOs;
using Dapper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi501
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}
		SqlConnection connection = new SqlConnection("Server=KADIRAKIPEK\\SQLEXPRESS;" +
			"initial Catalog=EgitimKampi501Db;integrated security = true");
		private async void btnList_Click(object sender, EventArgs e) //metodun kendiside asenkton olmalı
		{
			string query = "Select * From TblProduct";
			var values = await connection.QueryAsync<ResultProductDTO>(query); //Dapper'da verileri listelemek için bu metodu kullanırız
			dataGridView1.DataSource = values;
		}

		private async void btnAdd_Click(object sender, EventArgs e)
		{
			string query = "insert into TblProduct (ProductName, ProductStock, ProductPrice,ProductCategory) values" +
				"(@productName,@productStock,@productPrice,@productCategory)";
			var parameters = new DynamicParameters(); //dapper'da parametre oluşturma
			parameters.Add("@productName",txtProductName.Text);
			parameters.Add("@productStock",txtProductStock.Text);
			parameters.Add("@productPrice",txtProductPrice.Text);
			parameters.Add("@productCategory",txtProductCategory.Text);
			await connection.ExecuteAsync(query, parameters); //query'mizi parametrelerden gelen değerlerle çalıştırıp, veri tabanına yansıtacağız
			MessageBox.Show("Yeni kitap ekleme işlemi başarılı");
		}

		private async void btnDelete_Click(object sender, EventArgs e)
		{
			string query = "delete from TblProduct where ProductId = @productId";
			var parameters = new DynamicParameters();
			parameters.Add("@productId", txtProductId.Text);
			await connection.ExecuteAsync(query, parameters);
			MessageBox.Show("Kitap silme işlemi başarıyla tamamlandı");
		}

		private async void btnUpdate_Click(object sender, EventArgs e)
		{
			string query = "Update TblProduct Set ProductName = @productName, ProductPrice = @productPrice, " +
				"ProductStock = @productStock, ProductCategory = @productCategory where ProductId = @productId";
			var parameters = new DynamicParameters();
			parameters.Add("@productName", txtProductName.Text);
			parameters.Add("@productStock", txtProductStock.Text);
			parameters.Add("@productPrice", txtProductPrice.Text);
			parameters.Add("@productCategory", txtProductCategory.Text);
			parameters.Add("@productId", txtProductId.Text);
			await connection.ExecuteAsync(query, parameters);
			MessageBox.Show("Kitap güncelleme işlemi başarılı bir şekilde yapıldı");
		}

		private async void Form1_Load(object sender, EventArgs e)
		{
			string query1 = "Select Count(*) from TblProduct";
			var productTotalCount = await connection.QueryFirstOrDefaultAsync<int>(query1);
			lblTotalProductCount.Text = productTotalCount.ToString();

			string query2 = "Select ProductName from TblProduct Where ProductPrice = (Select Max(ProductPrice) from TblProduct)";
			var maxPriceProductName = await connection.QueryFirstOrDefaultAsync<string>(query2);
			lblMaxPriceProductName.Text = maxPriceProductName.ToString();

			string query3 = "Select Count(Distinct(ProductCategory)) From TblProduct";
			var distinctProductCount = await connection.QueryFirstOrDefaultAsync<int>(query3);
			lblDistinctCategoryCount.Text = distinctProductCount.ToString();
		}
	}
}
