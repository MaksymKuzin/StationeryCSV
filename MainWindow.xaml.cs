using System;
using System.Linq;
using System.Windows;
using Stationery.Models;
using Stationery.Service;

public partial class MainWindow : Window
{
    private readonly CsvDataService _csvService;
    private List<Goods> _goods;
    private List<Delivery> _deliveries;

    public MainWindow()
    {
        InitializeComponent();
        _csvService = new CsvDataService();
        LoadData();
    }

    private void LoadData()
    {
        _goods = _csvService.LoadGoods();
        _deliveries = _csvService.LoadDeliveries();
        GoodsDataGrid.ItemsSource = _goods;
    }

    private void CalculateStockValue_Click(object sender, RoutedEventArgs e)
    {
        if (!int.TryParse(SupplierIdBox.Text, out int supplierId))
        {
            MessageBox.Show("Invalid Supplier ID. Please enter a valid number.");
            return;
        }

        var totalValue = _deliveries
            .Where(d => d.SupplierId == supplierId)
            .Join(_goods, d => d.GoodsId, g => g.GoodsId, (d, g) => d.Quantity * g.UnitPrice)
            .Sum();

        MessageBox.Show($"Загальна вартість товарів для постачальника {supplierId}: {totalValue:C}");
    }
}
